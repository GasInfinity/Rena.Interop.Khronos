using System.Runtime.InteropServices;

namespace Rena.Interop.Egl;

public unsafe partial class Egl
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
    
    public Egl(delegate* unmanaged<byte*, void*> loadFunc)
    {
        fixed(byte* name = "eglGetDisplay"u8)
            eglGetDisplay = (delegate* unmanaged<void*, void*>)loadFunc(name);
        fixed(byte* name = "eglGetCurrentDisplay"u8)
            eglGetCurrentDisplay = (delegate* unmanaged<void*>)loadFunc(name);
        fixed(byte* name = "eglQueryString"u8)
            eglQueryString = (delegate* unmanaged<void*, int, byte*>)loadFunc(name);
        fixed(byte* name = "eglGetError"u8)
            eglGetError = (delegate* unmanaged<int>)loadFunc(name);
        if(eglGetDisplay == null || eglGetCurrentDisplay == null || eglQueryString == null || eglGetError == null) return;
        var display = eglGetCurrentDisplay();
        if(display == (void*)EGL_NO_DISPLAY) display = eglGetDisplay((void*)EGL_DEFAULT_DISPLAY);
        if(display == (void*)EGL_NO_DISPLAY) return;
        var version = eglQueryString(display, EGL_VERSION);
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
            fixed(byte* name = "eglChooseConfig"u8)
                eglChooseConfig = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglCopyBuffers"u8)
                eglCopyBuffers = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLNativePixmapType */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglCreateContext"u8)
                eglCreateContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLContext */ void*, /* EGLint */ int*, /* EGLContext */ void*>)loadFunc(name);
            fixed(byte* name = "eglCreatePbufferSurface"u8)
                eglCreatePbufferSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = "eglCreatePixmapSurface"u8)
                eglCreatePixmapSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativePixmapType */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = "eglCreateWindowSurface"u8)
                eglCreateWindowSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativeWindowType */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = "eglDestroyContext"u8)
                eglDestroyContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglDestroySurface"u8)
                eglDestroySurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglGetConfigAttrib"u8)
                eglGetConfigAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglGetConfigs"u8)
                eglGetConfigs = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglGetCurrentDisplay"u8)
                eglGetCurrentDisplay = (delegate* unmanaged</* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = "eglGetCurrentSurface"u8)
                eglGetCurrentSurface = (delegate* unmanaged</* EGLint */ int, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = "eglGetDisplay"u8)
                eglGetDisplay = (delegate* unmanaged</* EGLNativeDisplayType */ void*, /* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = "eglGetError"u8)
                eglGetError = (delegate* unmanaged</* EGLint */ int>)loadFunc(name);
            fixed(byte* name = "eglGetProcAddress"u8)
                eglGetProcAddress = (delegate* unmanaged</* char */ byte*, /* __eglMustCastToProperFunctionPointerType */ void*>)loadFunc(name);
            fixed(byte* name = "eglInitialize"u8)
                eglInitialize = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglMakeCurrent"u8)
                eglMakeCurrent = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLSurface */ void*, /* EGLContext */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglQueryContext"u8)
                eglQueryContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglQueryString"u8)
                eglQueryString = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* char */ byte*>)loadFunc(name);
            fixed(byte* name = "eglQuerySurface"u8)
                eglQuerySurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglSwapBuffers"u8)
                eglSwapBuffers = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglTerminate"u8)
                eglTerminate = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglWaitGL"u8)
                eglWaitGL = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglWaitNative"u8)
                eglWaitNative = (delegate* unmanaged</* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version11)
        {
            fixed(byte* name = "eglBindTexImage"u8)
                eglBindTexImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglReleaseTexImage"u8)
                eglReleaseTexImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglSurfaceAttrib"u8)
                eglSurfaceAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglSwapInterval"u8)
                eglSwapInterval = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version12)
        {
            fixed(byte* name = "eglBindAPI"u8)
                eglBindAPI = (delegate* unmanaged</* EGLenum */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglQueryAPI"u8)
                eglQueryAPI = (delegate* unmanaged</* EGLenum */ int>)loadFunc(name);
            fixed(byte* name = "eglCreatePbufferFromClientBuffer"u8)
                eglCreatePbufferFromClientBuffer = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = "eglReleaseThread"u8)
                eglReleaseThread = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglWaitClient"u8)
                eglWaitClient = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version13)
        {
        }
        
        if(Version14)
        {
            fixed(byte* name = "eglGetCurrentContext"u8)
                eglGetCurrentContext = (delegate* unmanaged</* EGLContext */ void*>)loadFunc(name);
        }
        
        if(Version15)
        {
            fixed(byte* name = "eglCreateSync"u8)
                eglCreateSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLAttrib */ nint*, /* EGLSync */ void*>)loadFunc(name);
            fixed(byte* name = "eglDestroySync"u8)
                eglDestroySync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglClientWaitSync"u8)
                eglClientWaitSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLTime */ ulong, /* EGLint */ int>)loadFunc(name);
            fixed(byte* name = "eglGetSyncAttrib"u8)
                eglGetSyncAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLAttrib */ nint*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglCreateImage"u8)
                eglCreateImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLAttrib */ nint*, /* EGLImage */ void*>)loadFunc(name);
            fixed(byte* name = "eglDestroyImage"u8)
                eglDestroyImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLImage */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = "eglGetPlatformDisplay"u8)
                eglGetPlatformDisplay = (delegate* unmanaged</* EGLenum */ int, /* void */ void*, /* EGLAttrib */ nint*, /* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = "eglCreatePlatformWindowSurface"u8)
                eglCreatePlatformWindowSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = "eglCreatePlatformPixmapSurface"u8)
                eglCreatePlatformPixmapSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = "eglWaitSync"u8)
                eglWaitSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
    }
}
