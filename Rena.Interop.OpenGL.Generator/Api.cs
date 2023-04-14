namespace Rena.Interop.OpenGL.Generator;

public enum Api : byte
{
    None,
    GL,
    GLES1,
    GLES2,
    GLSC2,
    GLX,
    GLW,
    EGL
}

public static class ApiExtensions
{
    public static string ToXmlString(this Api api)
        => api switch
        {
            Api.GL => "gl",
            Api.GLES1 => "gles1",
            Api.GLES2 => "gles2",
            Api.GLSC2 => "glsc2",
            Api.GLX => "glx",
            Api.GLW => "glw",
            Api.EGL => "egl",
            _ => string.Empty
        };

    public static Api FromXmlString(string api)
        => api switch
        {
            "gl" => Api.GL,
            "gles1" => Api.GLES1,
            "gles2" => Api.GLES2,
            "glsc2" => Api.GLSC2,
            "glx" => Api.GLX,
            "glw" => Api.GLW,
            "egl" => Api.EGL,
            _ => Api.None
        };
}