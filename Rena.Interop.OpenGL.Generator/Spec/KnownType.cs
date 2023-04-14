namespace Rena.Interop.OpenGL.Generator;

public class KnownType : IType
{
    public required string RealType { get; init; }
    public required KnownTypeKind Kind { get; init; }
    public int PointerDepth
        => 0;

    public override string ToString()
        => ToString(null, null);

    public string ToString(string? format, IFormatProvider? formatProvider)
        => $"{this}";

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => destination.TryWrite($"/* {RealType} */ {Kind.ToSharpString()}", out charsWritten);
}