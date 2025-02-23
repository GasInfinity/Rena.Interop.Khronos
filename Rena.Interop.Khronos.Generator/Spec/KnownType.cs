using System.Diagnostics.CodeAnalysis;

namespace Rena.Interop.Khronos.Generator;

public class KnownType(KnownTypeKind KnownKind) : IType
{
    public readonly KnownTypeKind KnownKind = KnownKind;

    public int PointerDepth
        => 0;

    public string SharpType
        => KnownKind.ToTypeString();

    public IType PointerStrippedType
        => this;

    public override string ToString()
        => ToString(null, null);

    public string ToString(string? format, IFormatProvider? formatProvider)
        => $"{this}";

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => destination.TryWrite($"{KnownKind.ToTypeString()}", out charsWritten);

    public static bool TryParse(ReadOnlySpan<char> value, [NotNullWhen(true)] out KnownType? knownType)
    {
        KnownTypeKind kind = (KnownTypeKindExtensions.Parse(value));
        
        if(kind == KnownTypeKind.Unknown)
        {
            knownType = null;
            return false;
        }

        knownType = new(kind);
        return true;
    }
}
