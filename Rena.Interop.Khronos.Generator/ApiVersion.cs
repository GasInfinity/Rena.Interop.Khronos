using System.Diagnostics.CodeAnalysis;

namespace Rena.Interop.Khronos.Generator;

public readonly record struct ApiVersion(ushort Major, ushort Minor) : IEquatable<ApiVersion>, IComparable<ApiVersion>, ISpanParsable<ApiVersion>
{
    public readonly ushort Major = Major;
    public readonly ushort Minor = Minor;

    public bool IsIncluded(ApiVersion version)
        => Major > version.Major || (Major == version.Major && Minor >= version.Minor);

    public int CompareTo(ApiVersion other)
        => Equals(other) ? 0 : (Major > other.Major ? 1 : (Major >= other.Major & Minor > other.Minor ? 1 : -1));

    public override string ToString()
        => $"{Major}.{Minor}";

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out ApiVersion result)
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
            result = new(major, minor);
            return true;
        }

        result = default;
        return false;
    }

    public static ApiVersion Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        if (!TryParse(s, provider, out var result))
            throw new FormatException($"Unknown api version '{s}'");

        return result;
    }

    public static ApiVersion Parse(string s, IFormatProvider? provider)
        => Parse(s.AsSpan(), provider);

    public static ApiVersion Parse(string s)
        => Parse(s, null);

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ApiVersion result)
        => TryParse(s, provider, out result);

    public static bool TryParse(ReadOnlySpan<char> s, out ApiVersion result)
        => TryParse(s, null, out result);
}
