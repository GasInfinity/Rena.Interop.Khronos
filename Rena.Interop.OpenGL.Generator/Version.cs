namespace Rena.Interop.OpenGL.Generator;

public readonly struct Version
{
    public required ushort Major { get; init; }
    public ushort Minor { get; init; }

    public bool IsIncluded(Version version)
        => Major > version.Major || (Major == version.Major && Minor >= version.Minor);

    public override string ToString()
        => $"{Major}.{Minor}";

    public static bool TryParse(ReadOnlySpan<char> s, out Version result)
    {
        var dotIndex = s.IndexOf('.');

        if (dotIndex == -1)
        {
            result = default;
            return false;
        }

        if (ushort.TryParse(s[..dotIndex], out ushort major)
        && ushort.TryParse(s[(dotIndex + 1)..], out ushort minor))
        {
            result = new()
            {
                Major = major,
                Minor = minor
            };
            return true;
        }

        result = default;
        return false;
    }
}