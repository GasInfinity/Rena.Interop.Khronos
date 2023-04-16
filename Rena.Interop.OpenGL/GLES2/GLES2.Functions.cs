namespace Rena.Interop.OpenGL;

public unsafe partial class GLES2
{
    public /* void */ void ActiveShaderProgram(/* GLuint */ uint @pipeline, /* GLuint */ uint @program)
        => glActiveShaderProgram(@pipeline, @program);
    public /* void */ void ActiveTexture(/* GLenum */ int @texture)
        => glActiveTexture(@texture);
    public /* void */ void AttachShader(/* GLuint */ uint @program, /* GLuint */ uint @shader)
        => glAttachShader(@program, @shader);
    public /* void */ void BeginQuery(/* GLenum */ int @target, /* GLuint */ uint @id)
        => glBeginQuery(@target, @id);
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
    public /* void */ void BindFramebuffer(/* GLenum */ int @target, /* GLuint */ uint @framebuffer)
        => glBindFramebuffer(@target, @framebuffer);
    public /* void */ void BindImageTexture(/* GLuint */ uint @unit, /* GLuint */ uint @texture, /* GLint */ int @level, /* GLboolean */ int @layered, /* GLint */ int @layer, /* GLenum */ int @access, /* GLenum */ int @format)
        => glBindImageTexture(@unit, @texture, @level, @layered, @layer, @access, @format);
    public /* void */ void BindProgramPipeline(/* GLuint */ uint @pipeline)
        => glBindProgramPipeline(@pipeline);
    public /* void */ void BindRenderbuffer(/* GLenum */ int @target, /* GLuint */ uint @renderbuffer)
        => glBindRenderbuffer(@target, @renderbuffer);
    public /* void */ void BindSampler(/* GLuint */ uint @unit, /* GLuint */ uint @sampler)
        => glBindSampler(@unit, @sampler);
    public /* void */ void BindTexture(/* GLenum */ int @target, /* GLuint */ uint @texture)
        => glBindTexture(@target, @texture);
    public /* void */ void BindTransformFeedback(/* GLenum */ int @target, /* GLuint */ uint @id)
        => glBindTransformFeedback(@target, @id);
    public /* void */ void BindVertexArray(/* GLuint */ uint @array)
        => glBindVertexArray(@array);
    public /* void */ void BindVertexBuffer(/* GLuint */ uint @bindingindex, /* GLuint */ uint @buffer, /* GLintptr */ nint @offset, /* GLsizei */ int @stride)
        => glBindVertexBuffer(@bindingindex, @buffer, @offset, @stride);
    public /* void */ void BlendBarrier()
        => glBlendBarrier();
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
    public /* void */ void BufferData(/* GLenum */ int @target, /* GLsizeiptr */ nint @size, /* void */ void* @data, /* GLenum */ int @usage)
        => glBufferData(@target, @size, @data, @usage);
    public /* void */ void BufferSubData(/* GLenum */ int @target, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @size, /* void */ void* @data)
        => glBufferSubData(@target, @offset, @size, @data);
    public /* GLenum */ int CheckFramebufferStatus(/* GLenum */ int @target)
        => glCheckFramebufferStatus(@target);
    public /* void */ void Clear(/* GLbitfield */ int @mask)
        => glClear(@mask);
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
    public /* void */ void ClearDepthf(/* GLfloat */ float @d)
        => glClearDepthf(@d);
    public /* void */ void ClearStencil(/* GLint */ int @s)
        => glClearStencil(@s);
    public /* GLenum */ int ClientWaitSync(/* GLsync */ void* @sync, /* GLbitfield */ int @flags, /* GLuint64 */ ulong @timeout)
        => glClientWaitSync(@sync, @flags, @timeout);
    public /* void */ void ColorMask(/* GLboolean */ int @red, /* GLboolean */ int @green, /* GLboolean */ int @blue, /* GLboolean */ int @alpha)
        => glColorMask(@red, @green, @blue, @alpha);
    public /* void */ void ColorMaski(/* GLuint */ uint @index, /* GLboolean */ int @r, /* GLboolean */ int @g, /* GLboolean */ int @b, /* GLboolean */ int @a)
        => glColorMaski(@index, @r, @g, @b, @a);
    public /* void */ void CompileShader(/* GLuint */ uint @shader)
        => glCompileShader(@shader);
    public /* void */ void CompressedTexImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLint */ int @border, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexImage2D(@target, @level, @internalformat, @width, @height, @border, @imageSize, @data);
    public /* void */ void CompressedTexImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLint */ int @border, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexImage3D(@target, @level, @internalformat, @width, @height, @depth, @border, @imageSize, @data);
    public /* void */ void CompressedTexSubImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexSubImage2D(@target, @level, @xoffset, @yoffset, @width, @height, @format, @imageSize, @data);
    public /* void */ void CompressedTexSubImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLenum */ int @format, /* GLsizei */ int @imageSize, /* void */ void* @data)
        => glCompressedTexSubImage3D(@target, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth, @format, @imageSize, @data);
    public /* void */ void CopyBufferSubData(/* GLenum */ int @readTarget, /* GLenum */ int @writeTarget, /* GLintptr */ nint @readOffset, /* GLintptr */ nint @writeOffset, /* GLsizeiptr */ nint @size)
        => glCopyBufferSubData(@readTarget, @writeTarget, @readOffset, @writeOffset, @size);
    public /* void */ void CopyImageSubData(/* GLuint */ uint @srcName, /* GLenum */ int @srcTarget, /* GLint */ int @srcLevel, /* GLint */ int @srcX, /* GLint */ int @srcY, /* GLint */ int @srcZ, /* GLuint */ uint @dstName, /* GLenum */ int @dstTarget, /* GLint */ int @dstLevel, /* GLint */ int @dstX, /* GLint */ int @dstY, /* GLint */ int @dstZ, /* GLsizei */ int @srcWidth, /* GLsizei */ int @srcHeight, /* GLsizei */ int @srcDepth)
        => glCopyImageSubData(@srcName, @srcTarget, @srcLevel, @srcX, @srcY, @srcZ, @dstName, @dstTarget, @dstLevel, @dstX, @dstY, @dstZ, @srcWidth, @srcHeight, @srcDepth);
    public /* void */ void CopyTexImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLenum */ int @internalformat, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLint */ int @border)
        => glCopyTexImage2D(@target, @level, @internalformat, @x, @y, @width, @height, @border);
    public /* void */ void CopyTexSubImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glCopyTexSubImage2D(@target, @level, @xoffset, @yoffset, @x, @y, @width, @height);
    public /* void */ void CopyTexSubImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glCopyTexSubImage3D(@target, @level, @xoffset, @yoffset, @zoffset, @x, @y, @width, @height);
    public /* GLuint */ uint CreateProgram()
        => glCreateProgram();
    public /* GLuint */ uint CreateShader(/* GLenum */ int @type)
        => glCreateShader(@type);
    public /* GLuint */ uint CreateShaderProgramv(/* GLenum */ int @type, /* GLsizei */ int @count, /* GLchar */ byte** @strings)
        => glCreateShaderProgramv(@type, @count, @strings);
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
    public /* void */ void DepthRangef(/* GLfloat */ float @n, /* GLfloat */ float @f)
        => glDepthRangef(@n, @f);
    public /* void */ void DetachShader(/* GLuint */ uint @program, /* GLuint */ uint @shader)
        => glDetachShader(@program, @shader);
    public /* void */ void Disable(/* GLenum */ int @cap)
        => glDisable(@cap);
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
    public /* void */ void DrawElementsInstancedBaseVertex(/* GLenum */ int @mode, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLsizei */ int @instancecount, /* GLint */ int @basevertex)
        => glDrawElementsInstancedBaseVertex(@mode, @count, @type, @indices, @instancecount, @basevertex);
    public /* void */ void DrawRangeElements(/* GLenum */ int @mode, /* GLuint */ uint @start, /* GLuint */ uint @end, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices)
        => glDrawRangeElements(@mode, @start, @end, @count, @type, @indices);
    public /* void */ void DrawRangeElementsBaseVertex(/* GLenum */ int @mode, /* GLuint */ uint @start, /* GLuint */ uint @end, /* GLsizei */ int @count, /* GLenum */ int @type, /* void */ void* @indices, /* GLint */ int @basevertex)
        => glDrawRangeElementsBaseVertex(@mode, @start, @end, @count, @type, @indices, @basevertex);
    public /* void */ void Enable(/* GLenum */ int @cap)
        => glEnable(@cap);
    public /* void */ void EnableVertexAttribArray(/* GLuint */ uint @index)
        => glEnableVertexAttribArray(@index);
    public /* void */ void Enablei(/* GLenum */ int @target, /* GLuint */ uint @index)
        => glEnablei(@target, @index);
    public /* void */ void EndQuery(/* GLenum */ int @target)
        => glEndQuery(@target);
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
    public /* void */ void FramebufferParameteri(/* GLenum */ int @target, /* GLenum */ int @pname, /* GLint */ int @param)
        => glFramebufferParameteri(@target, @pname, @param);
    public /* void */ void FramebufferRenderbuffer(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLenum */ int @renderbuffertarget, /* GLuint */ uint @renderbuffer)
        => glFramebufferRenderbuffer(@target, @attachment, @renderbuffertarget, @renderbuffer);
    public /* void */ void FramebufferTexture(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLuint */ uint @texture, /* GLint */ int @level)
        => glFramebufferTexture(@target, @attachment, @texture, @level);
    public /* void */ void FramebufferTexture2D(/* GLenum */ int @target, /* GLenum */ int @attachment, /* GLenum */ int @textarget, /* GLuint */ uint @texture, /* GLint */ int @level)
        => glFramebufferTexture2D(@target, @attachment, @textarget, @texture, @level);
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
    public /* void */ void GetActiveAttrib(/* GLuint */ uint @program, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLint */ int* @size, /* GLenum */ int* @type, /* GLchar */ byte* @name)
        => glGetActiveAttrib(@program, @index, @bufSize, @length, @size, @type, @name);
    public /* void */ void GetActiveUniform(/* GLuint */ uint @program, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLint */ int* @size, /* GLenum */ int* @type, /* GLchar */ byte* @name)
        => glGetActiveUniform(@program, @index, @bufSize, @length, @size, @type, @name);
    public /* void */ void GetActiveUniformBlockName(/* GLuint */ uint @program, /* GLuint */ uint @uniformBlockIndex, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @uniformBlockName)
        => glGetActiveUniformBlockName(@program, @uniformBlockIndex, @bufSize, @length, @uniformBlockName);
    public /* void */ void GetActiveUniformBlockiv(/* GLuint */ uint @program, /* GLuint */ uint @uniformBlockIndex, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetActiveUniformBlockiv(@program, @uniformBlockIndex, @pname, @params);
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
    public /* GLuint */ uint GetDebugMessageLog(/* GLuint */ uint @count, /* GLsizei */ int @bufSize, /* GLenum */ int* @sources, /* GLenum */ int* @types, /* GLuint */ uint* @ids, /* GLenum */ int* @severities, /* GLsizei */ int* @lengths, /* GLchar */ byte* @messageLog)
        => glGetDebugMessageLog(@count, @bufSize, @sources, @types, @ids, @severities, @lengths, @messageLog);
    public /* GLenum */ int GetError()
        => glGetError();
    public /* void */ void GetFloatv(/* GLenum */ int @pname, /* GLfloat */ float* @data)
        => glGetFloatv(@pname, @data);
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
    public /* void */ void GetInternalformativ(/* GLenum */ int @target, /* GLenum */ int @internalformat, /* GLenum */ int @pname, /* GLsizei */ int @count, /* GLint */ int* @params)
        => glGetInternalformativ(@target, @internalformat, @pname, @count, @params);
    public /* void */ void GetMultisamplefv(/* GLenum */ int @pname, /* GLuint */ uint @index, /* GLfloat */ float* @val)
        => glGetMultisamplefv(@pname, @index, @val);
    public /* void */ void GetObjectLabel(/* GLenum */ int @identifier, /* GLuint */ uint @name, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @label)
        => glGetObjectLabel(@identifier, @name, @bufSize, @length, @label);
    public /* void */ void GetObjectPtrLabel(/* void */ void* @ptr, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @label)
        => glGetObjectPtrLabel(@ptr, @bufSize, @length, @label);
    public /* void */ void GetPointerv(/* GLenum */ int @pname, /* void */ void** @params)
        => glGetPointerv(@pname, @params);
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
    public /* void */ void GetProgramResourceName(/* GLuint */ uint @program, /* GLenum */ int @programInterface, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLchar */ byte* @name)
        => glGetProgramResourceName(@program, @programInterface, @index, @bufSize, @length, @name);
    public /* void */ void GetProgramResourceiv(/* GLuint */ uint @program, /* GLenum */ int @programInterface, /* GLuint */ uint @index, /* GLsizei */ int @propCount, /* GLenum */ int* @props, /* GLsizei */ int @count, /* GLsizei */ int* @length, /* GLint */ int* @params)
        => glGetProgramResourceiv(@program, @programInterface, @index, @propCount, @props, @count, @length, @params);
    public /* void */ void GetProgramiv(/* GLuint */ uint @program, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetProgramiv(@program, @pname, @params);
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
    public /* void */ void GetSynciv(/* GLsync */ void* @sync, /* GLenum */ int @pname, /* GLsizei */ int @count, /* GLsizei */ int* @length, /* GLint */ int* @values)
        => glGetSynciv(@sync, @pname, @count, @length, @values);
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
    public /* void */ void GetTransformFeedbackVarying(/* GLuint */ uint @program, /* GLuint */ uint @index, /* GLsizei */ int @bufSize, /* GLsizei */ int* @length, /* GLsizei */ int* @size, /* GLenum */ int* @type, /* GLchar */ byte* @name)
        => glGetTransformFeedbackVarying(@program, @index, @bufSize, @length, @size, @type, @name);
    public /* GLuint */ uint GetUniformBlockIndex(/* GLuint */ uint @program, /* GLchar */ byte* @uniformBlockName)
        => glGetUniformBlockIndex(@program, @uniformBlockName);
    public /* void */ void GetUniformIndices(/* GLuint */ uint @program, /* GLsizei */ int @uniformCount, /* GLchar */ byte** @uniformNames, /* GLuint */ uint* @uniformIndices)
        => glGetUniformIndices(@program, @uniformCount, @uniformNames, @uniformIndices);
    public /* GLint */ int GetUniformLocation(/* GLuint */ uint @program, /* GLchar */ byte* @name)
        => glGetUniformLocation(@program, @name);
    public /* void */ void GetUniformfv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLfloat */ float* @params)
        => glGetUniformfv(@program, @location, @params);
    public /* void */ void GetUniformiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLint */ int* @params)
        => glGetUniformiv(@program, @location, @params);
    public /* void */ void GetUniformuiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLuint */ uint* @params)
        => glGetUniformuiv(@program, @location, @params);
    public /* void */ void GetVertexAttribIiv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetVertexAttribIiv(@index, @pname, @params);
    public /* void */ void GetVertexAttribIuiv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLuint */ uint* @params)
        => glGetVertexAttribIuiv(@index, @pname, @params);
    public /* void */ void GetVertexAttribPointerv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* void */ void** @pointer)
        => glGetVertexAttribPointerv(@index, @pname, @pointer);
    public /* void */ void GetVertexAttribfv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLfloat */ float* @params)
        => glGetVertexAttribfv(@index, @pname, @params);
    public /* void */ void GetVertexAttribiv(/* GLuint */ uint @index, /* GLenum */ int @pname, /* GLint */ int* @params)
        => glGetVertexAttribiv(@index, @pname, @params);
    public /* void */ void GetnUniformfv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @bufSize, /* GLfloat */ float* @params)
        => glGetnUniformfv(@program, @location, @bufSize, @params);
    public /* void */ void GetnUniformiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @bufSize, /* GLint */ int* @params)
        => glGetnUniformiv(@program, @location, @bufSize, @params);
    public /* void */ void GetnUniformuiv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @bufSize, /* GLuint */ uint* @params)
        => glGetnUniformuiv(@program, @location, @bufSize, @params);
    public /* void */ void Hint(/* GLenum */ int @target, /* GLenum */ int @mode)
        => glHint(@target, @mode);
    public /* void */ void InvalidateFramebuffer(/* GLenum */ int @target, /* GLsizei */ int @numAttachments, /* GLenum */ int* @attachments)
        => glInvalidateFramebuffer(@target, @numAttachments, @attachments);
    public /* void */ void InvalidateSubFramebuffer(/* GLenum */ int @target, /* GLsizei */ int @numAttachments, /* GLenum */ int* @attachments, /* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glInvalidateSubFramebuffer(@target, @numAttachments, @attachments, @x, @y, @width, @height);
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
    public /* void */ void* MapBufferRange(/* GLenum */ int @target, /* GLintptr */ nint @offset, /* GLsizeiptr */ nint @length, /* GLbitfield */ int @access)
        => glMapBufferRange(@target, @offset, @length, @access);
    public /* void */ void MemoryBarrier(/* GLbitfield */ int @barriers)
        => glMemoryBarrier(@barriers);
    public /* void */ void MemoryBarrierByRegion(/* GLbitfield */ int @barriers)
        => glMemoryBarrierByRegion(@barriers);
    public /* void */ void MinSampleShading(/* GLfloat */ float @value)
        => glMinSampleShading(@value);
    public /* void */ void ObjectLabel(/* GLenum */ int @identifier, /* GLuint */ uint @name, /* GLsizei */ int @length, /* GLchar */ byte* @label)
        => glObjectLabel(@identifier, @name, @length, @label);
    public /* void */ void ObjectPtrLabel(/* void */ void* @ptr, /* GLsizei */ int @length, /* GLchar */ byte* @label)
        => glObjectPtrLabel(@ptr, @length, @label);
    public /* void */ void PatchParameteri(/* GLenum */ int @pname, /* GLint */ int @value)
        => glPatchParameteri(@pname, @value);
    public /* void */ void PauseTransformFeedback()
        => glPauseTransformFeedback();
    public /* void */ void PixelStorei(/* GLenum */ int @pname, /* GLint */ int @param)
        => glPixelStorei(@pname, @param);
    public /* void */ void PolygonOffset(/* GLfloat */ float @factor, /* GLfloat */ float @units)
        => glPolygonOffset(@factor, @units);
    public /* void */ void PopDebugGroup()
        => glPopDebugGroup();
    public /* void */ void PrimitiveBoundingBox(/* GLfloat */ float @minX, /* GLfloat */ float @minY, /* GLfloat */ float @minZ, /* GLfloat */ float @minW, /* GLfloat */ float @maxX, /* GLfloat */ float @maxY, /* GLfloat */ float @maxZ, /* GLfloat */ float @maxW)
        => glPrimitiveBoundingBox(@minX, @minY, @minZ, @minW, @maxX, @maxY, @maxZ, @maxW);
    public /* void */ void ProgramBinary(/* GLuint */ uint @program, /* GLenum */ int @binaryFormat, /* void */ void* @binary, /* GLsizei */ int @length)
        => glProgramBinary(@program, @binaryFormat, @binary, @length);
    public /* void */ void ProgramParameteri(/* GLuint */ uint @program, /* GLenum */ int @pname, /* GLint */ int @value)
        => glProgramParameteri(@program, @pname, @value);
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
    public /* void */ void ProgramUniformMatrix2fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix2fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix2x3fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix2x3fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix2x4fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix2x4fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix3fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix3fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix3x2fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix3x2fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix3x4fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix3x4fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix4fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix4fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix4x2fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix4x2fv(@program, @location, @count, @transpose, @value);
    public /* void */ void ProgramUniformMatrix4x3fv(/* GLuint */ uint @program, /* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glProgramUniformMatrix4x3fv(@program, @location, @count, @transpose, @value);
    public /* void */ void PushDebugGroup(/* GLenum */ int @source, /* GLuint */ uint @id, /* GLsizei */ int @length, /* GLchar */ byte* @message)
        => glPushDebugGroup(@source, @id, @length, @message);
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
    public /* void */ void ShaderBinary(/* GLsizei */ int @count, /* GLuint */ uint* @shaders, /* GLenum */ int @binaryFormat, /* void */ void* @binary, /* GLsizei */ int @length)
        => glShaderBinary(@count, @shaders, @binaryFormat, @binary, @length);
    public /* void */ void ShaderSource(/* GLuint */ uint @shader, /* GLsizei */ int @count, /* GLchar */ byte** @string, /* GLint */ int* @length)
        => glShaderSource(@shader, @count, @string, @length);
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
    public /* void */ void TexImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLint */ int @border, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexImage2D(@target, @level, @internalformat, @width, @height, @border, @format, @type, @pixels);
    public /* void */ void TexImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLint */ int @border, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexImage3D(@target, @level, @internalformat, @width, @height, @depth, @border, @format, @type, @pixels);
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
    public /* void */ void TexStorage2D(/* GLenum */ int @target, /* GLsizei */ int @levels, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glTexStorage2D(@target, @levels, @internalformat, @width, @height);
    public /* void */ void TexStorage2DMultisample(/* GLenum */ int @target, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLboolean */ int @fixedsamplelocations)
        => glTexStorage2DMultisample(@target, @samples, @internalformat, @width, @height, @fixedsamplelocations);
    public /* void */ void TexStorage3D(/* GLenum */ int @target, /* GLsizei */ int @levels, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth)
        => glTexStorage3D(@target, @levels, @internalformat, @width, @height, @depth);
    public /* void */ void TexStorage3DMultisample(/* GLenum */ int @target, /* GLsizei */ int @samples, /* GLenum */ int @internalformat, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLboolean */ int @fixedsamplelocations)
        => glTexStorage3DMultisample(@target, @samples, @internalformat, @width, @height, @depth, @fixedsamplelocations);
    public /* void */ void TexSubImage2D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexSubImage2D(@target, @level, @xoffset, @yoffset, @width, @height, @format, @type, @pixels);
    public /* void */ void TexSubImage3D(/* GLenum */ int @target, /* GLint */ int @level, /* GLint */ int @xoffset, /* GLint */ int @yoffset, /* GLint */ int @zoffset, /* GLsizei */ int @width, /* GLsizei */ int @height, /* GLsizei */ int @depth, /* GLenum */ int @format, /* GLenum */ int @type, /* void */ void* @pixels)
        => glTexSubImage3D(@target, @level, @xoffset, @yoffset, @zoffset, @width, @height, @depth, @format, @type, @pixels);
    public /* void */ void TransformFeedbackVaryings(/* GLuint */ uint @program, /* GLsizei */ int @count, /* GLchar */ byte** @varyings, /* GLenum */ int @bufferMode)
        => glTransformFeedbackVaryings(@program, @count, @varyings, @bufferMode);
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
    public /* void */ void UniformMatrix2fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix2fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix2x3fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix2x3fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix2x4fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix2x4fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix3fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix3fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix3x2fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix3x2fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix3x4fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix3x4fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix4fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix4fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix4x2fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix4x2fv(@location, @count, @transpose, @value);
    public /* void */ void UniformMatrix4x3fv(/* GLint */ int @location, /* GLsizei */ int @count, /* GLboolean */ int @transpose, /* GLfloat */ float* @value)
        => glUniformMatrix4x3fv(@location, @count, @transpose, @value);
    public /* GLboolean */ int UnmapBuffer(/* GLenum */ int @target)
        => glUnmapBuffer(@target);
    public /* void */ void UseProgram(/* GLuint */ uint @program)
        => glUseProgram(@program);
    public /* void */ void UseProgramStages(/* GLuint */ uint @pipeline, /* GLbitfield */ int @stages, /* GLuint */ uint @program)
        => glUseProgramStages(@pipeline, @stages, @program);
    public /* void */ void ValidateProgram(/* GLuint */ uint @program)
        => glValidateProgram(@program);
    public /* void */ void ValidateProgramPipeline(/* GLuint */ uint @pipeline)
        => glValidateProgramPipeline(@pipeline);
    public /* void */ void VertexAttrib1f(/* GLuint */ uint @index, /* GLfloat */ float @x)
        => glVertexAttrib1f(@index, @x);
    public /* void */ void VertexAttrib1fv(/* GLuint */ uint @index, /* GLfloat */ float* @v)
        => glVertexAttrib1fv(@index, @v);
    public /* void */ void VertexAttrib2f(/* GLuint */ uint @index, /* GLfloat */ float @x, /* GLfloat */ float @y)
        => glVertexAttrib2f(@index, @x, @y);
    public /* void */ void VertexAttrib2fv(/* GLuint */ uint @index, /* GLfloat */ float* @v)
        => glVertexAttrib2fv(@index, @v);
    public /* void */ void VertexAttrib3f(/* GLuint */ uint @index, /* GLfloat */ float @x, /* GLfloat */ float @y, /* GLfloat */ float @z)
        => glVertexAttrib3f(@index, @x, @y, @z);
    public /* void */ void VertexAttrib3fv(/* GLuint */ uint @index, /* GLfloat */ float* @v)
        => glVertexAttrib3fv(@index, @v);
    public /* void */ void VertexAttrib4f(/* GLuint */ uint @index, /* GLfloat */ float @x, /* GLfloat */ float @y, /* GLfloat */ float @z, /* GLfloat */ float @w)
        => glVertexAttrib4f(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttrib4fv(/* GLuint */ uint @index, /* GLfloat */ float* @v)
        => glVertexAttrib4fv(@index, @v);
    public /* void */ void VertexAttribBinding(/* GLuint */ uint @attribindex, /* GLuint */ uint @bindingindex)
        => glVertexAttribBinding(@attribindex, @bindingindex);
    public /* void */ void VertexAttribDivisor(/* GLuint */ uint @index, /* GLuint */ uint @divisor)
        => glVertexAttribDivisor(@index, @divisor);
    public /* void */ void VertexAttribFormat(/* GLuint */ uint @attribindex, /* GLint */ int @size, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLuint */ uint @relativeoffset)
        => glVertexAttribFormat(@attribindex, @size, @type, @normalized, @relativeoffset);
    public /* void */ void VertexAttribI4i(/* GLuint */ uint @index, /* GLint */ int @x, /* GLint */ int @y, /* GLint */ int @z, /* GLint */ int @w)
        => glVertexAttribI4i(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttribI4iv(/* GLuint */ uint @index, /* GLint */ int* @v)
        => glVertexAttribI4iv(@index, @v);
    public /* void */ void VertexAttribI4ui(/* GLuint */ uint @index, /* GLuint */ uint @x, /* GLuint */ uint @y, /* GLuint */ uint @z, /* GLuint */ uint @w)
        => glVertexAttribI4ui(@index, @x, @y, @z, @w);
    public /* void */ void VertexAttribI4uiv(/* GLuint */ uint @index, /* GLuint */ uint* @v)
        => glVertexAttribI4uiv(@index, @v);
    public /* void */ void VertexAttribIFormat(/* GLuint */ uint @attribindex, /* GLint */ int @size, /* GLenum */ int @type, /* GLuint */ uint @relativeoffset)
        => glVertexAttribIFormat(@attribindex, @size, @type, @relativeoffset);
    public /* void */ void VertexAttribIPointer(/* GLuint */ uint @index, /* GLint */ int @size, /* GLenum */ int @type, /* GLsizei */ int @stride, /* void */ void* @pointer)
        => glVertexAttribIPointer(@index, @size, @type, @stride, @pointer);
    public /* void */ void VertexAttribPointer(/* GLuint */ uint @index, /* GLint */ int @size, /* GLenum */ int @type, /* GLboolean */ int @normalized, /* GLsizei */ int @stride, /* void */ void* @pointer)
        => glVertexAttribPointer(@index, @size, @type, @normalized, @stride, @pointer);
    public /* void */ void VertexBindingDivisor(/* GLuint */ uint @bindingindex, /* GLuint */ uint @divisor)
        => glVertexBindingDivisor(@bindingindex, @divisor);
    public /* void */ void Viewport(/* GLint */ int @x, /* GLint */ int @y, /* GLsizei */ int @width, /* GLsizei */ int @height)
        => glViewport(@x, @y, @width, @height);
    public /* void */ void WaitSync(/* GLsync */ void* @sync, /* GLbitfield */ int @flags, /* GLuint64 */ ulong @timeout)
        => glWaitSync(@sync, @flags, @timeout);
}
