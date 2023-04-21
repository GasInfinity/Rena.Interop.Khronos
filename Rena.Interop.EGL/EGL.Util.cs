using System.Buffers.Text;

namespace Rena.Interop.EGL;

public unsafe partial class EGL
{
    const byte DotAscii = (byte)'.';
    const byte SpaceAscii = (byte)' ';
    
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
        
        if (Utf8Parser.TryParse(value[..dotIndex], out major, out _) && Utf8Parser.TryParse(fromFirstDot[..lastIndex], out minor, out _))
            return true;
        
        major = minor = 0;
        return false;
    }
}
