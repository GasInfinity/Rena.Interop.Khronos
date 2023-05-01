using System.Buffers;
using System.Runtime.InteropServices;

namespace Rena.Interop.EGL;

public unsafe partial class EGL
{
    public delegate void* LoadFunction(byte* name);
    public readonly ushort Major;
    public readonly ushort Minor;
    
    public readonly bool Version10;
    public readonly bool Version11;
    public readonly bool Version12;
    public readonly bool Version13;
    public readonly bool Version14;
    public readonly bool Version15;
    public EGL(LoadFunction loadFunc)
    {
        delegate* unmanaged<void*, int, byte*> eglQueryString;
        fixed(byte* name = eglQueryStringFunctionName)
            eglQueryString = (delegate* unmanaged<void*, int, byte*>)loadFunc(name);
        delegate* unmanaged<int> eglGetError;
        fixed(byte* name = eglGetErrorFunctionName)
            eglGetError = (delegate* unmanaged<int>)loadFunc(name);
        if(eglQueryString is null || eglGetError is null) return;
        var version = eglQueryString((void*)EGL_NO_DISPLAY, EGL_VERSION);
        _ = eglGetError();
        if(version == null) (Major, Minor) = (1, 0);
        else if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor)) return;
        
        Version10 = Major > 1 | (Major == 1 & Minor >= 0);
        Version11 = Major > 1 | (Major == 1 & Minor >= 1);
        Version12 = Major > 1 | (Major == 1 & Minor >= 2);
        Version13 = Major > 1 | (Major == 1 & Minor >= 3);
        Version14 = Major > 1 | (Major == 1 & Minor >= 4);
        Version15 = Major > 1 | (Major == 1 & Minor >= 5);
        
        if(Version10)
        {
            fixed(byte* name = eglChooseConfigFunctionName)
                this.ChooseConfig = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglCopyBuffersFunctionName)
                this.CopyBuffers = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLNativePixmapType */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglCreateContextFunctionName)
                this.CreateContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLContext */ void*, /* EGLint */ int*, /* EGLContext */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePbufferSurfaceFunctionName)
                this.CreatePbufferSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePixmapSurfaceFunctionName)
                this.CreatePixmapSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativePixmapType */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglCreateWindowSurfaceFunctionName)
                this.CreateWindowSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativeWindowType */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglDestroyContextFunctionName)
                this.DestroyContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglDestroySurfaceFunctionName)
                this.DestroySurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetConfigAttribFunctionName)
                this.GetConfigAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetConfigsFunctionName)
                this.GetConfigs = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetCurrentDisplayFunctionName)
                this.GetCurrentDisplay = (delegate* unmanaged</* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = eglGetCurrentSurfaceFunctionName)
                this.GetCurrentSurface = (delegate* unmanaged</* EGLint */ int, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglGetDisplayFunctionName)
                this.GetDisplay = (delegate* unmanaged</* EGLNativeDisplayType */ void*, /* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = eglGetErrorFunctionName)
                this.GetError = (delegate* unmanaged</* EGLint */ int>)loadFunc(name);
            fixed(byte* name = eglGetProcAddressFunctionName)
                this.GetProcAddress = (delegate* unmanaged</* char */ byte*, /* __eglMustCastToProperFunctionPointerType */ void*>)loadFunc(name);
            fixed(byte* name = eglInitializeFunctionName)
                this.Initialize = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglMakeCurrentFunctionName)
                this.MakeCurrent = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLSurface */ void*, /* EGLContext */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglQueryContextFunctionName)
                this.QueryContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglQueryStringFunctionName)
                this.QueryString = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* char */ byte*>)loadFunc(name);
            fixed(byte* name = eglQuerySurfaceFunctionName)
                this.QuerySurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglSwapBuffersFunctionName)
                this.SwapBuffers = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglTerminateFunctionName)
                this.Terminate = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglWaitGLFunctionName)
                this.WaitGL = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglWaitNativeFunctionName)
                this.WaitNative = (delegate* unmanaged</* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version11)
        {
            fixed(byte* name = eglBindTexImageFunctionName)
                this.BindTexImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglReleaseTexImageFunctionName)
                this.ReleaseTexImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglSurfaceAttribFunctionName)
                this.SurfaceAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglSwapIntervalFunctionName)
                this.SwapInterval = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version12)
        {
            fixed(byte* name = eglBindAPIFunctionName)
                this.BindAPI = (delegate* unmanaged</* EGLenum */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglQueryAPIFunctionName)
                this.QueryAPI = (delegate* unmanaged</* EGLenum */ int>)loadFunc(name);
            fixed(byte* name = eglCreatePbufferFromClientBufferFunctionName)
                this.CreatePbufferFromClientBuffer = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglReleaseThreadFunctionName)
                this.ReleaseThread = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglWaitClientFunctionName)
                this.WaitClient = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version13)
        {
        }
        
        if(Version14)
        {
            fixed(byte* name = eglGetCurrentContextFunctionName)
                this.GetCurrentContext = (delegate* unmanaged</* EGLContext */ void*>)loadFunc(name);
        }
        
        if(Version15)
        {
            fixed(byte* name = eglCreateSyncFunctionName)
                this.CreateSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLAttrib */ nint*, /* EGLSync */ void*>)loadFunc(name);
            fixed(byte* name = eglDestroySyncFunctionName)
                this.DestroySync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglClientWaitSyncFunctionName)
                this.ClientWaitSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLTime */ ulong, /* EGLint */ int>)loadFunc(name);
            fixed(byte* name = eglGetSyncAttribFunctionName)
                this.GetSyncAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLAttrib */ nint*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglCreateImageFunctionName)
                this.CreateImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLAttrib */ nint*, /* EGLImage */ void*>)loadFunc(name);
            fixed(byte* name = eglDestroyImageFunctionName)
                this.DestroyImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLImage */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetPlatformDisplayFunctionName)
                this.GetPlatformDisplay = (delegate* unmanaged</* EGLenum */ int, /* void */ void*, /* EGLAttrib */ nint*, /* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePlatformWindowSurfaceFunctionName)
                this.CreatePlatformWindowSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePlatformPixmapSurfaceFunctionName)
                this.CreatePlatformPixmapSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglWaitSyncFunctionName)
                this.WaitSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
    }
}
