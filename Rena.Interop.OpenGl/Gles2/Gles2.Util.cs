
using System.Buffers.Text;

namespace Rena.Interop.OpenGl;

public partial class Gles2
{
    internal static ReadOnlySpan<byte> OpenGlEsCmPrefix => "OpenGL ES-CM"u8;
    internal static ReadOnlySpan<byte> OpenGlEsCxPrefix => "OpenGL ES-CX"u8;
    internal static ReadOnlySpan<byte> OpenGlScPrefix => "OpenGL SC"u8;
    internal static ReadOnlySpan<byte> OpenGlEsPrefix => "OpenGL ES"u8;

    internal static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor)
    {
        const byte DotAscii = (byte)'.';

        if (value.StartsWith(OpenGlEsCmPrefix))
            value = value[OpenGlEsCmPrefix.Length..];
        else if (value.StartsWith(OpenGlEsCxPrefix))
            value = value[OpenGlEsCxPrefix.Length..];
        else if (value.StartsWith(OpenGlScPrefix))
            value = value[OpenGlScPrefix.Length..];
        else if (value.StartsWith(OpenGlEsPrefix))
            value = value[OpenGlEsPrefix.Length..];

        var dotIndex = value.IndexOf(DotAscii);

        if (Utf8Parser.TryParse(value[..dotIndex], out major, out _)
        && Utf8Parser.TryParse(value[(dotIndex + 1)..], out minor, out _))
            return true;

        major = minor = 0;
        return false;
    }
}
        
