using System.Collections.Immutable;

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

    public static bool TryGetSupported(string supported, out ImmutableArray<GLApi> glSupported, out GLProfile profile)
    {
        profile = GLProfile.None;
        var span = supported.AsSpan();
        var nextSplitIndex = span.IndexOf('|');

        var listSupported = new List<GLApi>();
        while (nextSplitIndex != -1)
        {
            var supportedSplitted = span[..(nextSplitIndex)];

            GLApi api = GLApi.GL;
            switch (supportedSplitted)
            {
                case "glcore":
                    {
                        profile = GLProfile.Core;
                        break;
                    }
                case "gles1":
                    {
                        api = GLApi.GLES1;
                        break;
                    }
                case "gles2":
                    {
                        api = GLApi.GLES2;
                        break;
                    }
                case "glsc2":
                    {
                        api = GLApi.GLES2;
                        break;
                    }
            }

            listSupported.Add(api);
            span = span[(nextSplitIndex + 1)..];
            nextSplitIndex = span.IndexOf('|');
        }

        glSupported = listSupported.ToImmutableArray();
        return false;
    }
}