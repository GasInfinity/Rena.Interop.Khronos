
using System.Buffers.Text;

namespace Rena.Interop.OpenGL;

public unsafe partial class GLES2
{
    public delegate void* LoadFunction(byte* name);

    const byte DotAscii = (byte)'.';
    const byte SpaceAscii = (byte)' ';

    internal static ReadOnlySpan<byte> OpenGlEsCmPrefix => "OpenGL ES-CM"u8;
    internal static ReadOnlySpan<byte> OpenGlEsCxPrefix => "OpenGL ES-CX"u8;
    internal static ReadOnlySpan<byte> OpenGlScPrefix => "OpenGL SC"u8;
    internal static ReadOnlySpan<byte> OpenGlEsPrefix => "OpenGL ES"u8;

    internal static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor, out bool isEmbedded)
    {
        if (value.StartsWith(OpenGlEsCmPrefix))
        {
            value = value[(OpenGlEsCmPrefix.Length + 1)..];
            isEmbedded = true;
        }
        else if (value.StartsWith(OpenGlEsCxPrefix))
        {
            value = value[(OpenGlEsCxPrefix.Length + 1)..];
            isEmbedded = true;
        }
        else if (value.StartsWith(OpenGlEsPrefix))
        {
            value = value[(OpenGlEsPrefix.Length + 1)..];
            isEmbedded = true;
        }
        else if (value.StartsWith(OpenGlScPrefix))
        {
            value = value[(OpenGlScPrefix.Length + 1)..];
            isEmbedded = true;
        }
        else
        {
            isEmbedded = false;
        }

        return TryParseVersion(value, out major, out minor);
    }

    internal static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor)
    {
        var dotIndex = value.IndexOf(DotAscii);
        var spaceIndex = value.IndexOf(SpaceAscii);

        if (dotIndex == -1)
        {
            (major, minor) = (default, default);
            return false;
        }

        var fromFirstDot = value[(dotIndex + 1)..];
        var nextDot = fromFirstDot.IndexOf(DotAscii);
        var lastIndex = nextDot != -1 ? nextDot : (spaceIndex != -1 ? spaceIndex : fromFirstDot.Length);

        if (Utf8Parser.TryParse(value[..dotIndex], out major, out _)
        && Utf8Parser.TryParse(fromFirstDot[..lastIndex], out minor, out _))
            return true;

        major = minor = 0;
        return false;
    }
}

