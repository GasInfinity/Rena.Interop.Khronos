namespace Rena.Interop.Khronos.Generator;

public sealed class UnknownType(string Name) : IType
{
    public readonly string Name = Name;

    public int PointerDepth
        => 0;

    public string SharpType
        => Name;

    public IType PointerStrippedType
        => this;

    public string ToString(string? format, IFormatProvider? formatProvider)
        => $"{this}";

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => destination.TryWrite($"{SharpType}", out charsWritten);
}
