namespace Rena.Interop.OpenGl.Generator;

public enum Api : byte
{
    None,
    Gl,
    Gles1,
    Gles2,
    Glsc2,
    Glx,
    Glw,
    Egl
}

public static class ApiExtensions
{
    public static string ToXmlString(this Api api)
        => api switch
        {
            Api.Gl => "gl",
            Api.Gles1 => "gles1",
            Api.Gles2 => "gles2",
            Api.Glsc2 => "glsc2",
            Api.Glx => "glx",
            Api.Glw => "glw",
            Api.Egl => "egl",
            _ => string.Empty
        };

    public static Api FromXmlString(string api)
        => api switch
        {
            "gl" => Api.Gl,
            "gles1" => Api.Gles1,
            "gles2" => Api.Gles2,
            "glsc2" => Api.Glsc2,
            "glx" => Api.Glx,
            "glw" => Api.Glw,
            "egl" => Api.Egl,
            _ => Api.None
        };
}