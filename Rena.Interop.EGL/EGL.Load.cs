using System.Runtime.InteropServices;

namespace Rena.Interop.EGL;

public unsafe partial class EGL
{
    public readonly ushort Major;
    public readonly ushort Minor;
    public readonly bool Version10;
    public readonly bool Version11;
    public readonly bool Version12;
    public readonly bool Version13;
    public readonly bool Version14;
    public readonly bool Version15;
    
    // Extensions
    
    public EGL(LoadFunction loadFunc)
    {
        fixed(byte* name = eglQueryStringFunctionName)
            eglQueryString = (delegate* unmanaged<void*, int, byte*>)loadFunc(name);
        fixed(byte* name = eglGetErrorFunctionName)
            eglGetError = (delegate* unmanaged<int>)loadFunc(name);
        if(eglQueryString == null || eglGetError == null) return;
        var version = eglQueryString((void*)EGL_NO_DISPLAY, EGL_VERSION);
        _ = eglGetError();
        if(version == null) (Major, Minor) = (1, 0);
        else if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor)) return;
        
        Version10 = Major > 1 || (Major == 1 && Minor >= 0);
        Version11 = Major > 1 || (Major == 1 && Minor >= 1);
        Version12 = Major > 1 || (Major == 1 && Minor >= 2);
        Version13 = Major > 1 || (Major == 1 && Minor >= 3);
        Version14 = Major > 1 || (Major == 1 && Minor >= 4);
        Version15 = Major > 1 || (Major == 1 && Minor >= 5);
        
        if(Version10)
        {
            fixed(byte* name = eglChooseConfigFunctionName)
                eglChooseConfig = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglCopyBuffersFunctionName)
                eglCopyBuffers = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLNativePixmapType */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglCreateContextFunctionName)
                eglCreateContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLContext */ void*, /* EGLint */ int*, /* EGLContext */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePbufferSurfaceFunctionName)
                eglCreatePbufferSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePixmapSurfaceFunctionName)
                eglCreatePixmapSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativePixmapType */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglCreateWindowSurfaceFunctionName)
                eglCreateWindowSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativeWindowType */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglDestroyContextFunctionName)
                eglDestroyContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglDestroySurfaceFunctionName)
                eglDestroySurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetConfigAttribFunctionName)
                eglGetConfigAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetConfigsFunctionName)
                eglGetConfigs = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetCurrentDisplayFunctionName)
                eglGetCurrentDisplay = (delegate* unmanaged</* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = eglGetCurrentSurfaceFunctionName)
                eglGetCurrentSurface = (delegate* unmanaged</* EGLint */ int, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglGetDisplayFunctionName)
                eglGetDisplay = (delegate* unmanaged</* EGLNativeDisplayType */ void*, /* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = eglGetErrorFunctionName)
                eglGetError = (delegate* unmanaged</* EGLint */ int>)loadFunc(name);
            fixed(byte* name = eglGetProcAddressFunctionName)
                eglGetProcAddress = (delegate* unmanaged</* char */ byte*, /* __eglMustCastToProperFunctionPointerType */ void*>)loadFunc(name);
            fixed(byte* name = eglInitializeFunctionName)
                eglInitialize = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglMakeCurrentFunctionName)
                eglMakeCurrent = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLSurface */ void*, /* EGLContext */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglQueryContextFunctionName)
                eglQueryContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglQueryStringFunctionName)
                eglQueryString = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* char */ byte*>)loadFunc(name);
            fixed(byte* name = eglQuerySurfaceFunctionName)
                eglQuerySurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglSwapBuffersFunctionName)
                eglSwapBuffers = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglTerminateFunctionName)
                eglTerminate = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglWaitGLFunctionName)
                eglWaitGL = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglWaitNativeFunctionName)
                eglWaitNative = (delegate* unmanaged</* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version11)
        {
            fixed(byte* name = eglBindTexImageFunctionName)
                eglBindTexImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglReleaseTexImageFunctionName)
                eglReleaseTexImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglSurfaceAttribFunctionName)
                eglSurfaceAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglSwapIntervalFunctionName)
                eglSwapInterval = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version12)
        {
            fixed(byte* name = eglBindAPIFunctionName)
                eglBindAPI = (delegate* unmanaged</* EGLenum */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglQueryAPIFunctionName)
                eglQueryAPI = (delegate* unmanaged</* EGLenum */ int>)loadFunc(name);
            fixed(byte* name = eglCreatePbufferFromClientBufferFunctionName)
                eglCreatePbufferFromClientBuffer = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglReleaseThreadFunctionName)
                eglReleaseThread = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglWaitClientFunctionName)
                eglWaitClient = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version13)
        {
        }
        
        if(Version14)
        {
            fixed(byte* name = eglGetCurrentContextFunctionName)
                eglGetCurrentContext = (delegate* unmanaged</* EGLContext */ void*>)loadFunc(name);
        }
        
        if(Version15)
        {
            fixed(byte* name = eglCreateSyncFunctionName)
                eglCreateSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLAttrib */ nint*, /* EGLSync */ void*>)loadFunc(name);
            fixed(byte* name = eglDestroySyncFunctionName)
                eglDestroySync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglClientWaitSyncFunctionName)
                eglClientWaitSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLTime */ ulong, /* EGLint */ int>)loadFunc(name);
            fixed(byte* name = eglGetSyncAttribFunctionName)
                eglGetSyncAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLAttrib */ nint*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglCreateImageFunctionName)
                eglCreateImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLAttrib */ nint*, /* EGLImage */ void*>)loadFunc(name);
            fixed(byte* name = eglDestroyImageFunctionName)
                eglDestroyImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLImage */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetPlatformDisplayFunctionName)
                eglGetPlatformDisplay = (delegate* unmanaged</* EGLenum */ int, /* void */ void*, /* EGLAttrib */ nint*, /* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePlatformWindowSurfaceFunctionName)
                eglCreatePlatformWindowSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePlatformPixmapSurfaceFunctionName)
                eglCreatePlatformPixmapSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglWaitSyncFunctionName)
                eglWaitSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
    }
}
