namespace Rena.Interop.Egl;

public unsafe partial class Egl
{
    private readonly delegate* unmanaged</* EGLenum */ int, /* EGLBoolean */ int> eglBindAPI;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int> eglBindTexImage;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int> eglChooseConfig;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLTime */ ulong, /* EGLint */ int> eglClientWaitSync;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLNativePixmapType */ void*, /* EGLBoolean */ int> eglCopyBuffers;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLContext */ void*, /* EGLint */ int*, /* EGLContext */ void*> eglCreateContext;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLAttrib */ nint*, /* EGLImage */ void*> eglCreateImage;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLClientBuffer */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*> eglCreatePbufferFromClientBuffer;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int*, /* EGLSurface */ void*> eglCreatePbufferSurface;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativePixmapType */ void*, /* EGLint */ int*, /* EGLSurface */ void*> eglCreatePixmapSurface;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*> eglCreatePlatformPixmapSurface;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* void */ void*, /* EGLAttrib */ nint*, /* EGLSurface */ void*> eglCreatePlatformWindowSurface;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLenum */ int, /* EGLAttrib */ nint*, /* EGLSync */ void*> eglCreateSync;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLNativeWindowType */ void*, /* EGLint */ int*, /* EGLSurface */ void*> eglCreateWindowSurface;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLBoolean */ int> eglDestroyContext;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLImage */ void*, /* EGLBoolean */ int> eglDestroyImage;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int> eglDestroySurface;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLBoolean */ int> eglDestroySync;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int> eglGetConfigAttrib;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLConfig */ void**, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int> eglGetConfigs;
    private readonly delegate* unmanaged</* EGLContext */ void*> eglGetCurrentContext;
    private readonly delegate* unmanaged</* EGLDisplay */ void*> eglGetCurrentDisplay;
    private readonly delegate* unmanaged</* EGLint */ int, /* EGLSurface */ void*> eglGetCurrentSurface;
    private readonly delegate* unmanaged</* EGLNativeDisplayType */ void*, /* EGLDisplay */ void*> eglGetDisplay;
    private readonly delegate* unmanaged</* EGLint */ int> eglGetError;
    private readonly delegate* unmanaged</* EGLenum */ int, /* void */ void*, /* EGLAttrib */ nint*, /* EGLDisplay */ void*> eglGetPlatformDisplay;
    private readonly delegate* unmanaged</* char */ byte*, /* __eglMustCastToProperFunctionPointerType */ void*> eglGetProcAddress;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLAttrib */ nint*, /* EGLBoolean */ int> eglGetSyncAttrib;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int*, /* EGLint */ int*, /* EGLBoolean */ int> eglInitialize;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLSurface */ void*, /* EGLContext */ void*, /* EGLBoolean */ int> eglMakeCurrent;
    private readonly delegate* unmanaged</* EGLenum */ int> eglQueryAPI;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLContext */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int> eglQueryContext;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* char */ byte*> eglQueryString;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int*, /* EGLBoolean */ int> eglQuerySurface;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLBoolean */ int> eglReleaseTexImage;
    private readonly delegate* unmanaged</* EGLBoolean */ int> eglReleaseThread;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLint */ int, /* EGLint */ int, /* EGLBoolean */ int> eglSurfaceAttrib;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSurface */ void*, /* EGLBoolean */ int> eglSwapBuffers;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLint */ int, /* EGLBoolean */ int> eglSwapInterval;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLBoolean */ int> eglTerminate;
    private readonly delegate* unmanaged</* EGLBoolean */ int> eglWaitClient;
    private readonly delegate* unmanaged</* EGLBoolean */ int> eglWaitGL;
    private readonly delegate* unmanaged</* EGLint */ int, /* EGLBoolean */ int> eglWaitNative;
    private readonly delegate* unmanaged</* EGLDisplay */ void*, /* EGLSync */ void*, /* EGLint */ int, /* EGLBoolean */ int> eglWaitSync;
}
