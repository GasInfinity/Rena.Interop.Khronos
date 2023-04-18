namespace Rena.Interop.EGL;

public unsafe partial class EGL
{
    public /* EGLBoolean */ int ChooseConfig(/* EGLDisplay */ void* @dpy, /* EGLint */ int* @attrib_list, /* EGLConfig */ void** @configs, /* EGLint */ int @config_size, /* EGLint */ int* @num_config)
        => eglChooseConfig(@dpy, @attrib_list, @configs, @config_size, @num_config);
    public /* EGLBoolean */ int CopyBuffers(/* EGLDisplay */ void* @dpy, /* EGLSurface */ void* @surface, /* EGLNativePixmapType */ void* @target)
        => eglCopyBuffers(@dpy, @surface, @target);
    public /* EGLContext */ void* CreateContext(/* EGLDisplay */ void* @dpy, /* EGLConfig */ void* @config, /* EGLContext */ void* @share_context, /* EGLint */ int* @attrib_list)
        => eglCreateContext(@dpy, @config, @share_context, @attrib_list);
    public /* EGLSurface */ void* CreatePbufferSurface(/* EGLDisplay */ void* @dpy, /* EGLConfig */ void* @config, /* EGLint */ int* @attrib_list)
        => eglCreatePbufferSurface(@dpy, @config, @attrib_list);
    public /* EGLSurface */ void* CreatePixmapSurface(/* EGLDisplay */ void* @dpy, /* EGLConfig */ void* @config, /* EGLNativePixmapType */ void* @pixmap, /* EGLint */ int* @attrib_list)
        => eglCreatePixmapSurface(@dpy, @config, @pixmap, @attrib_list);
    public /* EGLSurface */ void* CreateWindowSurface(/* EGLDisplay */ void* @dpy, /* EGLConfig */ void* @config, /* EGLNativeWindowType */ void* @win, /* EGLint */ int* @attrib_list)
        => eglCreateWindowSurface(@dpy, @config, @win, @attrib_list);
    public /* EGLBoolean */ int DestroyContext(/* EGLDisplay */ void* @dpy, /* EGLContext */ void* @ctx)
        => eglDestroyContext(@dpy, @ctx);
    public /* EGLBoolean */ int DestroySurface(/* EGLDisplay */ void* @dpy, /* EGLSurface */ void* @surface)
        => eglDestroySurface(@dpy, @surface);
    public /* EGLBoolean */ int GetConfigAttrib(/* EGLDisplay */ void* @dpy, /* EGLConfig */ void* @config, /* EGLint */ int @attribute, /* EGLint */ int* @value)
        => eglGetConfigAttrib(@dpy, @config, @attribute, @value);
    public /* EGLBoolean */ int GetConfigs(/* EGLDisplay */ void* @dpy, /* EGLConfig */ void** @configs, /* EGLint */ int @config_size, /* EGLint */ int* @num_config)
        => eglGetConfigs(@dpy, @configs, @config_size, @num_config);
    public /* EGLDisplay */ void* GetCurrentDisplay()
        => eglGetCurrentDisplay();
    public /* EGLSurface */ void* GetCurrentSurface(/* EGLint */ int @readdraw)
        => eglGetCurrentSurface(@readdraw);
    public /* EGLDisplay */ void* GetDisplay(/* EGLNativeDisplayType */ void* @display_id)
        => eglGetDisplay(@display_id);
    public /* EGLint */ int GetError()
        => eglGetError();
    public /* __eglMustCastToProperFunctionPointerType */ void* GetProcAddress(/* char */ byte* @procname)
        => eglGetProcAddress(@procname);
    public /* EGLBoolean */ int Initialize(/* EGLDisplay */ void* @dpy, /* EGLint */ int* @major, /* EGLint */ int* @minor)
        => eglInitialize(@dpy, @major, @minor);
    public /* EGLBoolean */ int MakeCurrent(/* EGLDisplay */ void* @dpy, /* EGLSurface */ void* @draw, /* EGLSurface */ void* @read, /* EGLContext */ void* @ctx)
        => eglMakeCurrent(@dpy, @draw, @read, @ctx);
    public /* EGLBoolean */ int QueryContext(/* EGLDisplay */ void* @dpy, /* EGLContext */ void* @ctx, /* EGLint */ int @attribute, /* EGLint */ int* @value)
        => eglQueryContext(@dpy, @ctx, @attribute, @value);
    public /* char */ byte* QueryString(/* EGLDisplay */ void* @dpy, /* EGLint */ int @name)
        => eglQueryString(@dpy, @name);
    public /* EGLBoolean */ int QuerySurface(/* EGLDisplay */ void* @dpy, /* EGLSurface */ void* @surface, /* EGLint */ int @attribute, /* EGLint */ int* @value)
        => eglQuerySurface(@dpy, @surface, @attribute, @value);
    public /* EGLBoolean */ int SwapBuffers(/* EGLDisplay */ void* @dpy, /* EGLSurface */ void* @surface)
        => eglSwapBuffers(@dpy, @surface);
    public /* EGLBoolean */ int Terminate(/* EGLDisplay */ void* @dpy)
        => eglTerminate(@dpy);
    public /* EGLBoolean */ int WaitGL()
        => eglWaitGL();
    public /* EGLBoolean */ int WaitNative(/* EGLint */ int @engine)
        => eglWaitNative(@engine);
    public /* EGLBoolean */ int BindTexImage(/* EGLDisplay */ void* @dpy, /* EGLSurface */ void* @surface, /* EGLint */ int @buffer)
        => eglBindTexImage(@dpy, @surface, @buffer);
    public /* EGLBoolean */ int ReleaseTexImage(/* EGLDisplay */ void* @dpy, /* EGLSurface */ void* @surface, /* EGLint */ int @buffer)
        => eglReleaseTexImage(@dpy, @surface, @buffer);
    public /* EGLBoolean */ int SurfaceAttrib(/* EGLDisplay */ void* @dpy, /* EGLSurface */ void* @surface, /* EGLint */ int @attribute, /* EGLint */ int @value)
        => eglSurfaceAttrib(@dpy, @surface, @attribute, @value);
    public /* EGLBoolean */ int SwapInterval(/* EGLDisplay */ void* @dpy, /* EGLint */ int @interval)
        => eglSwapInterval(@dpy, @interval);
    public /* EGLBoolean */ int BindAPI(/* EGLenum */ int @api)
        => eglBindAPI(@api);
    public /* EGLenum */ int QueryAPI()
        => eglQueryAPI();
    public /* EGLSurface */ void* CreatePbufferFromClientBuffer(/* EGLDisplay */ void* @dpy, /* EGLenum */ int @buftype, /* EGLClientBuffer */ void* @buffer, /* EGLConfig */ void* @config, /* EGLint */ int* @attrib_list)
        => eglCreatePbufferFromClientBuffer(@dpy, @buftype, @buffer, @config, @attrib_list);
    public /* EGLBoolean */ int ReleaseThread()
        => eglReleaseThread();
    public /* EGLBoolean */ int WaitClient()
        => eglWaitClient();
    public /* EGLContext */ void* GetCurrentContext()
        => eglGetCurrentContext();
    public /* EGLSync */ void* CreateSync(/* EGLDisplay */ void* @dpy, /* EGLenum */ int @type, /* EGLAttrib */ nint* @attrib_list)
        => eglCreateSync(@dpy, @type, @attrib_list);
    public /* EGLBoolean */ int DestroySync(/* EGLDisplay */ void* @dpy, /* EGLSync */ void* @sync)
        => eglDestroySync(@dpy, @sync);
    public /* EGLint */ int ClientWaitSync(/* EGLDisplay */ void* @dpy, /* EGLSync */ void* @sync, /* EGLint */ int @flags, /* EGLTime */ ulong @timeout)
        => eglClientWaitSync(@dpy, @sync, @flags, @timeout);
    public /* EGLBoolean */ int GetSyncAttrib(/* EGLDisplay */ void* @dpy, /* EGLSync */ void* @sync, /* EGLint */ int @attribute, /* EGLAttrib */ nint* @value)
        => eglGetSyncAttrib(@dpy, @sync, @attribute, @value);
    public /* EGLImage */ void* CreateImage(/* EGLDisplay */ void* @dpy, /* EGLContext */ void* @ctx, /* EGLenum */ int @target, /* EGLClientBuffer */ void* @buffer, /* EGLAttrib */ nint* @attrib_list)
        => eglCreateImage(@dpy, @ctx, @target, @buffer, @attrib_list);
    public /* EGLBoolean */ int DestroyImage(/* EGLDisplay */ void* @dpy, /* EGLImage */ void* @image)
        => eglDestroyImage(@dpy, @image);
    public /* EGLDisplay */ void* GetPlatformDisplay(/* EGLenum */ int @platform, /* void */ void* @native_display, /* EGLAttrib */ nint* @attrib_list)
        => eglGetPlatformDisplay(@platform, @native_display, @attrib_list);
    public /* EGLSurface */ void* CreatePlatformWindowSurface(/* EGLDisplay */ void* @dpy, /* EGLConfig */ void* @config, /* void */ void* @native_window, /* EGLAttrib */ nint* @attrib_list)
        => eglCreatePlatformWindowSurface(@dpy, @config, @native_window, @attrib_list);
    public /* EGLSurface */ void* CreatePlatformPixmapSurface(/* EGLDisplay */ void* @dpy, /* EGLConfig */ void* @config, /* void */ void* @native_pixmap, /* EGLAttrib */ nint* @attrib_list)
        => eglCreatePlatformPixmapSurface(@dpy, @config, @native_pixmap, @attrib_list);
    public /* EGLBoolean */ int WaitSync(/* EGLDisplay */ void* @dpy, /* EGLSync */ void* @sync, /* EGLint */ int @flags)
        => eglWaitSync(@dpy, @sync, @flags);
}
