using System.Runtime.InteropServices;

namespace Rena.Interop.EGL;

public unsafe partial class EGL
{
    [DllImport("EGL", CallingConvention = CallingConvention.Cdecl, EntryPoint = "eglGetProcAddress", ExactSpelling = true)]
    public static extern void* NativeGetProcAddress(byte* procname);
}
