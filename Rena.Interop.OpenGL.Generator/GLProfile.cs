namespace Rena.Interop.OpenGL.Generator;

public enum GLProfile : byte
{
    None,
    Compatibility,
    Core
}

public static class GLProfileExtensions
{
    public static string ToXmlString(this GLProfile api)
        => api switch
        {
            GLProfile.Compatibility => "compatibility",
            GLProfile.Core => "core",
            _ => string.Empty
        };

    public static GLProfile FromXmlString(string value)
        => value switch
        {
            "compatibility" => GLProfile.Compatibility,
            "core" => GLProfile.Core,
            _ => GLProfile.None
        };
}