namespace Rena.Interop.OpenGL;

public unsafe partial class GLES1
{
    public /* void */ void AlphaFunc(/* GLenum */ int @func, /* GLfloat */ float @ref)
        => glAlphaFunc(@func, @ref);
    public /* void */ void ClearColor(/* GLfloat */ float @red, /* GLfloat */ float @green, /* GLfloat */ float @blue, /* GLfloat */ float @alpha)
        => glClearColor(@red, @green, @blue, @alpha);
    public /* void */ void ClearDepthf(/* GLfloat */ float @d)
        => glClearDepthf(@d);
    public /* void */ void ClipPlanef(/* GLenum */ int @p, /* GLfloat */ float* @eqn)
        => glClipPlanef(@p, @eqn);
    public /* void */ void Color4f(/* GLfloat */ float @red, /* GLfloat */ float @green, /* GLfloat */ float @blue, /* GLfloat */ float @alpha)
        => glColor4f(@red, @green, @blue, @alpha);
    public /* void */ void DepthRangef(/* GLfloat */ float @n, /* GLfloat */ float @f)
        => glDepthRangef(@n, @f);
    public /* void */ void Fogf(/* GLenum */ int @pname, /* GLfloat */ float @param)
        => glFogf(@pname, @param);
    public /* void */ void Fogfv(/* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glFogfv(@pname, @params);
    public /* void */ void Frustumf(/* GLfloat */ float @l, /* GLfloat */ float @r, /* GLfloat */ float @b, /* GLfloat */ float @t, /* GLfloat */ float @n, /* GLfloat */ float @f)
        => glFrustumf(@l, @r, @b, @t, @n, @f);
    public /* void */ void GetClipPlanef(/* GLenum */ int @plane, /* GLfloat */ float* @equation)
        => glGetClipPlanef(@plane, @equation);
    public /* void */ void GetFloatv(/* GLenum */ int @pname, /* GLfloat */ float* @data)
        => glGetFloatv(@pname, @data);
    public /* void */ void GetLightfv(/* GLenum */ int @light, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetLightfv(@light, @pname, @params);
    public /* void */ void GetMaterialfv(/* GLenum */ int @face, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetMaterialfv(@face, @pname, @params);
    public /* void */ void GetTexEnvfv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetTexEnvfv(@target, @pname, @params);
    public /* void */ void GetTexParameterfv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetTexParameterfv(@target, @pname, @params);
    public /* void */ void LightModelf(/* GLenum */ int @pname, /* GLfloat */ float @param)
        => glLightModelf(@pname, @param);
    public /* void */ void LightModelfv(/* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glLightModelfv(@pname, @params);
    public /* void */ void Lightf(/* GLenum */ int @light, /* GLenum */ int @pname, /* GLfloat */ float @param)
        => glLightf(@light, @pname, @param);
    public /* void */ void Lightfv(/* GLenum */ int @light, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glLightfv(@light, @pname, @params);
    public /* void */ void LineWidth(/* GLfloat */ float @width)
        => glLineWidth(@width);
    public /* void */ void LoadMatrixf(/* GLfloat */ float* @m)
        => glLoadMatrixf(@m);
    public /* void */ void Materialf(/* GLenum */ int @face, /* GLenum */ int @pname, /* GLfloat */ float @param)
        => glMaterialf(@face, @pname, @param);
    public /* void */ void Materialfv(/* GLenum */ int @face, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glMaterialfv(@face, @pname, @params);
    public /* void */ void MultMatrixf(/* GLfloat */ float* @m)
        => glMultMatrixf(@m);
    public /* void */ void MultiTexCoord4f(/* GLenum */ int @target, /* GLfloat */ float @s, /* GLfloat */ float @t, /* GLfloat */ float @r, /* GLfloat */ float @q)
        => glMultiTexCoord4f(@target, @s, @t, @r, @q);
    public /* void */ void Normal3f(/* GLfloat */ float @nx, /* GLfloat */ float @ny, /* GLfloat */ float @nz)
        => glNormal3f(@nx, @ny, @nz);
    public /* void */ void Orthof(/* GLfloat */ float @l, /* GLfloat */ float @r, /* GLfloat */ float @b, /* GLfloat */ float @t, /* GLfloat */ float @n, /* GLfloat */ float @f)
        => glOrthof(@l, @r, @b, @t, @n, @f);
    public /* void */ void PointParameterf(/* GLenum */ int @pname, /* GLfloat */ float @param)
        => glPointParameterf(@pname, @param);
    public /* void */ void PointParameterfv(/* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glPointParameterfv(@pname, @params);
    public /* void */ void PointSize(/* GLfloat */ float @size)
        => glPointSize(@size);
    public /* void */ void PolygonOffset(/* GLfloat */ float @factor, /* GLfloat */ float @units)
        => glPolygonOffset(@factor, @units);
    public /* void */ void Rotatef(/* GLfloat */ float @angle, /* GLfloat */ float @x, /* GLfloat */ float @y, /* GLfloat */ float @z)
        => glRotatef(@angle, @x, @y, @z);
    public /* void */ void Scalef(/* GLfloat */ float @x, /* GLfloat */ float @y, /* GLfloat */ float @z)
        => glScalef(@x, @y, @z);
    public /* void */ void TexEnvf(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfloat */ float @param)
        => glTexEnvf(@target, @pname, @param);
    public /* void */ void TexEnvfv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glTexEnvfv(@target, @pname, @params);
    public /* void */ void TexParameterf(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfloat */ float @param)
        => glTexParameterf(@target, @pname, @param);
    public /* void */ void TexParameterfv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glTexParameterfv(@target, @pname, @params);
    public /* void */ void Translatef(/* GLfloat */ float @x, /* GLfloat */ float @y, /* GLfloat */ float @z)
        => glTranslatef(@x, @y, @z);
    public /* void */ void ActiveTexture(/* GLenum */ int @texture)
        => glActiveTexture(@texture);
    public /* void */ void AlphaFuncx(/* GLenum */ int @func, /* GLfixed */ uint @ref)
        => glAlphaFuncx(@func, @ref);
    public /* void */ void BindBuffer(/* GLenum */ int @target, /* GLuint */ uint @buffer)
        => glBindBuffer(@target, @buffer);
    public /* void */ void BindTexture(/* GLenum */ int @target, /* GLuint */ uint @texture)
        => glBindTexture(@target, @texture);
    public /* void */ void BlendFunc(/* GLenum */ int @sfactor, /* GLenum */ int @dfactor)
        => glBlendFunc(@sfactor, @dfactor);
    public /* void */ void BufferData(/* GLenum */ int @target, /* GLsizeiptr */ nint @size, /* void */ void* @data, /* GLenum */ int @usage)
        => glBufferData(@target, @size, @data, @usage);
    public /* void */ void BufferSubData(/* GLenum */ int @target, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size, /* void */ void* @data)
        => glBufferSubData(@target, @offset, @size, @data);
    public /* void */ void Clear(/* GLbitfield */ int @mask)
        => glClear(@mask);
    public /* void */ void ClearColorx(/* GLfixed */ uint @red, /* GLfixed */ uint @green, /* GLfixed */ uint @blue, /* GLfixed */ uint @alpha)
        => glClearColorx(@red, @green, @blue, @alpha);
    public /* void */ void ClearDepthx(/* GLfixed */ uint @depth)
        => glClearDepthx(@depth);
    public /* void */ void ClearStencil(/* GLint */ int @s)
        => glClearStencil(@s);
    public /* void */ void ClientActiveTexture(/* GLenum */ int @texture)
        => glClientActiveTexture(@texture);
    public /* void */ void ClipPlanex(/* GLenum */ int @plane, /* GLfixed */ uint* @equation)
        => glClipPlanex(@plane, @equation);
    public /* void */ void Color4ub(/* GLubyte */ byte @red, /* GLubyte */ byte @green, /* GLubyte */ byte @blue, /* GLubyte */ byte @alpha)
        => glColor4ub(@red, @green, @blue, @alpha);
    public /* void */ void Color4x(/* GLfixed */ uint @red, /* GLfixed */ uint @green, /* GLfixed */ uint @blue, /* GLfixed */ uint @alpha)
        => glColor4x(@red, @green, @blue, @alpha);
    public /* void */ void ColorMask(/* GLboolean */ int @red, /* GLboolean */ int @green, /* GLboolean */ int @blue, /* GLboolean */ int @alpha)
        => glColorMask(@red, @green, @blue, @alpha);
    public /* void */ void ColorPointer(/* GLint */ int @size, /* GLenum */ int @type, /* GLsizei */ int @stride, /* void */ void* @pointer)
        => glColorPointer(@size, @type, @stride, @pointer);
    public /* void */ void CompressedTexImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLint */ int @border, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexImage2D(@target, @level, @internalformat, @width, @height, @border, @imageSize, @data);
    public /* void */ void CompressedTexSubImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexSubImage2D(@target, @level, @xoffset, @yoffset, @width, @height, @format, @imageSize, @data);
    public /* void */ void CopyTexImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLint */ int @border)
        => glCopyTexImage2D(@target, @level, @internalformat, @x, @y, @width, @height, @border);
    public /* void */ void CopyTexSubImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glCopyTexSubImage2D(@target, @level, @xoffset, @yoffset, @x, @y, @width, @height);
    public /* void */ void CullFace(/* GLenum */ int @mode)
        => glCullFace(@mode);
    public /* void */ void DeleteBuffers(/* GLsizei */ int @n, /* GLuint */ uint* @buffers)
        => glDeleteBuffers(@n, @buffers);
    public /* void */ void DeleteTextures(/* GLsizei */ int @n, /* GLuint */ uint* @textures)
        => glDeleteTextures(@n, @textures);
    public /* void */ void DepthFunc(/* GLenum */ int @func)
        => glDepthFunc(@func);
    public /* void */ void DepthMask(/* GLboolean */ int @flag)
        => glDepthMask(@flag);
    public /* void */ void DepthRangex(/* GLfixed */ uint @n, /* GLfixed */ uint @f)
        => glDepthRangex(@n, @f);
    public /* void */ void Disable(/* GLenum */ int @cap)
        => glDisable(@cap);
    public /* void */ void DisableClientState(/* GLenum */ int @array)
        => glDisableClientState(@array);
    public /* void */ void DrawArrays(/* GLenum */ int @mode, /* GLint */ int @first, /* GLsizei */ int @count)
        => glDrawArrays(@mode, @first, @count);
    public /* void */ void DrawElements(/* GLenum */ int @mode, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices)
        => glDrawElements(@mode, @count, @type, @indices);
    public /* void */ void Enable(/* GLenum */ int @cap)
        => glEnable(@cap);
    public /* void */ void EnableClientState(/* GLenum */ int @array)
        => glEnableClientState(@array);
    public /* void */ void Finish()
        => glFinish();
    public /* void */ void Flush()
        => glFlush();
    public /* void */ void Fogx(/* GLenum */ int @pname, /* GLfixed */ uint @param)
        => glFogx(@pname, @param);
    public /* void */ void Fogxv(/* GLenum */ int @pname, /* GLfixed */ uint* @param)
        => glFogxv(@pname, @param);
    public /* void */ void FrontFace(/* GLenum */ int @mode)
        => glFrontFace(@mode);
    public /* void */ void Frustumx(/* GLfixed */ uint @l, /* GLfixed */ uint @r, /* GLfixed */ uint @b, /* GLfixed */ uint @t, /* GLfixed */ uint @n, /* GLfixed */ uint @f)
        => glFrustumx(@l, @r, @b, @t, @n, @f);
    public /* void */ void GetBooleanv(/* GLenum */ int @pname, /* GLboolean */ int* @data)
        => glGetBooleanv(@pname, @data);
    public /* void */ void GetBufferParameteriv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetBufferParameteriv(@target, @pname, @params);
    public /* void */ void GetClipPlanex(/* GLenum */ int @plane, /* GLfixed */ uint* @equation)
        => glGetClipPlanex(@plane, @equation);
    public /* void */ void GenBuffers(/* GLsizei */ int @n, /* GLuint */ uint* @buffers)
        => glGenBuffers(@n, @buffers);
    public /* void */ void GenTextures(/* GLsizei */ int @n, /* GLuint */ uint* @textures)
        => glGenTextures(@n, @textures);
    public /* GLenum */ int GetError()
        => glGetError();
    public /* void */ void GetFixedv(/* GLenum */ int @pname, /* GLfixed */ uint* @params)
        => glGetFixedv(@pname, @params);
    public /* void */ void GetIntegerv(/* GLenum */ int @pname, /* GLint */ int* @data)
        => glGetIntegerv(@pname, @data);
    public /* void */ void GetLightxv(/* GLenum */ int @light, /* GLenum */ int @pname, /* GLfixed */ uint* @params)
        => glGetLightxv(@light, @pname, @params);
    public /* void */ void GetMaterialxv(/* GLenum */ int @face, /* GLenum */ int @pname, /* GLfixed */ uint* @params)
        => glGetMaterialxv(@face, @pname, @params);
    public /* void */ void GetPointerv(/* GLenum */ int @pname, /* void */ void** @params)
        => glGetPointerv(@pname, @params);
    public /* GLubyte */ byte* GetString(/* GLenum */ int @name)
        => glGetString(@name);
    public /* void */ void GetTexEnviv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetTexEnviv(@target, @pname, @params);
    public /* void */ void GetTexEnvxv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfixed */ uint* @params)
        => glGetTexEnvxv(@target, @pname, @params);
    public /* void */ void GetTexParameteriv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetTexParameteriv(@target, @pname, @params);
    public /* void */ void GetTexParameterxv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfixed */ uint* @params)
        => glGetTexParameterxv(@target, @pname, @params);
    public /* void */ void Hint(/* GLenum */ int @target, /* GLenum */ int @mode)
        => glHint(@target, @mode);
    public /* GLboolean */ int IsBuffer(/* GLuint */ uint @buffer)
        => glIsBuffer(@buffer);
    public /* GLboolean */ int IsEnabled(/* GLenum */ int @cap)
        => glIsEnabled(@cap);
    public /* GLboolean */ int IsTexture(/* GLuint */ uint @texture)
        => glIsTexture(@texture);
    public /* void */ void LightModelx(/* GLenum */ int @pname, /* GLfixed */ uint @param)
        => glLightModelx(@pname, @param);
    public /* void */ void LightModelxv(/* GLenum */ int @pname, /* GLfixed */ uint* @param)
        => glLightModelxv(@pname, @param);
    public /* void */ void Lightx(/* GLenum */ int @light, /* GLenum */ int @pname, /* GLfixed */ uint @param)
        => glLightx(@light, @pname, @param);
    public /* void */ void Lightxv(/* GLenum */ int @light, /* GLenum */ int @pname, /* GLfixed */ uint* @params)
        => glLightxv(@light, @pname, @params);
    public /* void */ void LineWidthx(/* GLfixed */ uint @width)
        => glLineWidthx(@width);
    public /* void */ void LoadIdentity()
        => glLoadIdentity();
    public /* void */ void LoadMatrixx(/* GLfixed */ uint* @m)
        => glLoadMatrixx(@m);
    public /* void */ void LogicOp(/* GLenum */ int @opcode)
        => glLogicOp(@opcode);
    public /* void */ void Materialx(/* GLenum */ int @face, /* GLenum */ int @pname, /* GLfixed */ uint @param)
        => glMaterialx(@face, @pname, @param);
    public /* void */ void Materialxv(/* GLenum */ int @face, /* GLenum */ int @pname, /* GLfixed */ uint* @param)
        => glMaterialxv(@face, @pname, @param);
    public /* void */ void MatrixMode(/* GLenum */ int @mode)
        => glMatrixMode(@mode);
    public /* void */ void MultMatrixx(/* GLfixed */ uint* @m)
        => glMultMatrixx(@m);
    public /* void */ void MultiTexCoord4x(/* GLenum */ int @texture, /* GLfixed */ uint @s, /* GLfixed */ uint @t, /* GLfixed */ uint @r, /* GLfixed */ uint @q)
        => glMultiTexCoord4x(@texture, @s, @t, @r, @q);
    public /* void */ void Normal3x(/* GLfixed */ uint @nx, /* GLfixed */ uint @ny, /* GLfixed */ uint @nz)
        => glNormal3x(@nx, @ny, @nz);
    public /* void */ void NormalPointer(/* GLenum */ int @type, /* GLsizei */ int @stride, /* void */ void* @pointer)
        => glNormalPointer(@type, @stride, @pointer);
    public /* void */ void Orthox(/* GLfixed */ uint @l, /* GLfixed */ uint @r, /* GLfixed */ uint @b, /* GLfixed */ uint @t, /* GLfixed */ uint @n, /* GLfixed */ uint @f)
        => glOrthox(@l, @r, @b, @t, @n, @f);
    public /* void */ void PixelStorei(/* GLenum */ int @pname, /* GLint */ int @param)
        => glPixelStorei(@pname, @param);
    public /* void */ void PointParameterx(/* GLenum */ int @pname, /* GLfixed */ uint @param)
        => glPointParameterx(@pname, @param);
    public /* void */ void PointParameterxv(/* GLenum */ int @pname, /* GLfixed */ uint* @params)
        => glPointParameterxv(@pname, @params);
    public /* void */ void PointSizex(/* GLfixed */ uint @size)
        => glPointSizex(@size);
    public /* void */ void PolygonOffsetx(/* GLfixed */ uint @factor, /* GLfixed */ uint @units)
        => glPolygonOffsetx(@factor, @units);
    public /* void */ void PopMatrix()
        => glPopMatrix();
    public /* void */ void PushMatrix()
        => glPushMatrix();
    public /* void */ void ReadPixels(/* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glReadPixels(@x, @y, @width, @height, @format, @type, @pixels);
    public /* void */ void Rotatex(/* GLfixed */ uint @angle, /* GLfixed */ uint @x, /* GLfixed */ uint @y, /* GLfixed */ uint @z)
        => glRotatex(@angle, @x, @y, @z);
    public /* void */ void SampleCoverage(/* GLfloat */ float @value, /* GLboolean */ int @invert)
        => glSampleCoverage(@value, @invert);
    public /* void */ void SampleCoveragex(/* GLclampx */ int @value, /* GLboolean */ int @invert)
        => glSampleCoveragex(@value, @invert);
    public /* void */ void Scalex(/* GLfixed */ uint @x, /* GLfixed */ uint @y, /* GLfixed */ uint @z)
        => glScalex(@x, @y, @z);
    public /* void */ void Scissor(/* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glScissor(@x, @y, @width, @height);
    public /* void */ void ShadeModel(/* GLenum */ int @mode)
        => glShadeModel(@mode);
    public /* void */ void StencilFunc(/* GLenum */ int @func, /* GLint */ int @ref, /* GLuint */ uint @mask)
        => glStencilFunc(@func, @ref, @mask);
    public /* void */ void StencilMask(/* GLuint */ uint @mask)
        => glStencilMask(@mask);
    public /* void */ void StencilOp(/* GLenum */ int @fail, /* GLenum */ int @zfail, /* GLenum */ int @zpass)
        => glStencilOp(@fail, @zfail, @zpass);
    public /* void */ void TexCoordPointer(/* GLint */ int @size, /* GLenum */ int @type, /* GLsizei */ int @stride, /* void */ void* @pointer)
        => glTexCoordPointer(@size, @type, @stride, @pointer);
    public /* void */ void TexEnvi(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int @param)
        => glTexEnvi(@target, @pname, @param);
    public /* void */ void TexEnvx(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfixed */ uint @param)
        => glTexEnvx(@target, @pname, @param);
    public /* void */ void TexEnviv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glTexEnviv(@target, @pname, @params);
    public /* void */ void TexEnvxv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfixed */ uint* @params)
        => glTexEnvxv(@target, @pname, @params);
    public /* void */ void TexImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLint */ int @border, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexImage2D(@target, @level, @internalformat, @width, @height, @border, @format, @type, @pixels);
    public /* void */ void TexParameteri(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int @param)
        => glTexParameteri(@target, @pname, @param);
    public /* void */ void TexParameterx(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfixed */ uint @param)
        => glTexParameterx(@target, @pname, @param);
    public /* void */ void TexParameteriv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glTexParameteriv(@target, @pname, @params);
    public /* void */ void TexParameterxv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfixed */ uint* @params)
        => glTexParameterxv(@target, @pname, @params);
    public /* void */ void TexSubImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexSubImage2D(@target, @level, @xoffset, @yoffset, @width, @height, @format, @type, @pixels);
    public /* void */ void Translatex(/* GLfixed */ uint @x, /* GLfixed */ uint @y, /* GLfixed */ uint @z)
        => glTranslatex(@x, @y, @z);
    public /* void */ void VertexPointer(/* GLint */ int @size, /* GLenum */ int @type, /* GLsizei */ int @stride, /* void */ void* @pointer)
        => glVertexPointer(@size, @type, @stride, @pointer);
    public /* void */ void Viewport(/* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glViewport(@x, @y, @width, @height);
}
