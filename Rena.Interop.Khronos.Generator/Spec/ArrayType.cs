namespace Rena.Interop.Khronos.Generator;

public sealed class ArrayType(string Length, IType InnerType) : IType
{
    public readonly string Length = Length;
    public readonly IType InnerType = InnerType;

    public int PointerDepth
        => InnerType.PointerDepth;

    public string SharpType
        => $"{InnerType.SharpType}";

    public IType PointerStrippedType
        => InnerType.PointerStrippedType;

    public override string ToString()
        => ToString(null, null);

    public string ToString(string? format, IFormatProvider? formatProvider)
        => $"{this}";

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => destination.TryWrite($"{SharpType}", out charsWritten);
}
