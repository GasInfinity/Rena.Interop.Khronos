namespace Rena.Interop.Khronos.Generator;

public sealed class PointerType : IType
{
    public required IType InnerType;

    public int PointerDepth
        => 1 + InnerType.PointerDepth;

    public string SharpType
        => $"{InnerType.SharpType}*";

    public IType PointerStrippedType
        => InnerType.PointerStrippedType;

    public override string ToString()
        => ToString(null, null);

    public string ToString(string? format, IFormatProvider? formatProvider)
        => $"{this}";

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => destination.TryWrite($"{SharpType}", out charsWritten);
}
