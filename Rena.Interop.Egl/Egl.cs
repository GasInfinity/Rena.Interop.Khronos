using System.Runtime.InteropServices;

namespace Rena.Interop.Egl;

public unsafe partial class Egl
{
    [DllImport("EGL", CallingConvention = CallingConvention.Cdecl, EntryPoint = "eglGetProcAddress", ExactSpelling = true)]
    public static extern void* NativeGetProcAddress(byte* procname);
}
