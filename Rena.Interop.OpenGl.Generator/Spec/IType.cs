namespace Rena.Interop.OpenGl.Generator;

public interface IType : ISpanFormattable
{
    public int PointerDepth { get; }

    public static IType ParseFrom(ReadOnlySpan<char> value)
    {
        const string ConstKeyword = "const";
        value = value.Trim();

        if (value.StartsWith(ConstKeyword))
            value = value[ConstKeyword.Length..];

        value = value.Trim();
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

        while (value.Length > 0 && value[0] is '*' or ' ')
        {
            if (value[0] is '*')
                type = new PointerType()
                {
                    InnerType = type
                };

            value = value[1..];
        }

        return type;
    }
}