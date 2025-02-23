namespace Rena.Interop.Khronos.Generator;

public enum KhronosSpecification
{
    GL,
    EGL,
    WGL,
    GLX,
    Vulkan
}

public static class KhronosSpecificationExtension
{
    public static string GetFileUrl(this KhronosSpecification spec)
        => spec switch
        {
            KhronosSpecification.GL => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/gl.xml",
            KhronosSpecification.EGL => "https://raw.githubusercontent.com/KhronosGroup/EGL-Registry/main/api/egl.xml",
            KhronosSpecification.WGL => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/wgl.xml",
            KhronosSpecification.GLX => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/glx.xml",
            KhronosSpecification.Vulkan => "https://raw.githubusercontent.com/KhronosGroup/Vulkan-Docs/main/xml/vk.xml",
            _ => string.Empty
        };
}
