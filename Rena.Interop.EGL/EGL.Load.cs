using System.Buffers;
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
    
    public EGL(LoadFunction loadFunc)
    {
        delegate* unmanaged<void*, int, byte*> eglQueryString;
        fixed(byte* name = eglQueryStringFunctionName)
            eglQueryString = (delegate* unmanaged<void*, int, byte*>)loadFunc(name);
        delegate* unmanaged<int> eglGetError;
        fixed(byte* name = eglGetErrorFunctionName)
            eglGetError = (delegate* unmanaged<int>)loadFunc(name);
        if(eglQueryString is null || eglGetError is null) return;
        
        Version10 = Major > 1 || (Major == 1 && Minor >= 0);
        Version11 = Major > 1 || (Major == 1 && Minor >= 1);
        Version12 = Major > 1 || (Major == 1 && Minor >= 2);
        Version13 = Major > 1 || (Major == 1 && Minor >= 3);
        Version14 = Major > 1 || (Major == 1 && Minor >= 4);
        Version15 = Major > 1 || (Major == 1 && Minor >= 5);
        
        if(Version10)
        {
            fixed(byte* name = eglChooseConfigFunctionName)
                this.eglChooseConfig = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglCopyBuffersFunctionName)
                this.eglCopyBuffers = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLNativePixmapType */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglCreateContextFunctionName)
                this.eglCreateContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLContext */ void*, /* EGLint */ int*, /* EGLContext */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePbufferSurfaceFunctionName)
                this.eglCreatePbufferSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePixmapSurfaceFunctionName)
                this.eglCreatePixmapSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativePixmapType */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglCreateWindowSurfaceFunctionName)
                this.eglCreateWindowSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativeWindowType */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglDestroyContextFunctionName)
                this.eglDestroyContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglDestroySurfaceFunctionName)
                this.eglDestroySurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetConfigAttribFunctionName)
                this.eglGetConfigAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetConfigsFunctionName)
                this.eglGetConfigs = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetCurrentDisplayFunctionName)
                this.eglGetCurrentDisplay = (delegate* unmanaged</* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = eglGetCurrentSurfaceFunctionName)
                this.eglGetCurrentSurface = (delegate* unmanaged</* EGLint */ int, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglGetDisplayFunctionName)
                this.eglGetDisplay = (delegate* unmanaged</* EGLNativeDisplayType */ void*, /* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = eglGetErrorFunctionName)
                this.eglGetError = (delegate* unmanaged</* EGLint */ int>)loadFunc(name);
            fixed(byte* name = eglGetProcAddressFunctionName)
                this.eglGetProcAddress = (delegate* unmanaged</* char */ byte*, /* __eglMustCastToProperFunctionPointerType */ void*>)loadFunc(name);
            fixed(byte* name = eglInitializeFunctionName)
                this.eglInitialize = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglMakeCurrentFunctionName)
                this.eglMakeCurrent = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLSurface */ void*, /* EGLContext */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglQueryContextFunctionName)
                this.eglQueryContext = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglQueryStringFunctionName)
                this.eglQueryString = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* char */ byte*>)loadFunc(name);
            fixed(byte* name = eglQuerySurfaceFunctionName)
                this.eglQuerySurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglSwapBuffersFunctionName)
                this.eglSwapBuffers = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglTerminateFunctionName)
                this.eglTerminate = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglWaitGLFunctionName)
                this.eglWaitGL = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglWaitNativeFunctionName)
                this.eglWaitNative = (delegate* unmanaged</* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version11)
        {
            fixed(byte* name = eglBindTexImageFunctionName)
                this.eglBindTexImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglReleaseTexImageFunctionName)
                this.eglReleaseTexImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglSurfaceAttribFunctionName)
                this.eglSurfaceAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglSwapIntervalFunctionName)
                this.eglSwapInterval = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version12)
        {
            fixed(byte* name = eglBindAPIFunctionName)
                this.eglBindAPI = (delegate* unmanaged</* EGLenum */ int, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglQueryAPIFunctionName)
                this.eglQueryAPI = (delegate* unmanaged</* EGLenum */ int>)loadFunc(name);
            fixed(byte* name = eglCreatePbufferFromClientBufferFunctionName)
                this.eglCreatePbufferFromClientBuffer = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglReleaseThreadFunctionName)
                this.eglReleaseThread = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglWaitClientFunctionName)
                this.eglWaitClient = (delegate* unmanaged</* EGLBoolean */ int>)loadFunc(name);
        }
        
        if(Version13)
        {
        }
        
        if(Version14)
        {
            fixed(byte* name = eglGetCurrentContextFunctionName)
                this.eglGetCurrentContext = (delegate* unmanaged</* EGLContext */ void*>)loadFunc(name);
        }
        
        if(Version15)
        {
            fixed(byte* name = eglCreateSyncFunctionName)
                this.eglCreateSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLAttrib */ nint*, /* EGLSync */ void*>)loadFunc(name);
            fixed(byte* name = eglDestroySyncFunctionName)
                this.eglDestroySync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglClientWaitSyncFunctionName)
                this.eglClientWaitSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLTime */ ulong, /* EGLint */ int>)loadFunc(name);
            fixed(byte* name = eglGetSyncAttribFunctionName)
                this.eglGetSyncAttrib = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLAttrib */ nint*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglCreateImageFunctionName)
                this.eglCreateImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLAttrib */ nint*, /* EGLImage */ void*>)loadFunc(name);
            fixed(byte* name = eglDestroyImageFunctionName)
                this.eglDestroyImage = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLImage */ void*, /* EGLBoolean */ int>)loadFunc(name);
            fixed(byte* name = eglGetPlatformDisplayFunctionName)
                this.eglGetPlatformDisplay = (delegate* unmanaged</* EGLenum */ int, /* void */ void*, /* EGLAttrib */ nint*, /* EGLDisplay */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePlatformWindowSurfaceFunctionName)
                this.eglCreatePlatformWindowSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglCreatePlatformPixmapSurfaceFunctionName)
                this.eglCreatePlatformPixmapSurface = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*>)loadFunc(name);
            fixed(byte* name = eglWaitSyncFunctionName)
                this.eglWaitSync = (delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLBoolean */ int>)loadFunc(name);
        }
    }
}
