using System.Diagnostics.CodeAnalysis;

namespace Rena.Interop.OpenGL.Generator;

public readonly struct ApiVersion : IEquatable<ApiVersion>, IComparable<ApiVersion>, ISpanParsable<ApiVersion>
{
    public required ushort Major { get; init; }
    public ushort Minor { get; init; }

    public bool IsIncluded(ApiVersion version)
        => Major > version.Major || (Major == version.Major && Minor >= version.Minor);

    public bool Equals(ApiVersion other)
        => Major == other.Major && Minor == other.Minor;

    public int CompareTo(ApiVersion other)
        => Equals(other) ? 0 : (Major > other.Major ? 1 : (Major >= other.Major & Minor > other.Minor ? 1 : -1));

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is ApiVersion version && Equals(version);

    public override int GetHashCode()
        => HashCode.Combine(Major, Minor);

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

    public static bool operator ==(ApiVersion left, ApiVersion right)
        => left.Equals(right);

    public static bool operator !=(ApiVersion left, ApiVersion right)
        => !(left == right);
}