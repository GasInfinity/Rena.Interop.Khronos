namespace Rena.Interop.Khronos.Generator;

public interface IType : ISpanFormattable, IFormattable
{
    int PointerDepth { get; }
    string SharpType { get; }
    IType PointerStrippedType { get; }

    public static IType ParseFrom(ReadOnlySpan<char> value)
    {
        const string ConstKeyword = "const";
        const string StructKeyword = "struct";
        value = value.Trim();
        bool isStruct = false;

        if (value.StartsWith(ConstKeyword))
        {
            value = value[ConstKeyword.Length..];
            value = value.TrimStart();
        }

        if (value.StartsWith(StructKeyword))
        {
            value = value[StructKeyword.Length..];
            isStruct = true;
        }

        var firstAsterisk = value.IndexOf('*');

        if (firstAsterisk == -1)
        {
            return isStruct ? new StructType(value.ToString()) : (KnownType.TryParse(value, out KnownType? t) ? t : new UnknownType(value.ToString()));
        }

        var named = value[..firstAsterisk].Trim().ToString();
        IType type = isStruct ? new StructType(named) : (KnownType.TryParse(named, out KnownType? k) ? k : new UnknownType(named));
        value = value[firstAsterisk..];

        type = ParsePointers(type, ref value);

        if (value.StartsWith(ConstKeyword))
        {
            value = value[ConstKeyword.Length..];
            type = ParsePointers(type, ref value);
        }

        return type;
    }

    private static IType ParsePointers(IType inner, ref ReadOnlySpan<char> type)
    {
        while (type.Length > 0 && type[0] is '*' or ' ')
        {
            if (type[0] is '*')
                inner = new PointerType()
                {
                    InnerType = inner
                };

            type = type[1..];
        }

        return inner;
    }
}
