namespace Rena.Interop.OpenGl;

public unsafe partial class Gl
{
    public /* void */ void ActiveShaderProgram(/* GLuint */ uint @pipeline, /* GLuint */ uint @program)
        => glActiveShaderProgram(@pipeline, @program);
    public /* void */ void ActiveTexture(/* GLenum */ int @texture)
        => glActiveTexture(@texture);
    public /* void */ void AttachShader(/* GLuint */ uint @program, /* GLuint */ uint @shader)
        => glAttachShader(@program, @shader);
    public /* void */ void BeginConditionalRender(/* GLuint */ uint @id, /* GLenum */ int @mode)
        => glBeginConditionalRender(@id, @mode);
    public /* void */ void BeginQuery(/* GLenum */ int @target, /* GLuint */ uint @id)
        => glBeginQuery(@target, @id);
    public /* void */ void BeginQueryIndexed(/* GLenum */ int @target, /* GLuint */ uint @index, /* GLuint */ uint @id)
        => glBeginQueryIndexed(@target, @index, @id);
    public /* void */ void BeginTransformFeedback(/* GLenum */ int @primitiveMode)
        => glBeginTransformFeedback(@primitiveMode);
    public /* void */ void BindAttribLocation(/* GLuint */ uint @program, /* GLuint */ uint @index, /* GLchar */ byte* @name)
        => glBindAttribLocation(@program, @index, @name);
    public /* void */ void BindBuffer(/* GLenum */ int @target, /* GLuint */ uint @buffer)
        => glBindBuffer(@target, @buffer);
    public /* void */ void BindBufferBase(/* GLenum */ int @target, /* GLuint */ uint @index, /* GLuint */ uint @buffer)
        => glBindBufferBase(@target, @index, @buffer);
    public /* void */ void BindBufferRange(/* GLenum */ int @target, /* GLuint */ uint @index, /* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size)
        => glBindBufferRange(@target, @index, @buffer, @offset, @size);
    public /* void */ void BindBuffersBase(/* GLenum */ int @target, /* GLuint */ uint @first, /* GLsizei */ int @count, /* GLuint */ uint* @buffers)
        => glBindBuffersBase(@target, @first, @count, @buffers);
    public /* void */ void BindBuffersRange(/* GLenum */ int @target, /* GLuint */ uint @first, /* GLsizei */ int @count, /* GLuint */ uint* @buffers, /* GLintptr */ nint* @offsets, /* GLsizeiptr */ nint* @sizes)
        => glBindBuffersRange(@target, @first, @count, @buffers, @offsets, @sizes);
    public /* void */ void BindFragDataLocation(/* GLuint */ uint @program, /* GLuint */ uint @color, /* GLchar */ byte* @name)
        => glBindFragDataLocation(@program, @color, @name);
    public /* void */ void BindFragDataLocationIndexed(/* GLuint */ uint @program, /* GLuint */ uint @colorNumber, /* GLuint */ uint @index, /* GLchar */ byte* @name)
        => glBindFragDataLocationIndexed(@program, @colorNumber, @index, @name);
    public /* void */ void BindFramebuffer(/* GLenum */ int @target, /* GLuint */ uint @framebuffer)
        => glBindFramebuffer(@target, @framebuffer);
    public /* void */ void BindImageTexture(/* GLuint */ uint @unit, /* GLuint */ uint @texture, /* GLint */ int @level, /* GLboolean */ int @layered, /* GLint */ int @layer, /* GLenum */ int @access, /* GLenum */ int @format)
        => glBindImageTexture(@unit, @texture, @level, @layered, @layer, @access, @format);
    public /* void */ void BindImageTextures(/* GLuint */ uint @first, /* GLsizei */ int @count, /* GLuint */ uint* @textures)
        => glBindImageTextures(@first, @count, @textures);
    public /* void */ void BindProgramPipeline(/* GLuint */ uint @pipeline)
        => glBindProgramPipeline(@pipeline);
    public /* void */ void BindRenderbuffer(/* GLenum */ int @target, /* GLuint */ uint @renderbuffer)
        => glBindRenderbuffer(@target, @renderbuffer);
    public /* void */ void BindSampler(/* GLuint */ uint @unit, /* GLuint */ uint @sampler)
        => glBindSampler(@unit, @sampler);
    public /* void */ void BindSamplers(/* GLuint */ uint @first, /* GLsizei */ int @count, /* GLuint */ uint* @samplers)
        => glBindSamplers(@first, @count, @samplers);
    public /* void */ void BindTexture(/* GLenum */ int @target, /* GLuint */ uint @texture)
        => glBindTexture(@target, @texture);
    public /* void */ void BindTextureUnit(/* GLuint */ uint @unit, /* GLuint */ uint @texture)
        => glBindTextureUnit(@unit, @texture);
    public /* void */ void BindTextures(/* GLuint */ uint @first, /* GLsizei */ int @count, /* GLuint */ uint* @textures)
        => glBindTextures(@first, @count, @textures);
    public /* void */ void BindTransformFeedback(/* GLenum */ int @target, /* GLuint */ uint @id)
        => glBindTransformFeedback(@target, @id);
    public /* void */ void BindVertexArray(/* GLuint */ uint @array)
        => glBindVertexArray(@array);
    public /* void */ void BindVertexBuffer(/* GLuint */ uint @bindingindex, /* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizei */ int @stride)
        => glBindVertexBuffer(@bindingindex, @buffer, @offset, @stride);
    public /* void */ void BindVertexBuffers(/* GLuint */ uint @first, /* GLsizei */ int @count, /* GLuint */ uint* @buffers, /* GLintptr */ nint* @offsets, /* GLsizei */ int* @strides)
        => glBindVertexBuffers(@first, @count, @buffers, @offsets, @strides);
    public /* void */ void BlendColor(/* GLfloat */ float @red, /* GLfloat */ float @green, /* GLfloat */ float @blue, /* GLfloat */ float @alpha)
        => glBlendColor(@red, @green, @blue, @alpha);
    public /* void */ void BlendEquation(/* GLenum */ int @mode)
        => glBlendEquation(@mode);
    public /* void */ void BlendEquationSeparate(/* GLenum */ int @modeRGB, /* GLenum */ int @modeAlpha)
        => glBlendEquationSeparate(@modeRGB, @modeAlpha);
    public /* void */ void BlendEquationSeparatei(/* GLuint */ uint @buf, /* GLenum */ int @modeRGB, /* GLenum */ int @modeAlpha)
        => glBlendEquationSeparatei(@buf, @modeRGB, @modeAlpha);
    public /* void */ void BlendEquationi(/* GLuint */ uint @buf, /* GLenum */ int @mode)
        => glBlendEquationi(@buf, @mode);
    public /* void */ void BlendFunc(/* GLenum */ int @sfactor, /* GLenum */ int @dfactor)
        => glBlendFunc(@sfactor, @dfactor);
    public /* void */ void BlendFuncSeparate(/* GLenum */ int @sfactorRGB, /* GLenum */ int @dfactorRGB, /* GLenum */ int @sfactorAlpha, /* GLenum */ int @dfactorAlpha)
        => glBlendFuncSeparate(@sfactorRGB, @dfactorRGB, @sfactorAlpha, @dfactorAlpha);
    public /* void */ void BlendFuncSeparatei(/* GLuint */ uint @buf, /* GLenum */ int @srcRGB, /* GLenum */ int @dstRGB, /* GLenum */ int @srcAlpha, /* GLenum */ int @dstAlpha)
        => glBlendFuncSeparatei(@buf, @srcRGB, @dstRGB, @srcAlpha, @dstAlpha);
    public /* void */ void BlendFunci(/* GLuint */ uint @buf, /* GLenum */ int @src, /* GLenum */ int @dst)
        => glBlendFunci(@buf, @src, @dst);
    public /* void */ void BlitFramebuffer(/* GLint */ int @srcX0, /* GLint */ int @srcY0, /* GLint */ int @srcX1, /* GLint */ int @srcY1, /* GLint */ int @dstX0, /* GLint */ int @dstY0, /* GLint */ int @dstX1, /* GLint */ int @dstY1, /* GLbitfield */ int @mask, /* GLenum */ int @filter)
        => glBlitFramebuffer(@srcX0, @srcY0, @srcX1, @srcY1, @dstX0, @dstY0, @dstX1, @dstY1, @mask, @filter);
    public /* void */ void BlitNamedFramebuffer(/* GLuint */ uint @readFramebuffer, /* GLuint */ uint @drawFramebuffer, /* GLint */ int @srcX0, /* GLint */ int @srcY0, /* GLint */ int @srcX1, /* GLint */ int @srcY1, /* GLint */ int @dstX0, /* GLint */ int @dstY0, /* GLint */ int @dstX1, /* GLint */ int @dstY1, /* GLbitfield */ int @mask, /* GLenum */ int @filter)
        => glBlitNamedFramebuffer(@readFramebuffer, @drawFramebuffer, @srcX0, @srcY0, @srcX1, @srcY1, @dstX0, @dstY0, @dstX1, @dstY1, @mask, @filter);
    public /* void */ void BufferData(/* GLenum */ int @target, /* GLsizeiptr */ nint @size, /* void */ void* @data, /* GLenum */ int @usage)
        => glBufferData(@target, @size, @data, @usage);
    public /* void */ void BufferStorage(/* GLenum */ int @target, /* GLsizeiptr */ nint @size, /* void */ void* @data, /* GLbitfield */ int @flags)
        => glBufferStorage(@target, @size, @data, @flags);
    public /* void */ void BufferSubData(/* GLenum */ int @target, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size, /* void */ void* @data)
        => glBufferSubData(@target, @offset, @size, @data);
    public /* GLenum */ int CheckFramebufferStatus(/* GLenum */ int @target)
        => glCheckFramebufferStatus(@target);
    public /* GLenum */ int CheckNamedFramebufferStatus(/* GLuint */ uint @framebuffer, /* GLenum */ int @target)
        => glCheckNamedFramebufferStatus(@framebuffer, @target);
    public /* void */ void ClampColor(/* GLenum */ int @target, /* GLenum */ int @clamp)
        => glClampColor(@target, @clamp);
    public /* void */ void Clear(/* GLbitfield */ int @mask)
        => glClear(@mask);
    public /* void */ void ClearBufferData(/* GLenum */ int @target, /* GLenum */ int @internalformat, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @data)
        => glClearBufferData(@target, @internalformat, @format, @type, @data);
    public /* void */ void ClearBufferSubData(/* GLenum */ int @target, /* GLenum */ int @internalformat, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @data)
        => glClearBufferSubData(@target, @internalformat, @offset, @size, @format, @type, @data);
    public /* void */ void ClearBufferfi(/* GLenum */ int @buffer, /* GLint */ int @drawbuffer, /* GLfloat */ float @depth, /* GLint */ int @stencil)
        => glClearBufferfi(@buffer, @drawbuffer, @depth, @stencil);
    public /* void */ void ClearBufferfv(/* GLenum */ int @buffer, /* GLint */ int @drawbuffer, /* GLfloat */ float* @value)
        => glClearBufferfv(@buffer, @drawbuffer, @value);
    public /* void */ void ClearBufferiv(/* GLenum */ int @buffer, /* GLint */ int @drawbuffer, /* GLint */ int* @value)
        => glClearBufferiv(@buffer, @drawbuffer, @value);
    public /* void */ void ClearBufferuiv(/* GLenum */ int @buffer, /* GLint */ int @drawbuffer, /* GLuint */ uint* @value)
        => glClearBufferuiv(@buffer, @drawbuffer, @value);
    public /* void */ void ClearColor(/* GLfloat */ float @red, /* GLfloat */ float @green, /* GLfloat */ float @blue, /* GLfloat */ float @alpha)
        => glClearColor(@red, @green, @blue, @alpha);
    public /* void */ void ClearDepth(/* GLdouble */ double @depth)
        => glClearDepth(@depth);
    public /* void */ void ClearDepthf(/* GLfloat */ float @d)
        => glClearDepthf(@d);
    public /* void */ void ClearNamedBufferData(/* GLuint */ uint @buffer, /* GLenum */ int @internalformat, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @data)
        => glClearNamedBufferData(@buffer, @internalformat, @format, @type, @data);
    public /* void */ void ClearNamedBufferSubData(/* GLuint */ uint @buffer, /* GLenum */ int @internalformat, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @data)
        => glClearNamedBufferSubData(@buffer, @internalformat, @offset, @size, @format, @type, @data);
    public /* void */ void ClearNamedFramebufferfi(/* GLuint */ uint @framebuffer, /* GLenum */ int @buffer, /* GLint */ int @drawbuffer, /* GLfloat */ float @depth, /* GLint */ int @stencil)
        => glClearNamedFramebufferfi(@framebuffer, @buffer, @drawbuffer, @depth, @stencil);
    public /* void */ void ClearNamedFramebufferfv(/* GLuint */ uint @framebuffer, /* GLenum */ int @buffer, /* GLint */ int @drawbuffer, /* GLfloat */ float* @value)
        => glClearNamedFramebufferfv(@framebuffer, @buffer, @drawbuffer, @value);
    public /* void */ void ClearNamedFramebufferiv(/* GLuint */ uint @framebuffer, /* GLenum */ int @buffer, /* GLint */ int @drawbuffer, /* GLint */ int* @value)
        => glClearNamedFramebufferiv(@framebuffer, @buffer, @drawbuffer, @value);
    public /* void */ void ClearNamedFramebufferuiv(/* GLuint */ uint @framebuffer, /* GLenum */ int @buffer, /* GLint */ int @drawbuffer, /* GLuint */ uint* @value)
        => glClearNamedFramebufferuiv(@framebuffer, @buffer, @drawbuffer, @value);
    public /* void */ void ClearStencil(/* GLint */ int @s)
        => glClearStencil(@s);
    public /* void */ void ClearTexImage(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @data)
        => glClearTexImage(@texture, @level, @format, @type, @data);
    public /* void */ void ClearTexSubImage(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @data)
        => glClearTexSubImage(@texture, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth, @format, @type, @data);
    public /* GLenum */ int ClientWaitSync(/* GLsync */ void* @sync, /* GLbitfield */ int @flags, /* GLuint64 */ ulong @timeout)
        => glClientWaitSync(@sync, @flags, @timeout);
    public /* void */ void ClipControl(/* GLenum */ int @origin, /* GLenum */ int @depth)
        => glClipControl(@origin, @depth);
    public /* void */ void ColorMask(/* GLboolean */ int @red, /* GLboolean */ int @green, /* GLboolean */ int @blue, /* GLboolean */ int @alpha)
        => glColorMask(@red, @green, @blue, @alpha);
    public /* void */ void ColorMaski(/* GLuint */ uint @index, /* GLboolean */ int @r, /* GLboolean */ int @g, /* GLboolean */ int @b, /* GLboolean */ int @a)
        => glColorMaski(@index, @r, @g, @b, @a);
    public /* void */ void CompileShader(/* GLuint */ uint @shader)
        => glCompileShader(@shader);
    public /* void */ void CompressedTexImage1D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLint */ int @border, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexImage1D(@target, @level, @internalformat, @width, @border, @imageSize, @data);
    public /* void */ void CompressedTexImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLint */ int @border, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexImage2D(@target, @level, @internalformat, @width, @height, @border, @imageSize, @data);
    public /* void */ void CompressedTexImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLint */ int @border, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexImage3D(@target, @level, @internalformat, @width, @height, @depth, @border, @imageSize, @data);
    public /* void */ void CompressedTexSubImage1D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLsizei */ int @width, /* GLenum */ int @format, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexSubImage1D(@target, @level, @xoffset, @width, @format, @imageSize, @data);
    public /* void */ void CompressedTexSubImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexSubImage2D(@target, @level, @xoffset, @yoffset, @width, @height, @format, @imageSize, @data);
    public /* void */ void CompressedTexSubImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLenum */ int @format, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexSubImage3D(@target, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth, @format, @imageSize, @data);
    public /* void */ void CompressedTextureSubImage1D(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLsizei */ int @width, /* GLenum */ int @format, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTextureSubImage1D(@texture, @level, @xoffset, @width, @format, @imageSize, @data);
    public /* void */ void CompressedTextureSubImage2D(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTextureSubImage2D(@texture, @level, @xoffset, @yoffset, @width, @height, @format, @imageSize, @data);
    public /* void */ void CompressedTextureSubImage3D(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLenum */ int @format, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTextureSubImage3D(@texture, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth, @format, @imageSize, @data);
    public /* void */ void CopyBufferSubData(/* GLenum */ int @readTarget, /* GLenum */ int @writeTarget, /* GLintptr */ nint @readOffset, /* GLintptr */ nint @writeOffset, /* GLsizeiptr */ nint @size)
        => glCopyBufferSubData(@readTarget, @writeTarget, @readOffset, @writeOffset, @size);
    public /* void */ void CopyImageSubData(/* GLuint */ uint @srcName, /* GLenum */ int @srcTarget, /* GLint */ int @srcLevel, /* GLint */ int @srcX, /* GLint */ int @srcY, /* GLint */ int @srcZ, /* GLuint */ uint @dstName, /* GLenum */ int @dstTarget, /* GLint */ int @dstLevel, /* GLint */ int @dstX, /* GLint */ int @dstY, /* GLint */ int @dstZ, /* GLsizei */ int @srcWidth, /* GLsizei */ int @srcHeight, /* GLsizei */ int @srcDepth)
        => glCopyImageSubData(@srcName, @srcTarget, @srcLevel, @srcX, @srcY, @srcZ, @dstName, @dstTarget, @dstLevel, @dstX, @dstY, @dstZ, @srcWidth, @srcHeight, @srcDepth);
    public /* void */ void CopyNamedBufferSubData(/* GLuint */ uint @readBuffer, /* GLuint */ uint @writeBuffer, /* GLintptr */ nint @readOffset, /* GLintptr */ nint @writeOffset, /* GLsizeiptr */ nint @size)
        => glCopyNamedBufferSubData(@readBuffer, @writeBuffer, @readOffset, @writeOffset, @size);
    public /* void */ void CopyTexImage1D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLint */ int @border)
        => glCopyTexImage1D(@target, @level, @internalformat, @x, @y, @width, @border);
    public /* void */ void CopyTexImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLint */ int @border)
        => glCopyTexImage2D(@target, @level, @internalformat, @x, @y, @width, @height, @border);
    public /* void */ void CopyTexSubImage1D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width)
        => glCopyTexSubImage1D(@target, @level, @xoffset, @x, @y, @width);
    public /* void */ void CopyTexSubImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glCopyTexSubImage2D(@target, @level, @xoffset, @yoffset, @x, @y, @width, @height);
    public /* void */ void CopyTexSubImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glCopyTexSubImage3D(@target, @level, @xoffset, @yoffset, @zoffset, @x, @y, @width, @height);
    public /* void */ void CopyTextureSubImage1D(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width)
        => glCopyTextureSubImage1D(@texture, @level, @xoffset, @x, @y, @width);
    public /* void */ void CopyTextureSubImage2D(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glCopyTextureSubImage2D(@texture, @level, @xoffset, @yoffset, @x, @y, @width, @height);
    public /* void */ void CopyTextureSubImage3D(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glCopyTextureSubImage3D(@texture, @level, @xoffset, @yoffset, @zoffset, @x, @y, @width, @height);
    public /* void */ void CreateBuffers(/* GLsizei */ int @n, /* GLuint */ uint* @buffers)
        => glCreateBuffers(@n, @buffers);
    public /* void */ void CreateFramebuffers(/* GLsizei */ int @n, /* GLuint */ uint* @framebuffers)
        => glCreateFramebuffers(@n, @framebuffers);
    public /* GLuint */ uint CreateProgram()
        => glCreateProgram();
    public /* void */ void CreateProgramPipelines(/* GLsizei */ int @n, /* GLuint */ uint* @pipelines)
        => glCreateProgramPipelines(@n, @pipelines);
    public /* void */ void CreateQueries(/* GLenum */ int @target, /* GLsizei */ int @n, /* GLuint */ uint* @ids)
        => glCreateQueries(@target, @n, @ids);
    public /* void */ void CreateRenderbuffers(/* GLsizei */ int @n, /* GLuint */ uint* @renderbuffers)
        => glCreateRenderbuffers(@n, @renderbuffers);
    public /* void */ void CreateSamplers(/* GLsizei */ int @n, /* GLuint */ uint* @samplers)
        => glCreateSamplers(@n, @samplers);
    public /* GLuint */ uint CreateShader(/* GLenum */ int @type)
        => glCreateShader(@type);
    public /* GLuint */ uint CreateShaderProgramv(/* GLenum */ int @type, /* GLsizei */ int @count, /* GLchar */ byte* @strings)
        => glCreateShaderProgramv(@type, @count, @strings);
    public /* void */ void CreateTextures(/* GLenum */ int @target, /* GLsizei */ int @n, /* GLuint */ uint* @textures)
        => glCreateTextures(@target, @n, @textures);
    public /* void */ void CreateTransformFeedbacks(/* GLsizei */ int @n, /* GLuint */ uint* @ids)
        => glCreateTransformFeedbacks(@n, @ids);
    public /* void */ void CreateVertexArrays(/* GLsizei */ int @n, /* GLuint */ uint* @arrays)
        => glCreateVertexArrays(@n, @arrays);
    public /* void */ void CullFace(/* GLenum */ int @mode)
        => glCullFace(@mode);
    public /* void */ void DebugMessageCallback(/* GLDEBUGPROC */ delegate* unmanaged<int, int, uint, int, nint, sbyte*, void*, void> @callback, /* void */ void* @userParam)
        => glDebugMessageCallback(@callback, @userParam);
    public /* void */ void DebugMessageControl(/* GLenum */ int @source, /* GLenum */ int @type, /* GLenum */ int @severity, /* GLsizei */ int @count, /* GLuint */ uint* @ids, /* GLboolean */ int @enabled)
        => glDebugMessageControl(@source, @type, @severity, @count, @ids, @enabled);
    public /* void */ void DebugMessageInsert(/* GLenum */ int @source, /* GLenum */ int @type, /* GLuint */ uint @id, /* GLenum */ int @severity, /* GLsizei */ int @length, /* GLchar */ byte* @buf)
        => glDebugMessageInsert(@source, @type, @id, @severity, @length, @buf);
    public /* void */ void DeleteBuffers(/* GLsizei */ int @n, /* GLuint */ uint* @buffers)
        => glDeleteBuffers(@n, @buffers);
    public /* void */ void DeleteFramebuffers(/* GLsizei */ int @n, /* GLuint */ uint* @framebuffers)
        => glDeleteFramebuffers(@n, @framebuffers);
    public /* void */ void DeleteProgram(/* GLuint */ uint @program)
        => glDeleteProgram(@program);
    public /* void */ void DeleteProgramPipelines(/* GLsizei */ int @n, /* GLuint */ uint* @pipelines)
        => glDeleteProgramPipelines(@n, @pipelines);
    public /* void */ void DeleteQueries(/* GLsizei */ int @n, /* GLuint */ uint* @ids)
        => glDeleteQueries(@n, @ids);
    public /* void */ void DeleteRenderbuffers(/* GLsizei */ int @n, /* GLuint */ uint* @renderbuffers)
        => glDeleteRenderbuffers(@n, @renderbuffers);
    public /* void */ void DeleteSamplers(/* GLsizei */ int @count, /* GLuint */ uint* @samplers)
        => glDeleteSamplers(@count, @samplers);
    public /* void */ void DeleteShader(/* GLuint */ uint @shader)
        => glDeleteShader(@shader);
    public /* void */ void DeleteSync(/* GLsync */ void* @sync)
        => glDeleteSync(@sync);
    public /* void */ void DeleteTextures(/* GLsizei */ int @n, /* GLuint */ uint* @textures)
        => glDeleteTextures(@n, @textures);
    public /* void */ void DeleteTransformFeedbacks(/* GLsizei */ int @n, /* GLuint */ uint* @ids)
        => glDeleteTransformFeedbacks(@n, @ids);
    public /* void */ void DeleteVertexArrays(/* GLsizei */ int @n, /* GLuint */ uint* @arrays)
        => glDeleteVertexArrays(@n, @arrays);
    public /* void */ void DepthFunc(/* GLenum */ int @func)
        => glDepthFunc(@func);
    public /* void */ void DepthMask(/* GLboolean */ int @flag)
        => glDepthMask(@flag);
    public /* void */ void DepthRange(/* GLdouble */ double @n, /* GLdouble */ double @f)
        => glDepthRange(@n, @f);
    public /* void */ void DepthRangeArrayv(/* GLuint */ uint @first, /* GLsizei */ int @count, /* GLdouble */ double* @v)
        => glDepthRangeArrayv(@first, @count, @v);
    public /* void */ void DepthRangeIndexed(/* GLuint */ uint @index, /* GLdouble */ double @n, /* GLdouble */ double @f)
        => glDepthRangeIndexed(@index, @n, @f);
    public /* void */ void DepthRangef(/* GLfloat */ float @n, /* GLfloat */ float @f)
        => glDepthRangef(@n, @f);
    public /* void */ void DetachShader(/* GLuint */ uint @program, /* GLuint */ uint @shader)
        => glDetachShader(@program, @shader);
    public /* void */ void Disable(/* GLenum */ int @cap)
        => glDisable(@cap);
    public /* void */ void DisableVertexArrayAttrib(/* GLuint */ uint @vaobj, /* GLuint */ uint @index)
        => glDisableVertexArrayAttrib(@vaobj, @index);
    public /* void */ void DisableVertexAttribArray(/* GLuint */ uint @index)
        => glDisableVertexAttribArray(@index);
    public /* void */ void Disablei(/* GLenum */ int @target, /* GLuint */ uint @index)
        => glDisablei(@target, @index);
    public /* void */ void DispatchCompute(/* GLuint */ uint @num_groups_x, /* GLuint */ uint @num_groups_y, /* GLuint */ uint @num_groups_z)
        => glDispatchCompute(@num_groups_x, @num_groups_y, @num_groups_z);
    public /* void */ void DispatchComputeIndirect(/* GLintptr */ nint @indirect)
        => glDispatchComputeIndirect(@indirect);
    public /* void */ void DrawArrays(/* GLenum */ int @mode, /* GLint */ int @first, /* GLsizei */ int @count)
        => glDrawArrays(@mode, @first, @count);
    public /* void */ void DrawArraysIndirect(/* GLenum */ int @mode, /* void */ void* @indirect)
        => glDrawArraysIndirect(@mode, @indirect);
    public /* void */ void DrawArraysInstanced(/* GLenum */ int @mode, /* GLint */ int @first, /* GLsizei */ int @count, /* GLsizei */ int @instancecount)
        => glDrawArraysInstanced(@mode, @first, @count, @instancecount);
    public /* void */ void DrawArraysInstancedBaseInstance(/* GLenum */ int @mode, /* GLint */ int @first, /* GLsizei */ int @count, /* GLsizei */ int @instancecount, /* GLuint */ uint @baseinstance)
        => glDrawArraysInstancedBaseInstance(@mode, @first, @count, @instancecount, @baseinstance);
    public /* void */ void DrawBuffer(/* GLenum */ int @buf)
        => glDrawBuffer(@buf);
    public /* void */ void DrawBuffers(/* GLsizei */ int @n, /* GLenum */ int* @bufs)
        => glDrawBuffers(@n, @bufs);
    public /* void */ void DrawElements(/* GLenum */ int @mode, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices)
        => glDrawElements(@mode, @count, @type, @indices);
    public /* void */ void DrawElementsBaseVertex(/* GLenum */ int @mode, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLint */ int @basevertex)
        => glDrawElementsBaseVertex(@mode, @count, @type, @indices, @basevertex);
    public /* void */ void DrawElementsIndirect(/* GLenum */ int @mode, /* GLenum */ int @type, /* void */ void* @indirect)
        => glDrawElementsIndirect(@mode, @type, @indirect);
    public /* void */ void DrawElementsInstanced(/* GLenum */ int @mode, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLsizei */ int @instancecount)
        => glDrawElementsInstanced(@mode, @count, @type, @indices, @instancecount);
    public /* void */ void DrawElementsInstancedBaseInstance(/* GLenum */ int @mode, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLsizei */ int @instancecount, /* GLuint */ uint @baseinstance)
        => glDrawElementsInstancedBaseInstance(@mode, @count, @type, @indices, @instancecount, @baseinstance);
    public /* void */ void DrawElementsInstancedBaseVertex(/* GLenum */ int @mode, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLsizei */ int @instancecount, /* GLint */ int @basevertex)
        => glDrawElementsInstancedBaseVertex(@mode, @count, @type, @indices, @instancecount, @basevertex);
    public /* void */ void DrawElementsInstancedBaseVertexBaseInstance(/* GLenum */ int @mode, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLsizei */ int @instancecount, /* GLint */ int @basevertex, /* GLuint */ uint @baseinstance)
        => glDrawElementsInstancedBaseVertexBaseInstance(@mode, @count, @type, @indices, @instancecount, @basevertex, @baseinstance);
    public /* void */ void DrawRangeElements(/* GLenum */ int @mode, /* GLuint */ uint @start, /* GLuint */ uint @end, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices)
        => glDrawRangeElements(@mode, @start, @end, @count, @type, @indices);
    public /* void */ void DrawRangeElementsBaseVertex(/* GLenum */ int @mode, /* GLuint */ uint @start, /* GLuint */ uint @end, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLint */ int @basevertex)
        => glDrawRangeElementsBaseVertex(@mode, @start, @end, @count, @type, @indices, @basevertex);
    public /* void */ void DrawTransformFeedback(/* GLenum */ int @mode, /* GLuint */ uint @id)
        => glDrawTransformFeedback(@mode, @id);
    public /* void */ void DrawTransformFeedbackInstanced(/* GLenum */ int @mode, /* GLuint */ uint @id, /* GLsizei */ int @instancecount)
        => glDrawTransformFeedbackInstanced(@mode, @id, @instancecount);
    public /* void */ void DrawTransformFeedbackStream(/* GLenum */ int @mode, /* GLuint */ uint @id, /* GLuint */ uint @stream)
        => glDrawTransformFeedbackStream(@mode, @id, @stream);
    public /* void */ void DrawTransformFeedbackStreamInstanced(/* GLenum */ int @mode, /* GLuint */ uint @id, /* GLuint */ uint @stream, /* GLsizei */ int @instancecount)
        => glDrawTransformFeedbackStreamInstanced(@mode, @id, @stream, @instancecount);
    public /* void */ void Enable(/* GLenum */ int @cap)
        => glEnable(@cap);
    public /* void */ void EnableVertexArrayAttrib(/* GLuint */ uint @vaobj, /* GLuint */ uint @index)
        => glEnableVertexArrayAttrib(@vaobj, @index);
    public /* void */ void EnableVertexAttribArray(/* GLuint */ uint @index)
        => glEnableVertexAttribArray(@index);
    public /* void */ void Enablei(/* GLenum */ int @target, /* GLuint */ uint @index)
        => glEnablei(@target, @index);
    public /* void */ void EndConditionalRender()
        => glEndConditionalRender();
    public /* void */ void EndQuery(/* GLenum */ int @target)
        => glEndQuery(@target);
    public /* void */ void EndQueryIndexed(/* GLenum */ int @target, /* GLuint */ uint @index)
        => glEndQueryIndexed(@target, @index);
    public /* void */ void EndTransformFeedback()
        => glEndTransformFeedback();
    public /* GLsync */ void* FenceSync(/* GLenum */ int @condition, /* GLbitfield */ int @flags)
        => glFenceSync(@condition, @flags);
    public /* void */ void Finish()
        => glFinish();
    public /* void */ void Flush()
        => glFlush();
    public /* void */ void FlushMappedBufferRange(/* GLenum */ int @target, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @length)
        => glFlushMappedBufferRange(@target, @offset, @length);
    public /* void */ void FlushMappedNamedBufferRange(/* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @length)
        => glFlushMappedNamedBufferRange(@buffer, @offset, @length);
    public /* void */ void FramebufferParameteri(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int @param)
        => glFramebufferParameteri(@target, @pname, @param);
    public /* void */ void FramebufferRenderbuffer(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLenum */ int @renderbuffertarget, /* GLuint */ uint @renderbuffer)
        => glFramebufferRenderbuffer(@target, @attachment, @renderbuffertarget, @renderbuffer);
    public /* void */ void FramebufferTexture(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLuint */ uint @texture, /* GLint */ int @level)
        => glFramebufferTexture(@target, @attachment, @texture, @level);
    public /* void */ void FramebufferTexture1D(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLenum */ int @textarget, /* GLuint */ uint @texture, /* GLint */ int @level)
        => glFramebufferTexture1D(@target, @attachment, @textarget, @texture, @level);
    public /* void */ void FramebufferTexture2D(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLenum */ int @textarget, /* GLuint */ uint @texture, /* GLint */ int @level)
        => glFramebufferTexture2D(@target, @attachment, @textarget, @texture, @level);
    public /* void */ void FramebufferTexture3D(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLenum */ int @textarget, /* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @zoffset)
        => glFramebufferTexture3D(@target, @attachment, @textarget, @texture, @level, @zoffset);
    public /* void */ void FramebufferTextureLayer(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @layer)
        => glFramebufferTextureLayer(@target, @attachment, @texture, @level, @layer);
    public /* void */ void FrontFace(/* GLenum */ int @mode)
        => glFrontFace(@mode);
    public /* void */ void GenBuffers(/* GLsizei */ int @n, /* GLuint */ uint* @buffers)
        => glGenBuffers(@n, @buffers);
    public /* void */ void GenFramebuffers(/* GLsizei */ int @n, /* GLuint */ uint* @framebuffers)
        => glGenFramebuffers(@n, @framebuffers);
    public /* void */ void GenProgramPipelines(/* GLsizei */ int @n, /* GLuint */ uint* @pipelines)
        => glGenProgramPipelines(@n, @pipelines);
    public /* void */ void GenQueries(/* GLsizei */ int @n, /* GLuint */ uint* @ids)
        => glGenQueries(@n, @ids);
    public /* void */ void GenRenderbuffers(/* GLsizei */ int @n, /* GLuint */ uint* @renderbuffers)
        => glGenRenderbuffers(@n, @renderbuffers);
    public /* void */ void GenSamplers(/* GLsizei */ int @count, /* GLuint */ uint* @samplers)
        => glGenSamplers(@count, @samplers);
    public /* void */ void GenTextures(/* GLsizei */ int @n, /* GLuint */ uint* @textures)
        => glGenTextures(@n, @textures);
    public /* void */ void GenTransformFeedbacks(/* GLsizei */ int @n, /* GLuint */ uint* @ids)
        => glGenTransformFeedbacks(@n, @ids);
    public /* void */ void GenVertexArrays(/* GLsizei */ int @n, /* GLuint */ uint* @arrays)
        => glGenVertexArrays(@n, @arrays);
    public /* void */ void GenerateMipmap(/* GLenum */ int @target)
        => glGenerateMipmap(@target);
    public /* void */ void GenerateTextureMipmap(/* GLuint */ uint @texture)
        => glGenerateTextureMipmap(@texture);
    public /* void */ void GetActiveAtomicCounterBufferiv(/* GLuint */ uint @program, /* GLuint */ uint @bufferIndex, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetActiveAtomicCounterBufferiv(@program, @bufferIndex, @pname, @params);
    public /* void */ void GetActiveAttrib(/* GLuint */ uint @program, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLint */ int* @size, /* GLenum */ int* @type, /* GLchar */ byte* @name)
        => glGetActiveAttrib(@program, @index, @bufSize, @length, @size, @type, @name);
    public /* void */ void GetActiveSubroutineName(/* GLuint */ uint @program, /* GLenum */ int @shadertype, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @name)
        => glGetActiveSubroutineName(@program, @shadertype, @index, @bufSize, @length, @name);
    public /* void */ void GetActiveSubroutineUniformName(/* GLuint */ uint @program, /* GLenum */ int @shadertype, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @name)
        => glGetActiveSubroutineUniformName(@program, @shadertype, @index, @bufSize, @length, @name);
    public /* void */ void GetActiveSubroutineUniformiv(/* GLuint */ uint @program, /* GLenum */ int @shadertype, /* GLuint */ uint @index, /* GLenum */ int @pname, /* GLint */ int* @values)
        => glGetActiveSubroutineUniformiv(@program, @shadertype, @index, @pname, @values);
    public /* void */ void GetActiveUniform(/* GLuint */ uint @program, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLint */ int* @size, /* GLenum */ int* @type, /* GLchar */ byte* @name)
        => glGetActiveUniform(@program, @index, @bufSize, @length, @size, @type, @name);
    public /* void */ void GetActiveUniformBlockName(/* GLuint */ uint @program, /* GLuint */ uint @uniformBlockIndex, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @uniformBlockName)
        => glGetActiveUniformBlockName(@program, @uniformBlockIndex, @bufSize, @length, @uniformBlockName);
    public /* void */ void GetActiveUniformBlockiv(/* GLuint */ uint @program, /* GLuint */ uint @uniformBlockIndex, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetActiveUniformBlockiv(@program, @uniformBlockIndex, @pname, @params);
    public /* void */ void GetActiveUniformName(/* GLuint */ uint @program, /* GLuint */ uint @uniformIndex, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @uniformName)
        => glGetActiveUniformName(@program, @uniformIndex, @bufSize, @length, @uniformName);
    public /* void */ void GetActiveUniformsiv(/* GLuint */ uint @program, /* GLsizei */ int @uniformCount, /* GLuint */ uint* @uniformIndices, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetActiveUniformsiv(@program, @uniformCount, @uniformIndices, @pname, @params);
    public /* void */ void GetAttachedShaders(/* GLuint */ uint @program, /* GLsizei */ int @maxCount, /* GLsizei */ int* @count, /* GLuint */ uint* @shaders)
        => glGetAttachedShaders(@program, @maxCount, @count, @shaders);
    public /* GLint */ int GetAttribLocation(/* GLuint */ uint @program, /* GLchar */ byte* @name)
        => glGetAttribLocation(@program, @name);
    public /* void */ void GetBooleani_v(/* GLenum */ int @target, /* GLuint */ uint @index, /* GLboolean */ int* @data)
        => glGetBooleani_v(@target, @index, @data);
    public /* void */ void GetBooleanv(/* GLenum */ int @pname, /* GLboolean */ int* @data)
        => glGetBooleanv(@pname, @data);
    public /* void */ void GetBufferParameteri64v(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint64 */ long* @params)
        => glGetBufferParameteri64v(@target, @pname, @params);
    public /* void */ void GetBufferParameteriv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetBufferParameteriv(@target, @pname, @params);
    public /* void */ void GetBufferPointerv(/* GLenum */ int @target, /* GLenum */ int @pname, /* void */ void** @params)
        => glGetBufferPointerv(@target, @pname, @params);
    public /* void */ void GetBufferSubData(/* GLenum */ int @target, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size, /* void */ void* @data)
        => glGetBufferSubData(@target, @offset, @size, @data);
    public /* void */ void GetCompressedTexImage(/* GLenum */ int @target, /* GLint */ int @level, /* void */ void* @img)
        => glGetCompressedTexImage(@target, @level, @img);
    public /* void */ void GetCompressedTextureImage(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLsizei */ int @bufSize, /* void */ void* @pixels)
        => glGetCompressedTextureImage(@texture, @level, @bufSize, @pixels);
    public /* void */ void GetCompressedTextureSubImage(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLsizei */ int @bufSize, /* void */ void* @pixels)
        => glGetCompressedTextureSubImage(@texture, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth, @bufSize, @pixels);
    public /* GLuint */ uint GetDebugMessageLog(/* GLuint */ uint @count, /* GLsizei */ int @bufSize, /* GLenum */ int* @sources, /* GLenum */ int* @types, /* GLuint */ uint* @ids, /* GLenum */ int* @severities, /* GLsizei */ int* @lengths, /* GLchar */ byte* @messageLog)
        => glGetDebugMessageLog(@count, @bufSize, @sources, @types, @ids, @severities, @lengths, @messageLog);
    public /* void */ void GetDoublei_v(/* GLenum */ int @target, /* GLuint */ uint @index, /* GLdouble */ double* @data)
        => glGetDoublei_v(@target, @index, @data);
    public /* void */ void GetDoublev(/* GLenum */ int @pname, /* GLdouble */ double* @data)
        => glGetDoublev(@pname, @data);
    public /* GLenum */ int GetError()
        => glGetError();
    public /* void */ void GetFloati_v(/* GLenum */ int @target, /* GLuint */ uint @index, /* GLfloat */ float* @data)
        => glGetFloati_v(@target, @index, @data);
    public /* void */ void GetFloatv(/* GLenum */ int @pname, /* GLfloat */ float* @data)
        => glGetFloatv(@pname, @data);
    public /* GLint */ int GetFragDataIndex(/* GLuint */ uint @program, /* GLchar */ byte* @name)
        => glGetFragDataIndex(@program, @name);
    public /* GLint */ int GetFragDataLocation(/* GLuint */ uint @program, /* GLchar */ byte* @name)
        => glGetFragDataLocation(@program, @name);
    public /* void */ void GetFramebufferAttachmentParameteriv(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetFramebufferAttachmentParameteriv(@target, @attachment, @pname, @params);
    public /* void */ void GetFramebufferParameteriv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetFramebufferParameteriv(@target, @pname, @params);
    public /* GLenum */ int GetGraphicsResetStatus()
        => glGetGraphicsResetStatus();
    public /* void */ void GetInteger64i_v(/* GLenum */ int @target, /* GLuint */ uint @index, /* GLint64 */ long* @data)
        => glGetInteger64i_v(@target, @index, @data);
    public /* void */ void GetInteger64v(/* GLenum */ int @pname, /* GLint64 */ long* @data)
        => glGetInteger64v(@pname, @data);
    public /* void */ void GetIntegeri_v(/* GLenum */ int @target, /* GLuint */ uint @index, /* GLint */ int* @data)
        => glGetIntegeri_v(@target, @index, @data);
    public /* void */ void GetIntegerv(/* GLenum */ int @pname, /* GLint */ int* @data)
        => glGetIntegerv(@pname, @data);
    public /* void */ void GetInternalformati64v(/* GLenum */ int @target, /* GLenum */ int @internalformat, /* GLenum */ int @pname, /* GLsizei */ int @count, /* GLint64 */ long* @params)
        => glGetInternalformati64v(@target, @internalformat, @pname, @count, @params);
    public /* void */ void GetInternalformativ(/* GLenum */ int @target, /* GLenum */ int @internalformat, /* GLenum */ int @pname, /* GLsizei */ int @count, /* GLint */ int* @params)
        => glGetInternalformativ(@target, @internalformat, @pname, @count, @params);
    public /* void */ void GetMultisamplefv(/* GLenum */ int @pname, /* GLuint */ uint @index, /* GLfloat */ float* @val)
        => glGetMultisamplefv(@pname, @index, @val);
    public /* void */ void GetNamedBufferParameteri64v(/* GLuint */ uint @buffer, /* GLenum */ int @pname, /* GLint64 */ long* @params)
        => glGetNamedBufferParameteri64v(@buffer, @pname, @params);
    public /* void */ void GetNamedBufferParameteriv(/* GLuint */ uint @buffer, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetNamedBufferParameteriv(@buffer, @pname, @params);
    public /* void */ void GetNamedBufferPointerv(/* GLuint */ uint @buffer, /* GLenum */ int @pname, /* void */ void** @params)
        => glGetNamedBufferPointerv(@buffer, @pname, @params);
    public /* void */ void GetNamedBufferSubData(/* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size, /* void */ void* @data)
        => glGetNamedBufferSubData(@buffer, @offset, @size, @data);
    public /* void */ void GetNamedFramebufferAttachmentParameteriv(/* GLuint */ uint @framebuffer, /* GLenum */ int @attachment, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetNamedFramebufferAttachmentParameteriv(@framebuffer, @attachment, @pname, @params);
    public /* void */ void GetNamedFramebufferParameteriv(/* GLuint */ uint @framebuffer, /* GLenum */ int @pname, /* GLint */ int* @param)
        => glGetNamedFramebufferParameteriv(@framebuffer, @pname, @param);
    public /* void */ void GetNamedRenderbufferParameteriv(/* GLuint */ uint @renderbuffer, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetNamedRenderbufferParameteriv(@renderbuffer, @pname, @params);
    public /* void */ void GetObjectLabel(/* GLenum */ int @identifier, /* GLuint */ uint @name, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @label)
        => glGetObjectLabel(@identifier, @name, @bufSize, @length, @label);
    public /* void */ void GetObjectPtrLabel(/* void */ void* @ptr, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @label)
        => glGetObjectPtrLabel(@ptr, @bufSize, @length, @label);
    public /* void */ void GetProgramBinary(/* GLuint */ uint @program, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLenum */ int* @binaryFormat, /* void */ void* @binary)
        => glGetProgramBinary(@program, @bufSize, @length, @binaryFormat, @binary);
    public /* void */ void GetProgramInfoLog(/* GLuint */ uint @program, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @infoLog)
        => glGetProgramInfoLog(@program, @bufSize, @length, @infoLog);
    public /* void */ void GetProgramInterfaceiv(/* GLuint */ uint @program, /* GLenum */ int @programInterface, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetProgramInterfaceiv(@program, @programInterface, @pname, @params);
    public /* void */ void GetProgramPipelineInfoLog(/* GLuint */ uint @pipeline, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @infoLog)
        => glGetProgramPipelineInfoLog(@pipeline, @bufSize, @length, @infoLog);
    public /* void */ void GetProgramPipelineiv(/* GLuint */ uint @pipeline, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetProgramPipelineiv(@pipeline, @pname, @params);
    public /* GLuint */ uint GetProgramResourceIndex(/* GLuint */ uint @program, /* GLenum */ int @programInterface, /* GLchar */ byte* @name)
        => glGetProgramResourceIndex(@program, @programInterface, @name);
    public /* GLint */ int GetProgramResourceLocation(/* GLuint */ uint @program, /* GLenum */ int @programInterface, /* GLchar */ byte* @name)
        => glGetProgramResourceLocation(@program, @programInterface, @name);
    public /* GLint */ int GetProgramResourceLocationIndex(/* GLuint */ uint @program, /* GLenum */ int @programInterface, /* GLchar */ byte* @name)
        => glGetProgramResourceLocationIndex(@program, @programInterface, @name);
    public /* void */ void GetProgramResourceName(/* GLuint */ uint @program, /* GLenum */ int @programInterface, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @name)
        => glGetProgramResourceName(@program, @programInterface, @index, @bufSize, @length, @name);
    public /* void */ void GetProgramResourceiv(/* GLuint */ uint @program, /* GLenum */ int @programInterface, /* GLuint */ uint @index, /* GLsizei */ int @propCount, /* GLenum */ int* @props, /* GLsizei */ int @count, /* GLsizei */ int* @length, /* GLint */ int* @params)
        => glGetProgramResourceiv(@program, @programInterface, @index, @propCount, @props, @count, @length, @params);
    public /* void */ void GetProgramStageiv(/* GLuint */ uint @program, /* GLenum */ int @shadertype, /* GLenum */ int @pname, /* GLint */ int* @values)
        => glGetProgramStageiv(@program, @shadertype, @pname, @values);
    public /* void */ void GetProgramiv(/* GLuint */ uint @program, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetProgramiv(@program, @pname, @params);
    public /* void */ void GetQueryBufferObjecti64v(/* GLuint */ uint @id, /* GLuint */ uint @buffer, /* GLenum */ int @pname, /* GLintptr */ nint @offset)
        => glGetQueryBufferObjecti64v(@id, @buffer, @pname, @offset);
    public /* void */ void GetQueryBufferObjectiv(/* GLuint */ uint @id, /* GLuint */ uint @buffer, /* GLenum */ int @pname, /* GLintptr */ nint @offset)
        => glGetQueryBufferObjectiv(@id, @buffer, @pname, @offset);
    public /* void */ void GetQueryBufferObjectui64v(/* GLuint */ uint @id, /* GLuint */ uint @buffer, /* GLenum */ int @pname, /* GLintptr */ nint @offset)
        => glGetQueryBufferObjectui64v(@id, @buffer, @pname, @offset);
    public /* void */ void GetQueryBufferObjectuiv(/* GLuint */ uint @id, /* GLuint */ uint @buffer, /* GLenum */ int @pname, /* GLintptr */ nint @offset)
        => glGetQueryBufferObjectuiv(@id, @buffer, @pname, @offset);
    public /* void */ void GetQueryIndexediv(/* GLenum */ int @target, /* GLuint */ uint @index, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetQueryIndexediv(@target, @index, @pname, @params);
    public /* void */ void GetQueryObjecti64v(/* GLuint */ uint @id, /* GLenum */ int @pname, /* GLint64 */ long* @params)
        => glGetQueryObjecti64v(@id, @pname, @params);
    public /* void */ void GetQueryObjectiv(/* GLuint */ uint @id, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetQueryObjectiv(@id, @pname, @params);
    public /* void */ void GetQueryObjectui64v(/* GLuint */ uint @id, /* GLenum */ int @pname, /* GLuint64 */ ulong* @params)
        => glGetQueryObjectui64v(@id, @pname, @params);
    public /* void */ void GetQueryObjectuiv(/* GLuint */ uint @id, /* GLenum */ int @pname, /* GLuint */ uint* @params)
        => glGetQueryObjectuiv(@id, @pname, @params);
    public /* void */ void GetQueryiv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetQueryiv(@target, @pname, @params);
    public /* void */ void GetRenderbufferParameteriv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetRenderbufferParameteriv(@target, @pname, @params);
    public /* void */ void GetSamplerParameterIiv(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetSamplerParameterIiv(@sampler, @pname, @params);
    public /* void */ void GetSamplerParameterIuiv(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLuint */ uint* @params)
        => glGetSamplerParameterIuiv(@sampler, @pname, @params);
    public /* void */ void GetSamplerParameterfv(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetSamplerParameterfv(@sampler, @pname, @params);
    public /* void */ void GetSamplerParameteriv(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetSamplerParameteriv(@sampler, @pname, @params);
    public /* void */ void GetShaderInfoLog(/* GLuint */ uint @shader, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @infoLog)
        => glGetShaderInfoLog(@shader, @bufSize, @length, @infoLog);
    public /* void */ void GetShaderPrecisionFormat(/* GLenum */ int @shadertype, /* GLenum */ int @precisiontype, /* GLint */ int* @range, /* GLint */ int* @precision)
        => glGetShaderPrecisionFormat(@shadertype, @precisiontype, @range, @precision);
    public /* void */ void GetShaderSource(/* GLuint */ uint @shader, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @source)
        => glGetShaderSource(@shader, @bufSize, @length, @source);
    public /* void */ void GetShaderiv(/* GLuint */ uint @shader, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetShaderiv(@shader, @pname, @params);
    public /* GLubyte */ byte* GetString(/* GLenum */ int @name)
        => glGetString(@name);
    public /* GLubyte */ byte* GetStringi(/* GLenum */ int @name, /* GLuint */ uint @index)
        => glGetStringi(@name, @index);
    public /* GLuint */ uint GetSubroutineIndex(/* GLuint */ uint @program, /* GLenum */ int @shadertype, /* GLchar */ byte* @name)
        => glGetSubroutineIndex(@program, @shadertype, @name);
    public /* GLint */ int GetSubroutineUniformLocation(/* GLuint */ uint @program, /* GLenum */ int @shadertype, /* GLchar */ byte* @name)
        => glGetSubroutineUniformLocation(@program, @shadertype, @name);
    public /* void */ void GetSynciv(/* GLsync */ void* @sync, /* GLenum */ int @pname, /* GLsizei */ int @count, /* GLsizei */ int* @length, /* GLint */ int* @values)
        => glGetSynciv(@sync, @pname, @count, @length, @values);
    public /* void */ void GetTexImage(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glGetTexImage(@target, @level, @format, @type, @pixels);
    public /* void */ void GetTexLevelParameterfv(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetTexLevelParameterfv(@target, @level, @pname, @params);
    public /* void */ void GetTexLevelParameteriv(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetTexLevelParameteriv(@target, @level, @pname, @params);
    public /* void */ void GetTexParameterIiv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetTexParameterIiv(@target, @pname, @params);
    public /* void */ void GetTexParameterIuiv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLuint */ uint* @params)
        => glGetTexParameterIuiv(@target, @pname, @params);
    public /* void */ void GetTexParameterfv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetTexParameterfv(@target, @pname, @params);
    public /* void */ void GetTexParameteriv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetTexParameteriv(@target, @pname, @params);
    public /* void */ void GetTextureImage(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLenum */ int @format, /* GLenum */ int @type, /* GLsizei */ int @bufSize, /* void */ void* @pixels)
        => glGetTextureImage(@texture, @level, @format, @type, @bufSize, @pixels);
    public /* void */ void GetTextureLevelParameterfv(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetTextureLevelParameterfv(@texture, @level, @pname, @params);
    public /* void */ void GetTextureLevelParameteriv(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetTextureLevelParameteriv(@texture, @level, @pname, @params);
    public /* void */ void GetTextureParameterIiv(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetTextureParameterIiv(@texture, @pname, @params);
    public /* void */ void GetTextureParameterIuiv(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLuint */ uint* @params)
        => glGetTextureParameterIuiv(@texture, @pname, @params);
    public /* void */ void GetTextureParameterfv(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetTextureParameterfv(@texture, @pname, @params);
    public /* void */ void GetTextureParameteriv(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetTextureParameteriv(@texture, @pname, @params);
    public /* void */ void GetTextureSubImage(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLenum */ int @format, /* GLenum */ int @type, /* GLsizei */ int @bufSize, /* void */ void* @pixels)
        => glGetTextureSubImage(@texture, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth, @format, @type, @bufSize, @pixels);
    public /* void */ void GetTransformFeedbackVarying(/* GLuint */ uint @program, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLsizei */ int* @size, /* GLenum */ int* @type, /* GLchar */ byte* @name)
        => glGetTransformFeedbackVarying(@program, @index, @bufSize, @length, @size, @type, @name);
    public /* void */ void GetTransformFeedbacki64_v(/* GLuint */ uint @xfb, /* GLenum */ int @pname, /* GLuint */ uint @index, /* GLint64 */ long* @param)
        => glGetTransformFeedbacki64_v(@xfb, @pname, @index, @param);
    public /* void */ void GetTransformFeedbacki_v(/* GLuint */ uint @xfb, /* GLenum */ int @pname, /* GLuint */ uint @index, /* GLint */ int* @param)
        => glGetTransformFeedbacki_v(@xfb, @pname, @index, @param);
    public /* void */ void GetTransformFeedbackiv(/* GLuint */ uint @xfb, /* GLenum */ int @pname, /* GLint */ int* @param)
        => glGetTransformFeedbackiv(@xfb, @pname, @param);
    public /* GLuint */ uint GetUniformBlockIndex(/* GLuint */ uint @program, /* GLchar */ byte* @uniformBlockName)
        => glGetUniformBlockIndex(@program, @uniformBlockName);
    public /* void */ void GetUniformIndices(/* GLuint */ uint @program, /* GLsizei */ int @uniformCount, /* GLchar */ byte* @uniformNames, /* GLuint */ uint* @uniformIndices)
        => glGetUniformIndices(@program, @uniformCount, @uniformNames, @uniformIndices);
    public /* GLint */ int GetUniformLocation(/* GLuint */ uint @program, /* GLchar */ byte* @name)
        => glGetUniformLocation(@program, @name);
    public /* void */ void GetUniformSubroutineuiv(/* GLenum */ int @shadertype, /* GLint */ int @location, /* GLuint */ uint* @params)
        => glGetUniformSubroutineuiv(@shadertype, @location, @params);
    public /* void */ void GetUniformdv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLdouble */ double* @params)
        => glGetUniformdv(@program, @location, @params);
    public /* void */ void GetUniformfv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLfloat */ float* @params)
        => glGetUniformfv(@program, @location, @params);
    public /* void */ void GetUniformiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLint */ int* @params)
        => glGetUniformiv(@program, @location, @params);
    public /* void */ void GetUniformuiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLuint */ uint* @params)
        => glGetUniformuiv(@program, @location, @params);
    public /* void */ void GetVertexArrayIndexed64iv(/* GLuint */ uint @vaobj, /* GLuint */ uint @index, /* GLenum */ int @pname, /* GLint64 */ long* @param)
        => glGetVertexArrayIndexed64iv(@vaobj, @index, @pname, @param);
    public /* void */ void GetVertexArrayIndexediv(/* GLuint */ uint @vaobj, /* GLuint */ uint @index, /* GLenum */ int @pname, /* GLint */ int* @param)
        => glGetVertexArrayIndexediv(@vaobj, @index, @pname, @param);
    public /* void */ void GetVertexArrayiv(/* GLuint */ uint @vaobj, /* GLenum */ int @pname, /* GLint */ int* @param)
        => glGetVertexArrayiv(@vaobj, @pname, @param);
    public /* void */ void GetVertexAttribIiv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetVertexAttribIiv(@index, @pname, @params);
    public /* void */ void GetVertexAttribIuiv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLuint */ uint* @params)
        => glGetVertexAttribIuiv(@index, @pname, @params);
    public /* void */ void GetVertexAttribLdv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLdouble */ double* @params)
        => glGetVertexAttribLdv(@index, @pname, @params);
    public /* void */ void GetVertexAttribPointerv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* void */ void** @pointer)
        => glGetVertexAttribPointerv(@index, @pname, @pointer);
    public /* void */ void GetVertexAttribdv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLdouble */ double* @params)
        => glGetVertexAttribdv(@index, @pname, @params);
    public /* void */ void GetVertexAttribfv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetVertexAttribfv(@index, @pname, @params);
    public /* void */ void GetVertexAttribiv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetVertexAttribiv(@index, @pname, @params);
    public /* void */ void GetnCompressedTexImage(/* GLenum */ int @target, /* GLint */ int @lod, /* GLsizei */ int @bufSize, /* void */ void* @pixels)
        => glGetnCompressedTexImage(@target, @lod, @bufSize, @pixels);
    public /* void */ void GetnTexImage(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @format, /* GLenum */ int @type, /* GLsizei */ int @bufSize, /* void */ void* @pixels)
        => glGetnTexImage(@target, @level, @format, @type, @bufSize, @pixels);
    public /* void */ void GetnUniformdv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @bufSize, /* GLdouble */ double* @params)
        => glGetnUniformdv(@program, @location, @bufSize, @params);
    public /* void */ void GetnUniformfv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @bufSize, /* GLfloat */ float* @params)
        => glGetnUniformfv(@program, @location, @bufSize, @params);
    public /* void */ void GetnUniformiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @bufSize, /* GLint */ int* @params)
        => glGetnUniformiv(@program, @location, @bufSize, @params);
    public /* void */ void GetnUniformuiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @bufSize, /* GLuint */ uint* @params)
        => glGetnUniformuiv(@program, @location, @bufSize, @params);
    public /* void */ void Hint(/* GLenum */ int @target, /* GLenum */ int @mode)
        => glHint(@target, @mode);
    public /* void */ void InvalidateBufferData(/* GLuint */ uint @buffer)
        => glInvalidateBufferData(@buffer);
    public /* void */ void InvalidateBufferSubData(/* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @length)
        => glInvalidateBufferSubData(@buffer, @offset, @length);
    public /* void */ void InvalidateFramebuffer(/* GLenum */ int @target, /* GLsizei */ int @numAttachments, /* GLenum */ int* @attachments)
        => glInvalidateFramebuffer(@target, @numAttachments, @attachments);
    public /* void */ void InvalidateNamedFramebufferData(/* GLuint */ uint @framebuffer, /* GLsizei */ int @numAttachments, /* GLenum */ int* @attachments)
        => glInvalidateNamedFramebufferData(@framebuffer, @numAttachments, @attachments);
    public /* void */ void InvalidateNamedFramebufferSubData(/* GLuint */ uint @framebuffer, /* GLsizei */ int @numAttachments, /* GLenum */ int* @attachments, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glInvalidateNamedFramebufferSubData(@framebuffer, @numAttachments, @attachments, @x, @y, @width, @height);
    public /* void */ void InvalidateSubFramebuffer(/* GLenum */ int @target, /* GLsizei */ int @numAttachments, /* GLenum */ int* @attachments, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glInvalidateSubFramebuffer(@target, @numAttachments, @attachments, @x, @y, @width, @height);
    public /* void */ void InvalidateTexImage(/* GLuint */ uint @texture, /* GLint */ int @level)
        => glInvalidateTexImage(@texture, @level);
    public /* void */ void InvalidateTexSubImage(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth)
        => glInvalidateTexSubImage(@texture, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth);
    public /* GLboolean */ int IsBuffer(/* GLuint */ uint @buffer)
        => glIsBuffer(@buffer);
    public /* GLboolean */ int IsEnabled(/* GLenum */ int @cap)
        => glIsEnabled(@cap);
    public /* GLboolean */ int IsEnabledi(/* GLenum */ int @target, /* GLuint */ uint @index)
        => glIsEnabledi(@target, @index);
    public /* GLboolean */ int IsFramebuffer(/* GLuint */ uint @framebuffer)
        => glIsFramebuffer(@framebuffer);
    public /* GLboolean */ int IsProgram(/* GLuint */ uint @program)
        => glIsProgram(@program);
    public /* GLboolean */ int IsProgramPipeline(/* GLuint */ uint @pipeline)
        => glIsProgramPipeline(@pipeline);
    public /* GLboolean */ int IsQuery(/* GLuint */ uint @id)
        => glIsQuery(@id);
    public /* GLboolean */ int IsRenderbuffer(/* GLuint */ uint @renderbuffer)
        => glIsRenderbuffer(@renderbuffer);
    public /* GLboolean */ int IsSampler(/* GLuint */ uint @sampler)
        => glIsSampler(@sampler);
    public /* GLboolean */ int IsShader(/* GLuint */ uint @shader)
        => glIsShader(@shader);
    public /* GLboolean */ int IsSync(/* GLsync */ void* @sync)
        => glIsSync(@sync);
    public /* GLboolean */ int IsTexture(/* GLuint */ uint @texture)
        => glIsTexture(@texture);
    public /* GLboolean */ int IsTransformFeedback(/* GLuint */ uint @id)
        => glIsTransformFeedback(@id);
    public /* GLboolean */ int IsVertexArray(/* GLuint */ uint @array)
        => glIsVertexArray(@array);
    public /* void */ void LineWidth(/* GLfloat */ float @width)
        => glLineWidth(@width);
    public /* void */ void LinkProgram(/* GLuint */ uint @program)
        => glLinkProgram(@program);
    public /* void */ void LogicOp(/* GLenum */ int @opcode)
        => glLogicOp(@opcode);
    public /* void */ void* MapBuffer(/* GLenum */ int @target, /* GLenum */ int @access)
        => glMapBuffer(@target, @access);
    public /* void */ void* MapBufferRange(/* GLenum */ int @target, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @length, /* GLbitfield */ int @access)
        => glMapBufferRange(@target, @offset, @length, @access);
    public /* void */ void* MapNamedBuffer(/* GLuint */ uint @buffer, /* GLenum */ int @access)
        => glMapNamedBuffer(@buffer, @access);
    public /* void */ void* MapNamedBufferRange(/* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @length, /* GLbitfield */ int @access)
        => glMapNamedBufferRange(@buffer, @offset, @length, @access);
    public /* void */ void MemoryBarrier(/* GLbitfield */ int @barriers)
        => glMemoryBarrier(@barriers);
    public /* void */ void MemoryBarrierByRegion(/* GLbitfield */ int @barriers)
        => glMemoryBarrierByRegion(@barriers);
    public /* void */ void MinSampleShading(/* GLfloat */ float @value)
        => glMinSampleShading(@value);
    public /* void */ void MultiDrawArrays(/* GLenum */ int @mode, /* GLint */ int* @first, /* GLsizei */ int* @count, /* GLsizei */ int @drawcount)
        => glMultiDrawArrays(@mode, @first, @count, @drawcount);
    public /* void */ void MultiDrawArraysIndirect(/* GLenum */ int @mode, /* void */ void* @indirect, /* GLsizei */ int @drawcount, /* GLsizei */ int @stride)
        => glMultiDrawArraysIndirect(@mode, @indirect, @drawcount, @stride);
    public /* void */ void MultiDrawElements(/* GLenum */ int @mode, /* GLsizei */ int* @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLsizei */ int @drawcount)
        => glMultiDrawElements(@mode, @count, @type, @indices, @drawcount);
    public /* void */ void MultiDrawElementsBaseVertex(/* GLenum */ int @mode, /* GLsizei */ int* @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLsizei */ int @drawcount, /* GLint */ int* @basevertex)
        => glMultiDrawElementsBaseVertex(@mode, @count, @type, @indices, @drawcount, @basevertex);
    public /* void */ void MultiDrawElementsIndirect(/* GLenum */ int @mode, /* GLenum */ int @type, /* void */ void* @indirect, /* GLsizei */ int @drawcount, /* GLsizei */ int @stride)
        => glMultiDrawElementsIndirect(@mode, @type, @indirect, @drawcount, @stride);
    public /* void */ void NamedBufferData(/* GLuint */ uint @buffer, /* GLsizeiptr */ nint @size, /* void */ void* @data, /* GLenum */ int @usage)
        => glNamedBufferData(@buffer, @size, @data, @usage);
    public /* void */ void NamedBufferStorage(/* GLuint */ uint @buffer, /* GLsizeiptr */ nint @size, /* void */ void* @data, /* GLbitfield */ int @flags)
        => glNamedBufferStorage(@buffer, @size, @data, @flags);
    public /* void */ void NamedBufferSubData(/* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size, /* void */ void* @data)
        => glNamedBufferSubData(@buffer, @offset, @size, @data);
    public /* void */ void NamedFramebufferDrawBuffer(/* GLuint */ uint @framebuffer, /* GLenum */ int @buf)
        => glNamedFramebufferDrawBuffer(@framebuffer, @buf);
    public /* void */ void NamedFramebufferDrawBuffers(/* GLuint */ uint @framebuffer, /* GLsizei */ int @n, /* GLenum */ int* @bufs)
        => glNamedFramebufferDrawBuffers(@framebuffer, @n, @bufs);
    public /* void */ void NamedFramebufferParameteri(/* GLuint */ uint @framebuffer, /* GLenum */ int @pname, /* GLint */ int @param)
        => glNamedFramebufferParameteri(@framebuffer, @pname, @param);
    public /* void */ void NamedFramebufferReadBuffer(/* GLuint */ uint @framebuffer, /* GLenum */ int @src)
        => glNamedFramebufferReadBuffer(@framebuffer, @src);
    public /* void */ void NamedFramebufferRenderbuffer(/* GLuint */ uint @framebuffer, /* GLenum */ int @attachment, /* GLenum */ int @renderbuffertarget, /* GLuint */ uint @renderbuffer)
        => glNamedFramebufferRenderbuffer(@framebuffer, @attachment, @renderbuffertarget, @renderbuffer);
    public /* void */ void NamedFramebufferTexture(/* GLuint */ uint @framebuffer, /* GLenum */ int @attachment, /* GLuint */ uint @texture, /* GLint */ int @level)
        => glNamedFramebufferTexture(@framebuffer, @attachment, @texture, @level);
    public /* void */ void NamedFramebufferTextureLayer(/* GLuint */ uint @framebuffer, /* GLenum */ int @attachment, /* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @layer)
        => glNamedFramebufferTextureLayer(@framebuffer, @attachment, @texture, @level, @layer);
    public /* void */ void NamedRenderbufferStorage(/* GLuint */ uint @renderbuffer, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glNamedRenderbufferStorage(@renderbuffer, @internalformat, @width, @height);
    public /* void */ void NamedRenderbufferStorageMultisample(/* GLuint */ uint @renderbuffer, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glNamedRenderbufferStorageMultisample(@renderbuffer, @samples, @internalformat, @width, @height);
    public /* void */ void ObjectLabel(/* GLenum */ int @identifier, /* GLuint */ uint @name, /* GLsizei */ int @length, /* GLchar */ byte* @label)
        => glObjectLabel(@identifier, @name, @length, @label);
    public /* void */ void ObjectPtrLabel(/* void */ void* @ptr, /* GLsizei */ int @length, /* GLchar */ byte* @label)
        => glObjectPtrLabel(@ptr, @length, @label);
    public /* void */ void PatchParameterfv(/* GLenum */ int @pname, /* GLfloat */ float* @values)
        => glPatchParameterfv(@pname, @values);
    public /* void */ void PatchParameteri(/* GLenum */ int @pname, /* GLint */ int @value)
        => glPatchParameteri(@pname, @value);
    public /* void */ void PauseTransformFeedback()
        => glPauseTransformFeedback();
    public /* void */ void PixelStoref(/* GLenum */ int @pname, /* GLfloat */ float @param)
        => glPixelStoref(@pname, @param);
    public /* void */ void PixelStorei(/* GLenum */ int @pname, /* GLint */ int @param)
        => glPixelStorei(@pname, @param);
    public /* void */ void PointParameterf(/* GLenum */ int @pname, /* GLfloat */ float @param)
        => glPointParameterf(@pname, @param);
    public /* void */ void PointParameterfv(/* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glPointParameterfv(@pname, @params);
    public /* void */ void PointParameteri(/* GLenum */ int @pname, /* GLint */ int @param)
        => glPointParameteri(@pname, @param);
    public /* void */ void PointParameteriv(/* GLenum */ int @pname, /* GLint */ int* @params)
        => glPointParameteriv(@pname, @params);
    public /* void */ void PointSize(/* GLfloat */ float @size)
        => glPointSize(@size);
    public /* void */ void PolygonMode(/* GLenum */ int @face, /* GLenum */ int @mode)
        => glPolygonMode(@face, @mode);
    public /* void */ void PolygonOffset(/* GLfloat */ float @factor, /* GLfloat */ float @units)
        => glPolygonOffset(@factor, @units);
    public /* void */ void PopDebugGroup()
        => glPopDebugGroup();
    public /* void */ void PrimitiveRestartIndex(/* GLuint */ uint @index)
        => glPrimitiveRestartIndex(@index);
    public /* void */ void ProgramBinary(/* GLuint */ uint @program, /* GLenum */ int @binaryFormat, /* void */ void* @binary, /* GLsizei */ int @length)
        => glProgramBinary(@program, @binaryFormat, @binary, @length);
    public /* void */ void ProgramParameteri(/* GLuint */ uint @program, /* GLenum */ int @pname, /* GLint */ int @value)
        => glProgramParameteri(@program, @pname, @value);
    public /* void */ void ProgramUniform1d(/* GLuint */ uint @program, /* GLint */ int @location, /* GLdouble */ double @v0)
        => glProgramUniform1d(@program, @location, @v0);
    public /* void */ void ProgramUniform1dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLdouble */ double* @value)
        => glProgramUniform1dv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform1f(/* GLuint */ uint @program, /* GLint */ int @location, /* GLfloat */ float @v0)
        => glProgramUniform1f(@program, @location, @v0);
    public /* void */ void ProgramUniform1fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLfloat */ float* @value)
        => glProgramUniform1fv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform1i(/* GLuint */ uint @program, /* GLint */ int @location, /* GLint */ int @v0)
        => glProgramUniform1i(@program, @location, @v0);
    public /* void */ void ProgramUniform1iv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLint */ int* @value)
        => glProgramUniform1iv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform1ui(/* GLuint */ uint @program, /* GLint */ int @location, /* GLuint */ uint @v0)
        => glProgramUniform1ui(@program, @location, @v0);
    public /* void */ void ProgramUniform1uiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLuint */ uint* @value)
        => glProgramUniform1uiv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform2d(/* GLuint */ uint @program, /* GLint */ int @location, /* GLdouble */ double @v0, /* GLdouble */ double @v1)
        => glProgramUniform2d(@program, @location, @v0, @v1);
    public /* void */ void ProgramUniform2dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLdouble */ double* @value)
        => glProgramUniform2dv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform2f(/* GLuint */ uint @program, /* GLint */ int @location, /* GLfloat */ float @v0, /* GLfloat */ float @v1)
        => glProgramUniform2f(@program, @location, @v0, @v1);
    public /* void */ void ProgramUniform2fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLfloat */ float* @value)
        => glProgramUniform2fv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform2i(/* GLuint */ uint @program, /* GLint */ int @location, /* GLint */ int @v0, /* GLint */ int @v1)
        => glProgramUniform2i(@program, @location, @v0, @v1);
    public /* void */ void ProgramUniform2iv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLint */ int* @value)
        => glProgramUniform2iv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform2ui(/* GLuint */ uint @program, /* GLint */ int @location, /* GLuint */ uint @v0, /* GLuint */ uint @v1)
        => glProgramUniform2ui(@program, @location, @v0, @v1);
    public /* void */ void ProgramUniform2uiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLuint */ uint* @value)
        => glProgramUniform2uiv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform3d(/* GLuint */ uint @program, /* GLint */ int @location, /* GLdouble */ double @v0, /* GLdouble */ double @v1, /* GLdouble */ double @v2)
        => glProgramUniform3d(@program, @location, @v0, @v1, @v2);
    public /* void */ void ProgramUniform3dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLdouble */ double* @value)
        => glProgramUniform3dv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform3f(/* GLuint */ uint @program, /* GLint */ int @location, /* GLfloat */ float @v0, /* GLfloat */ float @v1, /* GLfloat */ float @v2)
        => glProgramUniform3f(@program, @location, @v0, @v1, @v2);
    public /* void */ void ProgramUniform3fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLfloat */ float* @value)
        => glProgramUniform3fv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform3i(/* GLuint */ uint @program, /* GLint */ int @location, /* GLint */ int @v0, /* GLint */ int @v1, /* GLint */ int @v2)
        => glProgramUniform3i(@program, @location, @v0, @v1, @v2);
    public /* void */ void ProgramUniform3iv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLint */ int* @value)
        => glProgramUniform3iv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform3ui(/* GLuint */ uint @program, /* GLint */ int @location, /* GLuint */ uint @v0, /* GLuint */ uint @v1, /* GLuint */ uint @v2)
        => glProgramUniform3ui(@program, @location, @v0, @v1, @v2);
    public /* void */ void ProgramUniform3uiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLuint */ uint* @value)
        => glProgramUniform3uiv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform4d(/* GLuint */ uint @program, /* GLint */ int @location, /* GLdouble */ double @v0, /* GLdouble */ double @v1, /* GLdouble */ double @v2, /* GLdouble */ double @v3)
        => glProgramUniform4d(@program, @location, @v0, @v1, @v2, @v3);
    public /* void */ void ProgramUniform4dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLdouble */ double* @value)
        => glProgramUniform4dv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform4f(/* GLuint */ uint @program, /* GLint */ int @location, /* GLfloat */ float @v0, /* GLfloat */ float @v1, /* GLfloat */ float @v2, /* GLfloat */ float @v3)
        => glProgramUniform4f(@program, @location, @v0, @v1, @v2, @v3);
    public /* void */ void ProgramUniform4fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLfloat */ float* @value)
        => glProgramUniform4fv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform4i(/* GLuint */ uint @program, /* GLint */ int @location, /* GLint */ int @v0, /* GLint */ int @v1, /* GLint */ int @v2, /* GLint */ int @v3)
        => glProgramUniform4i(@program, @location, @v0, @v1, @v2, @v3);
    public /* void */ void ProgramUniform4iv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLint */ int* @value)
        => glProgramUniform4iv(@program, @location, @count, @value);
    public /* void */ void ProgramUniform4ui(/* GLuint */ uint @program, /* GLint */ int @location, /* GLuint */ uint @v0, /* GLuint */ uint @v1, /* GLuint */ uint @v2, /* GLuint */ uint @v3)
        => glProgramUniform4ui(@program, @location, @v0, @v1, @v2, @v3);
    public /* void */ void ProgramUniform4uiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLuint */ uint* @value)
        => glProgramUniform4uiv(@program, @location, @count, @value);
    public /* void */ void ProgramUniformMatrix2dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glProgramUniformMatrix2dv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix2fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix2fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix2x3dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glProgramUniformMatrix2x3dv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix2x3fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix2x3fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix2x4dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glProgramUniformMatrix2x4dv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix2x4fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix2x4fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix3dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glProgramUniformMatrix3dv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix3fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix3fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix3x2dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glProgramUniformMatrix3x2dv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix3x2fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix3x2fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix3x4dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glProgramUniformMatrix3x4dv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix3x4fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix3x4fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix4dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glProgramUniformMatrix4dv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix4fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix4fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix4x2dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glProgramUniformMatrix4x2dv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix4x2fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix4x2fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix4x3dv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glProgramUniformMatrix4x3dv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix4x3fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix4x3fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProvokingVertex(/* GLenum */ int @mode)
        => glProvokingVertex(@mode);
    public /* void */ void PushDebugGroup(/* GLenum */ int @source, /* GLuint */ uint @id, /* GLsizei */ int @length, /* GLchar */ byte* @message)
        => glPushDebugGroup(@source, @id, @length, @message);
    public /* void */ void QueryCounter(/* GLuint */ uint @id, /* GLenum */ int @target)
        => glQueryCounter(@id, @target);
    public /* void */ void ReadBuffer(/* GLenum */ int @src)
        => glReadBuffer(@src);
    public /* void */ void ReadPixels(/* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glReadPixels(@x, @y, @width, @height, @format, @type, @pixels);
    public /* void */ void ReadnPixels(/* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLenum */ int @type, /* GLsizei */ int @bufSize, /* void */ void* @data)
        => glReadnPixels(@x, @y, @width, @height, @format, @type, @bufSize, @data);
    public /* void */ void ReleaseShaderCompiler()
        => glReleaseShaderCompiler();
    public /* void */ void RenderbufferStorage(/* GLenum */ int @target, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glRenderbufferStorage(@target, @internalformat, @width, @height);
    public /* void */ void RenderbufferStorageMultisample(/* GLenum */ int @target, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glRenderbufferStorageMultisample(@target, @samples, @internalformat, @width, @height);
    public /* void */ void ResumeTransformFeedback()
        => glResumeTransformFeedback();
    public /* void */ void SampleCoverage(/* GLfloat */ float @value, /* GLboolean */ int @invert)
        => glSampleCoverage(@value, @invert);
    public /* void */ void SampleMaski(/* GLuint */ uint @maskNumber, /* GLbitfield */ int @mask)
        => glSampleMaski(@maskNumber, @mask);
    public /* void */ void SamplerParameterIiv(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLint */ int* @param)
        => glSamplerParameterIiv(@sampler, @pname, @param);
    public /* void */ void SamplerParameterIuiv(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLuint */ uint* @param)
        => glSamplerParameterIuiv(@sampler, @pname, @param);
    public /* void */ void SamplerParameterf(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLfloat */ float @param)
        => glSamplerParameterf(@sampler, @pname, @param);
    public /* void */ void SamplerParameterfv(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLfloat */ float* @param)
        => glSamplerParameterfv(@sampler, @pname, @param);
    public /* void */ void SamplerParameteri(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLint */ int @param)
        => glSamplerParameteri(@sampler, @pname, @param);
    public /* void */ void SamplerParameteriv(/* GLuint */ uint @sampler, /* GLenum */ int @pname, /* GLint */ int* @param)
        => glSamplerParameteriv(@sampler, @pname, @param);
    public /* void */ void Scissor(/* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glScissor(@x, @y, @width, @height);
    public /* void */ void ScissorArrayv(/* GLuint */ uint @first, /* GLsizei */ int @count, /* GLint */ int* @v)
        => glScissorArrayv(@first, @count, @v);
    public /* void */ void ScissorIndexed(/* GLuint */ uint @index, /* GLint */ int @left, /* GLint */ int @bottom, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glScissorIndexed(@index, @left, @bottom, @width, @height);
    public /* void */ void ScissorIndexedv(/* GLuint */ uint @index, /* GLint */ int* @v)
        => glScissorIndexedv(@index, @v);
    public /* void */ void ShaderBinary(/* GLsizei */ int @count, /* GLuint */ uint* @shaders, /* GLenum */ int @binaryFormat, /* void */ void* @binary, /* GLsizei */ int @length)
        => glShaderBinary(@count, @shaders, @binaryFormat, @binary, @length);
    public /* void */ void ShaderSource(/* GLuint */ uint @shader, /* GLsizei */ int @count, /* GLchar */ byte* @string, /* GLint */ int* @length)
        => glShaderSource(@shader, @count, @string, @length);
    public /* void */ void ShaderStorageBlockBinding(/* GLuint */ uint @program, /* GLuint */ uint @storageBlockIndex, /* GLuint */ uint @storageBlockBinding)
        => glShaderStorageBlockBinding(@program, @storageBlockIndex, @storageBlockBinding);
    public /* void */ void StencilFunc(/* GLenum */ int @func, /* GLint */ int @ref, /* GLuint */ uint @mask)
        => glStencilFunc(@func, @ref, @mask);
    public /* void */ void StencilFuncSeparate(/* GLenum */ int @face, /* GLenum */ int @func, /* GLint */ int @ref, /* GLuint */ uint @mask)
        => glStencilFuncSeparate(@face, @func, @ref, @mask);
    public /* void */ void StencilMask(/* GLuint */ uint @mask)
        => glStencilMask(@mask);
    public /* void */ void StencilMaskSeparate(/* GLenum */ int @face, /* GLuint */ uint @mask)
        => glStencilMaskSeparate(@face, @mask);
    public /* void */ void StencilOp(/* GLenum */ int @fail, /* GLenum */ int @zfail, /* GLenum */ int @zpass)
        => glStencilOp(@fail, @zfail, @zpass);
    public /* void */ void StencilOpSeparate(/* GLenum */ int @face, /* GLenum */ int @sfail, /* GLenum */ int @dpfail, /* GLenum */ int @dppass)
        => glStencilOpSeparate(@face, @sfail, @dpfail, @dppass);
    public /* void */ void TexBuffer(/* GLenum */ int @target, /* GLenum */ int @internalformat, /* GLuint */ uint @buffer)
        => glTexBuffer(@target, @internalformat, @buffer);
    public /* void */ void TexBufferRange(/* GLenum */ int @target, /* GLenum */ int @internalformat, /* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size)
        => glTexBufferRange(@target, @internalformat, @buffer, @offset, @size);
    public /* void */ void TexImage1D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @internalformat, /* GLsizei */ int @width, /* GLint */ int @border, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexImage1D(@target, @level, @internalformat, @width, @border, @format, @type, @pixels);
    public /* void */ void TexImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLint */ int @border, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexImage2D(@target, @level, @internalformat, @width, @height, @border, @format, @type, @pixels);
    public /* void */ void TexImage2DMultisample(/* GLenum */ int @target, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLboolean */ int @fixedsamplelocations)
        => glTexImage2DMultisample(@target, @samples, @internalformat, @width, @height, @fixedsamplelocations);
    public /* void */ void TexImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLint */ int @border, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexImage3D(@target, @level, @internalformat, @width, @height, @depth, @border, @format, @type, @pixels);
    public /* void */ void TexImage3DMultisample(/* GLenum */ int @target, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLboolean */ int @fixedsamplelocations)
        => glTexImage3DMultisample(@target, @samples, @internalformat, @width, @height, @depth, @fixedsamplelocations);
    public /* void */ void TexParameterIiv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glTexParameterIiv(@target, @pname, @params);
    public /* void */ void TexParameterIuiv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLuint */ uint* @params)
        => glTexParameterIuiv(@target, @pname, @params);
    public /* void */ void TexParameterf(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfloat */ float @param)
        => glTexParameterf(@target, @pname, @param);
    public /* void */ void TexParameterfv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glTexParameterfv(@target, @pname, @params);
    public /* void */ void TexParameteri(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int @param)
        => glTexParameteri(@target, @pname, @param);
    public /* void */ void TexParameteriv(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glTexParameteriv(@target, @pname, @params);
    public /* void */ void TexStorage1D(/* GLenum */ int @target, /* GLsizei */ int @levels, /* GLenum */ int @internalformat, /* GLsizei */ int @width)
        => glTexStorage1D(@target, @levels, @internalformat, @width);
    public /* void */ void TexStorage2D(/* GLenum */ int @target, /* GLsizei */ int @levels, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glTexStorage2D(@target, @levels, @internalformat, @width, @height);
    public /* void */ void TexStorage2DMultisample(/* GLenum */ int @target, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLboolean */ int @fixedsamplelocations)
        => glTexStorage2DMultisample(@target, @samples, @internalformat, @width, @height, @fixedsamplelocations);
    public /* void */ void TexStorage3D(/* GLenum */ int @target, /* GLsizei */ int @levels, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth)
        => glTexStorage3D(@target, @levels, @internalformat, @width, @height, @depth);
    public /* void */ void TexStorage3DMultisample(/* GLenum */ int @target, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLboolean */ int @fixedsamplelocations)
        => glTexStorage3DMultisample(@target, @samples, @internalformat, @width, @height, @depth, @fixedsamplelocations);
    public /* void */ void TexSubImage1D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLsizei */ int @width, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexSubImage1D(@target, @level, @xoffset, @width, @format, @type, @pixels);
    public /* void */ void TexSubImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexSubImage2D(@target, @level, @xoffset, @yoffset, @width, @height, @format, @type, @pixels);
    public /* void */ void TexSubImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexSubImage3D(@target, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth, @format, @type, @pixels);
    public /* void */ void TextureBarrier()
        => glTextureBarrier();
    public /* void */ void TextureBuffer(/* GLuint */ uint @texture, /* GLenum */ int @internalformat, /* GLuint */ uint @buffer)
        => glTextureBuffer(@texture, @internalformat, @buffer);
    public /* void */ void TextureBufferRange(/* GLuint */ uint @texture, /* GLenum */ int @internalformat, /* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size)
        => glTextureBufferRange(@texture, @internalformat, @buffer, @offset, @size);
    public /* void */ void TextureParameterIiv(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glTextureParameterIiv(@texture, @pname, @params);
    public /* void */ void TextureParameterIuiv(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLuint */ uint* @params)
        => glTextureParameterIuiv(@texture, @pname, @params);
    public /* void */ void TextureParameterf(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLfloat */ float @param)
        => glTextureParameterf(@texture, @pname, @param);
    public /* void */ void TextureParameterfv(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLfloat */ float* @param)
        => glTextureParameterfv(@texture, @pname, @param);
    public /* void */ void TextureParameteri(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLint */ int @param)
        => glTextureParameteri(@texture, @pname, @param);
    public /* void */ void TextureParameteriv(/* GLuint */ uint @texture, /* GLenum */ int @pname, /* GLint */ int* @param)
        => glTextureParameteriv(@texture, @pname, @param);
    public /* void */ void TextureStorage1D(/* GLuint */ uint @texture, /* GLsizei */ int @levels, /* GLenum */ int @internalformat, /* GLsizei */ int @width)
        => glTextureStorage1D(@texture, @levels, @internalformat, @width);
    public /* void */ void TextureStorage2D(/* GLuint */ uint @texture, /* GLsizei */ int @levels, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glTextureStorage2D(@texture, @levels, @internalformat, @width, @height);
    public /* void */ void TextureStorage2DMultisample(/* GLuint */ uint @texture, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLboolean */ int @fixedsamplelocations)
        => glTextureStorage2DMultisample(@texture, @samples, @internalformat, @width, @height, @fixedsamplelocations);
    public /* void */ void TextureStorage3D(/* GLuint */ uint @texture, /* GLsizei */ int @levels, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth)
        => glTextureStorage3D(@texture, @levels, @internalformat, @width, @height, @depth);
    public /* void */ void TextureStorage3DMultisample(/* GLuint */ uint @texture, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLboolean */ int @fixedsamplelocations)
        => glTextureStorage3DMultisample(@texture, @samples, @internalformat, @width, @height, @depth, @fixedsamplelocations);
    public /* void */ void TextureSubImage1D(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLsizei */ int @width, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTextureSubImage1D(@texture, @level, @xoffset, @width, @format, @type, @pixels);
    public /* void */ void TextureSubImage2D(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTextureSubImage2D(@texture, @level, @xoffset, @yoffset, @width, @height, @format, @type, @pixels);
    public /* void */ void TextureSubImage3D(/* GLuint */ uint @texture, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTextureSubImage3D(@texture, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth, @format, @type, @pixels);
    public /* void */ void TextureView(/* GLuint */ uint @texture, /* GLenum */ int @target, /* GLuint */ uint @origtexture, /* GLenum */ int @internalformat, /* GLuint */ uint @minlevel, /* GLuint */ uint @numlevels, /* GLuint */ uint @minlayer, /* GLuint */ uint @numlayers)
        => glTextureView(@texture, @target, @origtexture, @internalformat, @minlevel, @numlevels, @minlayer, @numlayers);
    public /* void */ void TransformFeedbackBufferBase(/* GLuint */ uint @xfb, /* GLuint */ uint @index, /* GLuint */ uint @buffer)
        => glTransformFeedbackBufferBase(@xfb, @index, @buffer);
    public /* void */ void TransformFeedbackBufferRange(/* GLuint */ uint @xfb, /* GLuint */ uint @index, /* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size)
        => glTransformFeedbackBufferRange(@xfb, @index, @buffer, @offset, @size);
    public /* void */ void TransformFeedbackVaryings(/* GLuint */ uint @program, /* GLsizei */ int @count, /* GLchar */ byte* @varyings, /* GLenum */ int @bufferMode)
        => glTransformFeedbackVaryings(@program, @count, @varyings, @bufferMode);
    public /* void */ void Uniform1d(/* GLint */ int @location, /* GLdouble */ double @x)
        => glUniform1d(@location, @x);
    public /* void */ void Uniform1dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLdouble */ double* @value)
        => glUniform1dv(@location, @count, @value);
    public /* void */ void Uniform1f(/* GLint */ int @location, /* GLfloat */ float @v0)
        => glUniform1f(@location, @v0);
    public /* void */ void Uniform1fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLfloat */ float* @value)
        => glUniform1fv(@location, @count, @value);
    public /* void */ void Uniform1i(/* GLint */ int @location, /* GLint */ int @v0)
        => glUniform1i(@location, @v0);
    public /* void */ void Uniform1iv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLint */ int* @value)
        => glUniform1iv(@location, @count, @value);
    public /* void */ void Uniform1ui(/* GLint */ int @location, /* GLuint */ uint @v0)
        => glUniform1ui(@location, @v0);
    public /* void */ void Uniform1uiv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLuint */ uint* @value)
        => glUniform1uiv(@location, @count, @value);
    public /* void */ void Uniform2d(/* GLint */ int @location, /* GLdouble */ double @x, /* GLdouble */ double @y)
        => glUniform2d(@location, @x, @y);
    public /* void */ void Uniform2dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLdouble */ double* @value)
        => glUniform2dv(@location, @count, @value);
    public /* void */ void Uniform2f(/* GLint */ int @location, /* GLfloat */ float @v0, /* GLfloat */ float @v1)
        => glUniform2f(@location, @v0, @v1);
    public /* void */ void Uniform2fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLfloat */ float* @value)
        => glUniform2fv(@location, @count, @value);
    public /* void */ void Uniform2i(/* GLint */ int @location, /* GLint */ int @v0, /* GLint */ int @v1)
        => glUniform2i(@location, @v0, @v1);
    public /* void */ void Uniform2iv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLint */ int* @value)
        => glUniform2iv(@location, @count, @value);
    public /* void */ void Uniform2ui(/* GLint */ int @location, /* GLuint */ uint @v0, /* GLuint */ uint @v1)
        => glUniform2ui(@location, @v0, @v1);
    public /* void */ void Uniform2uiv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLuint */ uint* @value)
        => glUniform2uiv(@location, @count, @value);
    public /* void */ void Uniform3d(/* GLint */ int @location, /* GLdouble */ double @x, /* GLdouble */ double @y, /* GLdouble */ double @z)
        => glUniform3d(@location, @x, @y, @z);
    public /* void */ void Uniform3dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLdouble */ double* @value)
        => glUniform3dv(@location, @count, @value);
    public /* void */ void Uniform3f(/* GLint */ int @location, /* GLfloat */ float @v0, /* GLfloat */ float @v1, /* GLfloat */ float @v2)
        => glUniform3f(@location, @v0, @v1, @v2);
    public /* void */ void Uniform3fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLfloat */ float* @value)
        => glUniform3fv(@location, @count, @value);
    public /* void */ void Uniform3i(/* GLint */ int @location, /* GLint */ int @v0, /* GLint */ int @v1, /* GLint */ int @v2)
        => glUniform3i(@location, @v0, @v1, @v2);
    public /* void */ void Uniform3iv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLint */ int* @value)
        => glUniform3iv(@location, @count, @value);
    public /* void */ void Uniform3ui(/* GLint */ int @location, /* GLuint */ uint @v0, /* GLuint */ uint @v1, /* GLuint */ uint @v2)
        => glUniform3ui(@location, @v0, @v1, @v2);
    public /* void */ void Uniform3uiv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLuint */ uint* @value)
        => glUniform3uiv(@location, @count, @value);
    public /* void */ void Uniform4d(/* GLint */ int @location, /* GLdouble */ double @x, /* GLdouble */ double @y, /* GLdouble */ double @z, /* GLdouble */ double @w)
        => glUniform4d(@location, @x, @y, @z, @w);
    public /* void */ void Uniform4dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLdouble */ double* @value)
        => glUniform4dv(@location, @count, @value);
    public /* void */ void Uniform4f(/* GLint */ int @location, /* GLfloat */ float @v0, /* GLfloat */ float @v1, /* GLfloat */ float @v2, /* GLfloat */ float @v3)
        => glUniform4f(@location, @v0, @v1, @v2, @v3);
    public /* void */ void Uniform4fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLfloat */ float* @value)
        => glUniform4fv(@location, @count, @value);
    public /* void */ void Uniform4i(/* GLint */ int @location, /* GLint */ int @v0, /* GLint */ int @v1, /* GLint */ int @v2, /* GLint */ int @v3)
        => glUniform4i(@location, @v0, @v1, @v2, @v3);
    public /* void */ void Uniform4iv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLint */ int* @value)
        => glUniform4iv(@location, @count, @value);
    public /* void */ void Uniform4ui(/* GLint */ int @location, /* GLuint */ uint @v0, /* GLuint */ uint @v1, /* GLuint */ uint @v2, /* GLuint */ uint @v3)
        => glUniform4ui(@location, @v0, @v1, @v2, @v3);
    public /* void */ void Uniform4uiv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLuint */ uint* @value)
        => glUniform4uiv(@location, @count, @value);
    public /* void */ void UniformBlockBinding(/* GLuint */ uint @program, /* GLuint */ uint @uniformBlockIndex, /* GLuint */ uint @uniformBlockBinding)
        => glUniformBlockBinding(@program, @uniformBlockIndex, @uniformBlockBinding);
    public /* void */ void UniformMatrix2dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glUniformMatrix2dv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix2fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix2fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix2x3dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glUniformMatrix2x3dv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix2x3fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix2x3fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix2x4dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glUniformMatrix2x4dv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix2x4fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix2x4fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix3dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glUniformMatrix3dv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix3fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix3fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix3x2dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glUniformMatrix3x2dv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix3x2fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix3x2fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix3x4dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glUniformMatrix3x4dv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix3x4fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix3x4fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix4dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glUniformMatrix4dv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix4fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix4fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix4x2dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glUniformMatrix4x2dv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix4x2fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix4x2fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix4x3dv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLdouble */ double* @value)
        => glUniformMatrix4x3dv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix4x3fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix4x3fv(@location, @count, @transpose, @value);
    public /* void */ void UniformSubroutinesuiv(/* GLenum */ int @shadertype, /* GLsizei */ int @count, /* GLuint */ uint* @indices)
        => glUniformSubroutinesuiv(@shadertype, @count, @indices);
    public /* GLboolean */ int UnmapBuffer(/* GLenum */ int @target)
        => glUnmapBuffer(@target);
    public /* GLboolean */ int UnmapNamedBuffer(/* GLuint */ uint @buffer)
        => glUnmapNamedBuffer(@buffer);
    public /* void */ void UseProgram(/* GLuint */ uint @program)
        => glUseProgram(@program);
    public /* void */ void UseProgramStages(/* GLuint */ uint @pipeline, /* GLbitfield */ int @stages, /* GLuint */ uint @program)
        => glUseProgramStages(@pipeline, @stages, @program);
    public /* void */ void ValidateProgram(/* GLuint */ uint @program)
        => glValidateProgram(@program);
    public /* void */ void ValidateProgramPipeline(/* GLuint */ uint @pipeline)
        => glValidateProgramPipeline(@pipeline);
    public /* void */ void VertexArrayAttribBinding(/* GLuint */ uint @vaobj, /* GLuint */ uint @attribindex, /* GLuint */ uint @bindingindex)
        => glVertexArrayAttribBinding(@vaobj, @attribindex, @bindingindex);
    public /* void */ void VertexArrayAttribFormat(/* GLuint */ uint @vaobj, /* GLuint */ uint @attribindex, /* GLint */ int @size, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint @relativeoffset)
        => glVertexArrayAttribFormat(@vaobj, @attribindex, @size, @type, @normalized, @relativeoffset);
    public /* void */ void VertexArrayAttribIFormat(/* GLuint */ uint @vaobj, /* GLuint */ uint @attribindex, /* GLint */ int @size, /* GLenum */ int @type, /* GLuint */ uint @relativeoffset)
        => glVertexArrayAttribIFormat(@vaobj, @attribindex, @size, @type, @relativeoffset);
    public /* void */ void VertexArrayAttribLFormat(/* GLuint */ uint @vaobj, /* GLuint */ uint @attribindex, /* GLint */ int @size, /* GLenum */ int @type, /* GLuint */ uint @relativeoffset)
        => glVertexArrayAttribLFormat(@vaobj, @attribindex, @size, @type, @relativeoffset);
    public /* void */ void VertexArrayBindingDivisor(/* GLuint */ uint @vaobj, /* GLuint */ uint @bindingindex, /* GLuint */ uint @divisor)
        => glVertexArrayBindingDivisor(@vaobj, @bindingindex, @divisor);
    public /* void */ void VertexArrayElementBuffer(/* GLuint */ uint @vaobj, /* GLuint */ uint @buffer)
        => glVertexArrayElementBuffer(@vaobj, @buffer);
    public /* void */ void VertexArrayVertexBuffer(/* GLuint */ uint @vaobj, /* GLuint */ uint @bindingindex, /* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizei */ int @stride)
        => glVertexArrayVertexBuffer(@vaobj, @bindingindex, @buffer, @offset, @stride);
    public /* void */ void VertexArrayVertexBuffers(/* GLuint */ uint @vaobj, /* GLuint */ uint @first, /* GLsizei */ int @count, /* GLuint */ uint* @buffers, /* GLintptr */ nint* @offsets, /* GLsizei */ int* @strides)
        => glVertexArrayVertexBuffers(@vaobj, @first, @count, @buffers, @offsets, @strides);
    public /* void */ void VertexAttrib1d(/* GLuint */ uint @index, /* GLdouble */ double @x)
        => glVertexAttrib1d(@index, @x);
    public /* void */ void VertexAttrib1dv(/* GLuint */ uint @index, /* GLdouble */ double* @v)
        => glVertexAttrib1dv(@index, @v);
    public /* void */ void VertexAttrib1f(/* GLuint */ uint @index, /* GLfloat */ float @x)
        => glVertexAttrib1f(@index, @x);
    public /* void */ void VertexAttrib1fv(/* GLuint */ uint @index, /* GLfloat */ float* @v)
        => glVertexAttrib1fv(@index, @v);
    public /* void */ void VertexAttrib1s(/* GLuint */ uint @index, /* GLshort */ short @x)
        => glVertexAttrib1s(@index, @x);
    public /* void */ void VertexAttrib1sv(/* GLuint */ uint @index, /* GLshort */ short* @v)
        => glVertexAttrib1sv(@index, @v);
    public /* void */ void VertexAttrib2d(/* GLuint */ uint @index, /* GLdouble */ double @x, /* GLdouble */ double @y)
        => glVertexAttrib2d(@index, @x, @y);
    public /* void */ void VertexAttrib2dv(/* GLuint */ uint @index, /* GLdouble */ double* @v)
        => glVertexAttrib2dv(@index, @v);
    public /* void */ void VertexAttrib2f(/* GLuint */ uint @index, /* GLfloat */ float @x, /* GLfloat */ float @y)
        => glVertexAttrib2f(@index, @x, @y);
    public /* void */ void VertexAttrib2fv(/* GLuint */ uint @index, /* GLfloat */ float* @v)
        => glVertexAttrib2fv(@index, @v);
    public /* void */ void VertexAttrib2s(/* GLuint */ uint @index, /* GLshort */ short @x, /* GLshort */ short @y)
        => glVertexAttrib2s(@index, @x, @y);
    public /* void */ void VertexAttrib2sv(/* GLuint */ uint @index, /* GLshort */ short* @v)
        => glVertexAttrib2sv(@index, @v);
    public /* void */ void VertexAttrib3d(/* GLuint */ uint @index, /* GLdouble */ double @x, /* GLdouble */ double @y, /* GLdouble */ double @z)
        => glVertexAttrib3d(@index, @x, @y, @z);
    public /* void */ void VertexAttrib3dv(/* GLuint */ uint @index, /* GLdouble */ double* @v)
        => glVertexAttrib3dv(@index, @v);
    public /* void */ void VertexAttrib3f(/* GLuint */ uint @index, /* GLfloat */ float @x, /* GLfloat */ float @y, /* GLfloat */ float @z)
        => glVertexAttrib3f(@index, @x, @y, @z);
    public /* void */ void VertexAttrib3fv(/* GLuint */ uint @index, /* GLfloat */ float* @v)
        => glVertexAttrib3fv(@index, @v);
    public /* void */ void VertexAttrib3s(/* GLuint */ uint @index, /* GLshort */ short @x, /* GLshort */ short @y, /* GLshort */ short @z)
        => glVertexAttrib3s(@index, @x, @y, @z);
    public /* void */ void VertexAttrib3sv(/* GLuint */ uint @index, /* GLshort */ short* @v)
        => glVertexAttrib3sv(@index, @v);
    public /* void */ void VertexAttrib4Nbv(/* GLuint */ uint @index, /* GLbyte */ byte* @v)
        => glVertexAttrib4Nbv(@index, @v);
    public /* void */ void VertexAttrib4Niv(/* GLuint */ uint @index, /* GLint */ int* @v)
        => glVertexAttrib4Niv(@index, @v);
    public /* void */ void VertexAttrib4Nsv(/* GLuint */ uint @index, /* GLshort */ short* @v)
        => glVertexAttrib4Nsv(@index, @v);
    public /* void */ void VertexAttrib4Nub(/* GLuint */ uint @index, /* GLubyte */ byte @x, /* GLubyte */ byte @y, /* GLubyte */ byte @z, /* GLubyte */ byte @w)
        => glVertexAttrib4Nub(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttrib4Nubv(/* GLuint */ uint @index, /* GLubyte */ byte* @v)
        => glVertexAttrib4Nubv(@index, @v);
    public /* void */ void VertexAttrib4Nuiv(/* GLuint */ uint @index, /* GLuint */ uint* @v)
        => glVertexAttrib4Nuiv(@index, @v);
    public /* void */ void VertexAttrib4Nusv(/* GLuint */ uint @index, /* GLushort */ ushort* @v)
        => glVertexAttrib4Nusv(@index, @v);
    public /* void */ void VertexAttrib4bv(/* GLuint */ uint @index, /* GLbyte */ byte* @v)
        => glVertexAttrib4bv(@index, @v);
    public /* void */ void VertexAttrib4d(/* GLuint */ uint @index, /* GLdouble */ double @x, /* GLdouble */ double @y, /* GLdouble */ double @z, /* GLdouble */ double @w)
        => glVertexAttrib4d(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttrib4dv(/* GLuint */ uint @index, /* GLdouble */ double* @v)
        => glVertexAttrib4dv(@index, @v);
    public /* void */ void VertexAttrib4f(/* GLuint */ uint @index, /* GLfloat */ float @x, /* GLfloat */ float @y, /* GLfloat */ float @z, /* GLfloat */ float @w)
        => glVertexAttrib4f(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttrib4fv(/* GLuint */ uint @index, /* GLfloat */ float* @v)
        => glVertexAttrib4fv(@index, @v);
    public /* void */ void VertexAttrib4iv(/* GLuint */ uint @index, /* GLint */ int* @v)
        => glVertexAttrib4iv(@index, @v);
    public /* void */ void VertexAttrib4s(/* GLuint */ uint @index, /* GLshort */ short @x, /* GLshort */ short @y, /* GLshort */ short @z, /* GLshort */ short @w)
        => glVertexAttrib4s(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttrib4sv(/* GLuint */ uint @index, /* GLshort */ short* @v)
        => glVertexAttrib4sv(@index, @v);
    public /* void */ void VertexAttrib4ubv(/* GLuint */ uint @index, /* GLubyte */ byte* @v)
        => glVertexAttrib4ubv(@index, @v);
    public /* void */ void VertexAttrib4uiv(/* GLuint */ uint @index, /* GLuint */ uint* @v)
        => glVertexAttrib4uiv(@index, @v);
    public /* void */ void VertexAttrib4usv(/* GLuint */ uint @index, /* GLushort */ ushort* @v)
        => glVertexAttrib4usv(@index, @v);
    public /* void */ void VertexAttribBinding(/* GLuint */ uint @attribindex, /* GLuint */ uint @bindingindex)
        => glVertexAttribBinding(@attribindex, @bindingindex);
    public /* void */ void VertexAttribDivisor(/* GLuint */ uint @index, /* GLuint */ uint @divisor)
        => glVertexAttribDivisor(@index, @divisor);
    public /* void */ void VertexAttribFormat(/* GLuint */ uint @attribindex, /* GLint */ int @size, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint @relativeoffset)
        => glVertexAttribFormat(@attribindex, @size, @type, @normalized, @relativeoffset);
    public /* void */ void VertexAttribI1i(/* GLuint */ uint @index, /* GLint */ int @x)
        => glVertexAttribI1i(@index, @x);
    public /* void */ void VertexAttribI1iv(/* GLuint */ uint @index, /* GLint */ int* @v)
        => glVertexAttribI1iv(@index, @v);
    public /* void */ void VertexAttribI1ui(/* GLuint */ uint @index, /* GLuint */ uint @x)
        => glVertexAttribI1ui(@index, @x);
    public /* void */ void VertexAttribI1uiv(/* GLuint */ uint @index, /* GLuint */ uint* @v)
        => glVertexAttribI1uiv(@index, @v);
    public /* void */ void VertexAttribI2i(/* GLuint */ uint @index, /* GLint */ int @x, /* GLint */ int @y)
        => glVertexAttribI2i(@index, @x, @y);
    public /* void */ void VertexAttribI2iv(/* GLuint */ uint @index, /* GLint */ int* @v)
        => glVertexAttribI2iv(@index, @v);
    public /* void */ void VertexAttribI2ui(/* GLuint */ uint @index, /* GLuint */ uint @x, /* GLuint */ uint @y)
        => glVertexAttribI2ui(@index, @x, @y);
    public /* void */ void VertexAttribI2uiv(/* GLuint */ uint @index, /* GLuint */ uint* @v)
        => glVertexAttribI2uiv(@index, @v);
    public /* void */ void VertexAttribI3i(/* GLuint */ uint @index, /* GLint */ int @x, /* GLint */ int @y, /* GLint */ int @z)
        => glVertexAttribI3i(@index, @x, @y, @z);
    public /* void */ void VertexAttribI3iv(/* GLuint */ uint @index, /* GLint */ int* @v)
        => glVertexAttribI3iv(@index, @v);
    public /* void */ void VertexAttribI3ui(/* GLuint */ uint @index, /* GLuint */ uint @x, /* GLuint */ uint @y, /* GLuint */ uint @z)
        => glVertexAttribI3ui(@index, @x, @y, @z);
    public /* void */ void VertexAttribI3uiv(/* GLuint */ uint @index, /* GLuint */ uint* @v)
        => glVertexAttribI3uiv(@index, @v);
    public /* void */ void VertexAttribI4bv(/* GLuint */ uint @index, /* GLbyte */ byte* @v)
        => glVertexAttribI4bv(@index, @v);
    public /* void */ void VertexAttribI4i(/* GLuint */ uint @index, /* GLint */ int @x, /* GLint */ int @y, /* GLint */ int @z, /* GLint */ int @w)
        => glVertexAttribI4i(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttribI4iv(/* GLuint */ uint @index, /* GLint */ int* @v)
        => glVertexAttribI4iv(@index, @v);
    public /* void */ void VertexAttribI4sv(/* GLuint */ uint @index, /* GLshort */ short* @v)
        => glVertexAttribI4sv(@index, @v);
    public /* void */ void VertexAttribI4ubv(/* GLuint */ uint @index, /* GLubyte */ byte* @v)
        => glVertexAttribI4ubv(@index, @v);
    public /* void */ void VertexAttribI4ui(/* GLuint */ uint @index, /* GLuint */ uint @x, /* GLuint */ uint @y, /* GLuint */ uint @z, /* GLuint */ uint @w)
        => glVertexAttribI4ui(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttribI4uiv(/* GLuint */ uint @index, /* GLuint */ uint* @v)
        => glVertexAttribI4uiv(@index, @v);
    public /* void */ void VertexAttribI4usv(/* GLuint */ uint @index, /* GLushort */ ushort* @v)
        => glVertexAttribI4usv(@index, @v);
    public /* void */ void VertexAttribIFormat(/* GLuint */ uint @attribindex, /* GLint */ int @size, /* GLenum */ int @type, /* GLuint */ uint @relativeoffset)
        => glVertexAttribIFormat(@attribindex, @size, @type, @relativeoffset);
    public /* void */ void VertexAttribIPointer(/* GLuint */ uint @index, /* GLint */ int @size, /* GLenum */ int @type, /* GLsizei */ int @stride, /* void */ void* @pointer)
        => glVertexAttribIPointer(@index, @size, @type, @stride, @pointer);
    public /* void */ void VertexAttribL1d(/* GLuint */ uint @index, /* GLdouble */ double @x)
        => glVertexAttribL1d(@index, @x);
    public /* void */ void VertexAttribL1dv(/* GLuint */ uint @index, /* GLdouble */ double* @v)
        => glVertexAttribL1dv(@index, @v);
    public /* void */ void VertexAttribL2d(/* GLuint */ uint @index, /* GLdouble */ double @x, /* GLdouble */ double @y)
        => glVertexAttribL2d(@index, @x, @y);
    public /* void */ void VertexAttribL2dv(/* GLuint */ uint @index, /* GLdouble */ double* @v)
        => glVertexAttribL2dv(@index, @v);
    public /* void */ void VertexAttribL3d(/* GLuint */ uint @index, /* GLdouble */ double @x, /* GLdouble */ double @y, /* GLdouble */ double @z)
        => glVertexAttribL3d(@index, @x, @y, @z);
    public /* void */ void VertexAttribL3dv(/* GLuint */ uint @index, /* GLdouble */ double* @v)
        => glVertexAttribL3dv(@index, @v);
    public /* void */ void VertexAttribL4d(/* GLuint */ uint @index, /* GLdouble */ double @x, /* GLdouble */ double @y, /* GLdouble */ double @z, /* GLdouble */ double @w)
        => glVertexAttribL4d(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttribL4dv(/* GLuint */ uint @index, /* GLdouble */ double* @v)
        => glVertexAttribL4dv(@index, @v);
    public /* void */ void VertexAttribLFormat(/* GLuint */ uint @attribindex, /* GLint */ int @size, /* GLenum */ int @type, /* GLuint */ uint @relativeoffset)
        => glVertexAttribLFormat(@attribindex, @size, @type, @relativeoffset);
    public /* void */ void VertexAttribLPointer(/* GLuint */ uint @index, /* GLint */ int @size, /* GLenum */ int @type, /* GLsizei */ int @stride, /* void */ void* @pointer)
        => glVertexAttribLPointer(@index, @size, @type, @stride, @pointer);
    public /* void */ void VertexAttribP1ui(/* GLuint */ uint @index, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint @value)
        => glVertexAttribP1ui(@index, @type, @normalized, @value);
    public /* void */ void VertexAttribP1uiv(/* GLuint */ uint @index, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint* @value)
        => glVertexAttribP1uiv(@index, @type, @normalized, @value);
    public /* void */ void VertexAttribP2ui(/* GLuint */ uint @index, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint @value)
        => glVertexAttribP2ui(@index, @type, @normalized, @value);
    public /* void */ void VertexAttribP2uiv(/* GLuint */ uint @index, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint* @value)
        => glVertexAttribP2uiv(@index, @type, @normalized, @value);
    public /* void */ void VertexAttribP3ui(/* GLuint */ uint @index, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint @value)
        => glVertexAttribP3ui(@index, @type, @normalized, @value);
    public /* void */ void VertexAttribP3uiv(/* GLuint */ uint @index, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint* @value)
        => glVertexAttribP3uiv(@index, @type, @normalized, @value);
    public /* void */ void VertexAttribP4ui(/* GLuint */ uint @index, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint @value)
        => glVertexAttribP4ui(@index, @type, @normalized, @value);
    public /* void */ void VertexAttribP4uiv(/* GLuint */ uint @index, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint* @value)
        => glVertexAttribP4uiv(@index, @type, @normalized, @value);
    public /* void */ void VertexAttribPointer(/* GLuint */ uint @index, /* GLint */ int @size, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLsizei */ int @stride, /* void */ void* @pointer)
        => glVertexAttribPointer(@index, @size, @type, @normalized, @stride, @pointer);
    public /* void */ void VertexBindingDivisor(/* GLuint */ uint @bindingindex, /* GLuint */ uint @divisor)
        => glVertexBindingDivisor(@bindingindex, @divisor);
    public /* void */ void Viewport(/* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glViewport(@x, @y, @width, @height);
    public /* void */ void ViewportArrayv(/* GLuint */ uint @first, /* GLsizei */ int @count, /* GLfloat */ float* @v)
        => glViewportArrayv(@first, @count, @v);
    public /* void */ void ViewportIndexedf(/* GLuint */ uint @index, /* GLfloat */ float @x, /* GLfloat */ float @y, /* GLfloat */ float @w, /* GLfloat */ float @h)
        => glViewportIndexedf(@index, @x, @y, @w, @h);
    public /* void */ void ViewportIndexedfv(/* GLuint */ uint @index, /* GLfloat */ float* @v)
        => glViewportIndexedfv(@index, @v);
    public /* void */ void WaitSync(/* GLsync */ void* @sync, /* GLbitfield */ int @flags, /* GLuint64 */ ulong @timeout)
        => glWaitSync(@sync, @flags, @timeout);
}
