namespace Rena.Interop.OpenGL.Generator;

public enum GLApi
{
    GL,
    GLES1,
    GLES2,
    GLSC2
}

public static class GLApiExtensions
{
    public static string ToFeatureString(this GLApi api)
        => api switch
        {
            GLApi.GLES1 => "gles1",
            GLApi.GLES2 => "gles2",
            GLApi.GLSC2 => "glsc2",
            _ => "gl"
        };

    public static bool IsEmbedded(this GLApi api)
        => api is not GLApi.GL;
}