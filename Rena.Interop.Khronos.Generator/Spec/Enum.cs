using System.Collections.Immutable;
using System.Globalization;
using System.Xml;

namespace Rena.Interop.Khronos.Generator;

public readonly partial record struct Enum
{
    private static ImmutableArray<string> NonHandledTypes = [ "basetype" ];

    public readonly string Name;
    public readonly Dictionary<string, EnumValue> Values;
    public readonly bool IsBitmask;

    public Enum(string name, Dictionary<string, EnumValue> values, bool isBitmask)
        => (Name, Values, IsBitmask) = (name, values, isBitmask);

    public Enum WithBitmask() => new(Name, Values, true);

    public (Dictionary<string, string> Mapping, Enum Return) StripLongestCommonSubstringToPascalcase(string? possiblePrefix = null)
    {
        string prefix = possiblePrefix ?? string.Empty;
        Dictionary<string, EnumValue> newValues = [];
        Dictionary<string, string> mapping = [];

        if(Values.Count == 1)
        {
            (string name, EnumValue value) = Values.First();
            string possibleNewName = Utilities.SnakeToPascalcase(name.StartsWith(prefix) ? name.AsSpan()[prefix.Length..] : name);
            int commonPrefix = Utilities.LongestCommonPrefixLengthIgnoreCase(Enumerable.Repeat(possibleNewName, 1).Append(Name), false);
            int commonSuffix = Utilities.LongestCommonSuffixLengthIgnoreCase(Enumerable.Repeat(possibleNewName, 1).Append(Name), false);

            if(commonPrefix < 2 || commonPrefix == possibleNewName.Length) // Avoid literally writing an empty string or removing only a char
                commonPrefix = 0;

            if(commonSuffix < 3) // Avoid removing whole words or some chars
                commonSuffix = 0;

            ReadOnlySpan<char> newNameSpan = possibleNewName.AsSpan()[commonPrefix..^commonSuffix];
            string newName = (newNameSpan.Length > 0 && char.IsDigit(newNameSpan[0]) ? $"N{newNameSpan}" : newNameSpan).ToString();
            newValues.Add(newName, value);
            mapping.Add(name, newName);
            return (mapping, new(Name, newValues, IsBitmask));
        }

        int longestCommonPrefix = Utilities.LongestCommonPrefixLengthIgnoreCase(Values.Keys);
        int longestCommonSuffix = Utilities.LongestCommonSuffixLengthIgnoreCase(Values.Keys);
        
        foreach((var name, var value) in Values)
        {
            string newName;

            // FIXME: Very hacky
            if(name.Length == longestCommonPrefix + longestCommonSuffix)
            {
                newName = Utilities.SnakeToPascalcase(name.AsSpan()[longestCommonPrefix..]);
            }
            else
            {
                // Some OpenGL enum names could lead to this, we prefer stripping the GL_ prefix
                if(longestCommonSuffix > longestCommonPrefix || name.Length < longestCommonPrefix + longestCommonSuffix)
                {
                    newName = Utilities.SnakeToPascalcase(name.AsSpan()[longestCommonPrefix..]);
                }
                else
                {
                    newName = name.Length < longestCommonPrefix ? Utilities.SnakeToPascalcase(name) : Utilities.SnakeToPascalcase(name.AsSpan()[longestCommonPrefix..^longestCommonSuffix]);
                }
            }

            if(newName.Length > 0 && char.IsDigit(newName[0]))
                newName = "N" + newName;

            newValues.Add(newName, value);
            mapping.Add(name, newName);
        }

        return (mapping, new(Name, newValues, IsBitmask));
    }

    public static bool TryDeserializeTo(XmlNode n, Dictionary<KhronosApi, Dictionary<string, Enum>> definedEnums, Dictionary<string, Constant> definedConstants)
    {
        if(n is not XmlElement element || n.Name != "enums" || element.GetAttribute("type") is not string enumType || NonHandledTypes.Contains(enumType))
            return false;

        if(enumType == "constants")
        {
            _ = Constant.TryDeserializeRangeTo(element, definedConstants);
            return true;
        }

        string enumName = element.GetAttribute("name");

        KhronosApi enumApi = KhronosApiExtensions.Parse(element.GetAttribute("api"));
        bool isBitmask = enumType == "bitmask";

        if(string.IsNullOrEmpty(enumName))
        {
            foreach (XmlNode child in element)
            {
                if (child is not XmlElement enumValueElement || enumValueElement.Name != "enum" || !string.IsNullOrEmpty(enumValueElement.GetAttribute("deprecated")))
                    continue;
                
                KhronosApi api = KhronosApiExtensions.Parse(enumValueElement.GetAttribute("api"));
                Dictionary<string, Enum> valueGlobals = definedEnums.TryGetValue(api, out Dictionary<string, Enum>? vGlobals) ? vGlobals : new();

                (string parsedValueName, EnumValue parsedEnumValue) = DeserializeValue(enumValueElement);
                string groups = enumValueElement.GetAttribute("group");

                if(string.IsNullOrEmpty(groups))
                {
                    if(!valueGlobals.TryGetValue(string.Empty, out Enum otherEnum)) {
                        valueGlobals.Add(string.Empty, otherEnum = new(string.Empty, new(), false));
                    }

                    otherEnum.Values.Add(parsedValueName, parsedEnumValue);
                    _ = definedEnums.TryAdd(api, valueGlobals);
                    continue;
                }

                string[] groupsSplitted = groups.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                foreach(string group in groupsSplitted)
                {
                    // TODO: use ReadOnlySpan<> getter when available
                    if(!valueGlobals.TryGetValue(group, out Enum otherEnum)) {
                        valueGlobals.Add(group, otherEnum = new(group, new(), false));
                    }

                    otherEnum.Values.Add(parsedValueName, parsedEnumValue);
                }

                _ = definedEnums.TryAdd(api, valueGlobals);
            }

            return true;
        }
        
        Dictionary<string, Enum> apiEnums = definedEnums.TryGetValue(enumApi, out Dictionary<string, Enum>? enums) ? enums : new();
        Enum e = apiEnums.TryGetValue(enumName, out Enum existing) ? existing : new(enumName, new(), isBitmask);

        foreach (XmlNode child in element)
        {
            if (child is not XmlElement enumValueElement || enumValueElement.Name != "enum" || !string.IsNullOrEmpty(enumValueElement.GetAttribute("deprecated")))
                continue;

            (string name, EnumValue parsedEnumValue) = DeserializeValue(enumValueElement);
            e.Values.TryAdd(name, parsedEnumValue);    
        }

        apiEnums[enumName] = isBitmask ? e.WithBitmask() : e;
        _ = definedEnums.TryAdd(enumApi, apiEnums);
        return true;
    }

    private static (string Name, EnumValue Value) DeserializeValue(XmlElement e)
    {
        string name = e.GetAttribute("name");
        string alias = e.GetAttribute("alias");
        string bitposValue = e.GetAttribute("bitpos");

        if (string.IsNullOrEmpty(bitposValue))
        {
            string valueString = e.GetAttribute("value");

            if (string.IsNullOrEmpty(valueString))
                return (name, new(alias, 0));

            long value = ParseValue(valueString);
            return (name, new(string.Empty, value));
        }

        int bitpos = int.Parse(bitposValue, NumberStyles.Integer);
        return (name, EnumValue.FromBitposition(bitpos));
    }

    private static long ParseValue(ReadOnlySpan<char> value, NumberStyles styles = NumberStyles.Integer)
    {
        if(value.StartsWith("EGL_CAST"))
            value = value[(value.IndexOf(',')+1)..value.LastIndexOf(')')]; 

        if(value.StartsWith("0x"))
        {
            value = value["0x".Length..];
            styles = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowHexSpecifier;
        }

        return long.Parse(value, styles);
    }
}

public readonly record struct EnumValue(string Alias, long Value)
{
    public readonly string Alias = Alias;
    public readonly long Value = Value;

    public static EnumValue FromBitposition(int bitPosition)
        => new(string.Empty, (long)1 << bitPosition);
}
