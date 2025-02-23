using System.Collections.Immutable;
using System.Text;
using System.Xml;

namespace Rena.Interop.Khronos.Generator;

public readonly struct Type(Type.Kind TypeKind, string Name, object Data, string? Requires = null)
{
    public readonly Kind TypeKind = TypeKind; 
    public readonly string Name = Name;
    public readonly object Data = Data;
    public readonly string Requires = Requires ?? string.Empty;

    public enum Kind
    {
        Typedef,
        Handle,
        Struct,
        Union
    }
    
    public record class StructDeclaration(OrderedDictionary<(KhronosApi, string), StructField> Fields)
    {
        public readonly OrderedDictionary<(KhronosApi, string), StructField> Fields = Fields;
    }

    public record struct StructField(IType Type, string Values)
    {
        public readonly IType Type = Type;
        public readonly string Value = Values;
    }

    public static bool TryDeserializeTo(XmlNode n, Dictionary<KhronosApi, Dictionary<string, Type>> definedTypes)
    {
        if(n.Name != "types" || n is not XmlElement element)
            return false;

        foreach(XmlNode c in element)
        {
            if(c.Name != "type" || c is not XmlElement child)
                continue;

            KhronosApi api = KhronosApiExtensions.Parse(child.GetAttribute("api"));
            string category = child.GetAttribute("category");

            if(!definedTypes.TryGetValue(api, out Dictionary<string, Type>? apiTypes))
                definedTypes.Add(api, apiTypes = new());

            if(string.IsNullOrEmpty(category) || category is "bitmask" or "funcpointer" or "basetype")
            {
                string inner = child.InnerText;
                string requires = !string.IsNullOrEmpty(category) ? child.GetAttribute("requires") : string.Empty;
                 
                if(!TryParseTypedef(apiTypes, inner, requires, out Type t))
                {
                    if(!TryParseOpaqueStruct(inner, out t))
                    {
                        string requiredName = child.GetAttribute("name");

                        if(requiredName.All(char.IsLower)) // Surely is not intended to be a typedef
                            continue;

                        if(!string.IsNullOrEmpty(requiredName)
                        && KnownTypeKindExtensions.Parse(requiredName) == KnownTypeKind.Unknown)
                            apiTypes.Add(requiredName, new(Kind.Typedef, requiredName, child.GetAttribute("alias") is string s && !string.IsNullOrEmpty(s) ? s : IType.ParseFrom("void*")));
                        continue;
                    }
                    
                    apiTypes.Add(t.Name, t);
                    continue;
                }

                apiTypes.Add(t.Name, t);
                continue;
            }

            string name = child.GetAttribute("name");
            string alias = child.GetAttribute("alias");

            if(!string.IsNullOrEmpty(alias))
            {
                apiTypes.Add(name, new(Kind.Typedef, name, $"<<NAMESPACE>>{alias}"));
                continue;
            }

            switch(category)
            {
                case "struct":
                case "union":
                    {
                        apiTypes.Add(name, ParseStruct(name, child, category == "union")); 
                        break;
                    }
                case "handle":
                    {
                        string handleName = child["name"]!.InnerText;
                        apiTypes.Add(handleName, new(Kind.Handle, handleName, child.GetAttribute("parent")));
                        break;
                    }
            }
        }

        return true;
    }

    private static Type ParseStruct(string name, XmlElement e, bool isUnion)
    {
        OrderedDictionary<(KhronosApi, string), StructField> fields = [];

        foreach(XmlNode c in e)
        {
            if(c is not XmlElement child || child.Name != "member")
                continue;

            string memberText = child.InnerText;
            string values = child.GetAttribute("values");
            string possibleApi = child.GetAttribute("api");
            KhronosApi api = !string.IsNullOrEmpty(possibleApi) ? KhronosApiExtensions.Parse(possibleApi) : KhronosApi.None;
            string memberName = child["name"]!.InnerText;
            string memberComment = child["comment"]?.InnerText ?? string.Empty;
            
            ReadOnlySpan<char> uncommentedMember = memberText.AsSpan()[..^memberComment.Length];
            ReadOnlySpan<char> possibleBitfieldArray = uncommentedMember[(uncommentedMember.LastIndexOf(memberName) + memberName.Length)..];

            IType type = IType.ParseFrom(uncommentedMember[..^(memberName.Length + possibleBitfieldArray.Length)].Trim());
            if(possibleBitfieldArray.Length > 0)
            {
                // Is Array
                if(possibleBitfieldArray.StartsWith('['))
                {
                    StringBuilder arrayLength = new();
                    int start = 0;
                    do
                    {
                        if(start != 0)
                            arrayLength.Append('*');

                        possibleBitfieldArray = possibleBitfieldArray[(start + 1)..];
                        ReadOnlySpan<char> dimension = possibleBitfieldArray[..possibleBitfieldArray.IndexOf(']')];
                        if(!int.TryParse(dimension, out int v))
                        {
                            // This is only supported on vulkan so lets hardcode this! :D
                            arrayLength.Append("Constants.").Append(Utilities.SnakeToPascalcase(dimension["VK_".Length..]));
                        }
                        else
                        {
                            arrayLength.Append(v);
                        }

                        start = possibleBitfieldArray.IndexOf('[');
                    }
                    while(start != -1);
                    type = new ArrayType(arrayLength.ToString(), type);
                }

            }

            fields.Add((api, memberName), new(type, values));
        }

        return new Type(isUnion ? Kind.Union : Kind.Struct, name, new StructDeclaration(fields));
    }

    private static bool TryParseOpaqueStruct(string strct, out Type t)
    {
        if(!strct.StartsWith("struct "))
        {
            t = default;
            return false;
        }

        t = new(Kind.Struct, strct["struct ".Length..^1], new StructDeclaration([]));
        return true;
    }

    private static bool TryParseTypedef(Dictionary<string, Type> apiTypes, string typedef, string requires, out Type t)
    {
        if(!typedef.StartsWith("typedef "))
        {
            t = default;
            return false;
        } 

        ReadOnlySpan<char> types = typedef.AsSpan()["typedef ".Length..^1];

        int baseOffset = types.StartsWith("unsigned ") ? "unsigned ".Length : 0; 
        ReadOnlySpan<char> unprefixedTypeAlias = types[baseOffset..];

        int firstParenIndex = unprefixedTypeAlias.IndexOf('(');

        if(firstParenIndex != -1) // Assume function pointer
        {
            t = ParseSimpleFunctionPointer(types, apiTypes);
            return true;
        }

        return TryParseSimpleTypedef(types, requires, baseOffset, apiTypes, out t);
    }

    private static bool TryParseSimpleTypedef(ReadOnlySpan<char> typedef, string requires, int baseOffset, Dictionary<string, Type> apiTypes, out Type t)
    {
        ReadOnlySpan<char> unprefixedTypeAlias = typedef[baseOffset..];

        int typeEndIndex = unprefixedTypeAlias.IndexOf('*');
        if(typeEndIndex != -1)
        {
            while(unprefixedTypeAlias[typeEndIndex] is '*' or ' ')
                ++typeEndIndex;
        }
        else
        {
            typeEndIndex = unprefixedTypeAlias.IndexOf(' ');
        }

        ReadOnlySpan<char> baseTypeSpan = typedef[..(baseOffset + typeEndIndex)].Trim();
        IType baseType = IType.ParseFrom(baseTypeSpan);

        if(baseType is KnownType known && known.KnownKind == KnownTypeKind.Void)
            baseType = new KnownType(KnownTypeKind.UInt8);

        ReadOnlySpan<char> aliasName = typedef[(baseOffset + typeEndIndex)..].Trim();
        t = new (Kind.Typedef, aliasName.ToString(), baseType, requires);
        return true;
    }

    private static Type ParseSimpleFunctionPointer(ReadOnlySpan<char> cFunctionPointer, Dictionary<string, Type> apiTypes)
    {
        int parenIndex = cFunctionPointer.IndexOf('(');
        ReadOnlySpan<char> returnTypeSpan = cFunctionPointer[..parenIndex].Trim();
        string returnType = (apiTypes.TryGetValue(returnTypeSpan.ToString(), out Type t) && t.Data is string str ? str : returnTypeSpan.ToString())!;

        ReadOnlySpan<char> functionPointerNameParams = cFunctionPointer[parenIndex..];  
        int funcNameStartIndex = functionPointerNameParams.IndexOf('*');

        while(functionPointerNameParams[++funcNameStartIndex] is '*' or ' ');

        int endAliasedNameIndex = functionPointerNameParams.IndexOf(')');
        ReadOnlySpan<char> aliasedName = functionPointerNameParams[funcNameStartIndex..endAliasedNameIndex].Trim();

        StringBuilder pointerType = new StringBuilder("delegate* unmanaged<");

        int currentParamStartIndex = endAliasedNameIndex + 2;

        if(functionPointerNameParams[currentParamStartIndex..].SequenceEqual("void)") || functionPointerNameParams[currentParamStartIndex] == ')')
            return new(Kind.Typedef, aliasedName.ToString(), pointerType.Append(returnTypeSpan).Append('>').ToString());

        while(functionPointerNameParams[currentParamStartIndex] != ')')
        {
            while(char.IsWhiteSpace(functionPointerNameParams[currentParamStartIndex]) || functionPointerNameParams[currentParamStartIndex] == ',')
                ++currentParamStartIndex;

            ReadOnlySpan<char> paramStart = functionPointerNameParams[currentParamStartIndex..].Trim();
            
            if(paramStart.StartsWith("const "))
            {
                currentParamStartIndex += "const ".Length;
                paramStart = functionPointerNameParams[currentParamStartIndex..].Trim();
            }

            int ptrTypeEnd = paramStart.IndexOf('*');
            int nextArgumentStart = paramStart.IndexOf(',');

            bool isCurrentPointerType = nextArgumentStart == -1 || ptrTypeEnd < nextArgumentStart;
            int paramTypeEndIndex;
            
            if(isCurrentPointerType && ptrTypeEnd != -1)
            {
                while(paramStart[ptrTypeEnd] is '*' or ' ')
                    ++ptrTypeEnd;

                paramTypeEndIndex = ptrTypeEnd;
            }
            else
            {
                paramTypeEndIndex = paramStart.IndexOf(' ');
            }

            ReadOnlySpan<char> paramType = paramStart[..paramTypeEndIndex].Trim();
            ReadOnlySpan<char> cleanParamType = paramType.StartsWith("const ") ? paramType["const ".Length..] : paramType;
            IType parsedParamType = IType.ParseFrom(cleanParamType); 

            string sharpParameterType;
            if(apiTypes.TryGetValue(parsedParamType.PointerStrippedType.SharpType, out Type b))
            {
                switch(b.TypeKind)
                {
                    case Kind.Struct:
                    case Kind.Handle: sharpParameterType = parsedParamType.SharpType; break;
                    case Kind.Typedef: sharpParameterType = b.Data is IType type ? type.SharpType + new string('*', parsedParamType.PointerDepth) : parsedParamType.SharpType; break;
                    default: sharpParameterType = string.Empty; break;
                }
            }
            else
            {
                sharpParameterType = parsedParamType.PointerStrippedType is UnknownType ut ? $"<<NAMESPACE>>{parsedParamType.SharpType}" : parsedParamType.SharpType;
            }
            
            pointerType.Append(sharpParameterType);

            if(nextArgumentStart == -1)
                break;

            pointerType.Append(',');
            currentParamStartIndex += nextArgumentStart;
        }
        pointerType.Append(',').Append(returnType).Append('>');
        return new (Kind.Typedef, aliasedName.ToString(), pointerType.ToString());
    }
}
