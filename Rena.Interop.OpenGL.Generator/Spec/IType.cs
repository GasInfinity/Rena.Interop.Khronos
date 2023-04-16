namespace Rena.Interop.OpenGL.Generator;

public interface IType : ISpanFormattable
{
    public int PointerDepth { get; }

    public static IType ParseFrom(ReadOnlySpan<char> value)
    {
        const string ConstKeyword = "const";
        value = value.Trim();

        if (value.StartsWith(ConstKeyword))
            value = value[ConstKeyword.Length..];

        var firstAsterisk = value.IndexOf('*');

        if (firstAsterisk == -1)
            return new KnownType()
            {
                RealType = value.ToString(),
                Kind = KnownTypeKindExtensions.FromString(value)
            };

        var named = value[..firstAsterisk].Trim().ToString();
        IType type = new KnownType()
        {
            RealType = named.ToString(),
            Kind = KnownTypeKindExtensions.FromString(named)
        };

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