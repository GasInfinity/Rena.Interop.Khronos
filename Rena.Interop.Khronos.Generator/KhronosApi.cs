namespace Rena.Interop.Khronos.Generator;

public enum KhronosApi
{
    None,
    GL,
    GLES1,
    GLES2,
    GLSC2,
    Vulkan,
    VulkanSC,
    EGL,
    WGL,
    GLX
}

public static class KhronosApiExtensions
{
    public static KhronosApi Parse(string value)
        => value switch
        {
            "gl" => KhronosApi.GL,
            "glcompatibility" => KhronosApi.GL,
            "glcore" => KhronosApi.GL,
            "gles1" => KhronosApi.GLES1,
            "gles2" => KhronosApi.GLES2,
            "glsc2" => KhronosApi.GLSC2,
            "vulkan" => KhronosApi.Vulkan,
            "vulkansc" => KhronosApi.VulkanSC,
            "egl" => KhronosApi.EGL,
            "wgl" => KhronosApi.WGL,
            "glx" => KhronosApi.GLX,
            _ => KhronosApi.None
        };
}
