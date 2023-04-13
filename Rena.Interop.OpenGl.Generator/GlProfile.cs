namespace Rena.Interop.OpenGl.Generator;

public enum GlProfile : byte
{
    None,
    Compatibility,
    Core
}

public static class GlProfileExtensions
{
    public static string ToXmlString(this GlProfile api)
        => api switch
        {
            GlProfile.Compatibility => "compatibility",
            GlProfile.Core => "core",
            _ => string.Empty
        };

    public static GlProfile FromXmlString(string value)
        => value switch
        {
            "compatibility" => GlProfile.Compatibility,
            "core" => GlProfile.Core,
            _ => GlProfile.None
        };
}