namespace Rena.Interop.OpenGL.Generator;

public sealed class PointerType : IType
{
    public required IType InnerType { get; init; }
    public int PointerDepth
        => 1 + InnerType.PointerDepth;

    public override string ToString()
        => ToString(null, null);

    public string ToString(string? format, IFormatProvider? formatProvider)
        => $"{this}";

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => destination.TryWrite($"{InnerType}*", out charsWritten);
}