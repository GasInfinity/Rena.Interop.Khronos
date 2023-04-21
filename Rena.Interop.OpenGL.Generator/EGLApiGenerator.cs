using System.CodeDom.Compiler;
using static Rena.Interop.OpenGL.Generator.Generation;

namespace Rena.Interop.OpenGL.Generator;

public sealed class EGLApiGenerator : ApiGenerator
{
    public override string Prefix
        => "egl";

    public EGLApiGenerator(Generator generator) : base(generator)
    {
    }

    public override void WriteRequiredFields(IndentedTextWriter writer)
    {
        base.WriteRequiredFields(writer);

        var includedEnums = MainGenerator.IncludedEnums;

        if (!includedEnums.Any(e => e.Name is "EGL_EXTENSIONS"))
            writer.WriteLine("internal const int EGL_EXTENSIONS = 0x3055;");
    }

    public override void WriteLoadingStatements(IndentedTextWriter writer)
    {
        base.WriteLoadingStatements(writer);

        writer.WriteLine("delegate* unmanaged<void*, int, byte*> eglQueryString;");
        GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName("eglQueryString"), "eglQueryString", "delegate* unmanaged<void*, int, byte*>");

        writer.WriteLine("delegate* unmanaged<int> eglGetError;");
        GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName("eglGetError"), "eglGetError", "delegate* unmanaged<int>");

        writer.WriteLine("if(eglQueryString is null || eglGetError is null) return;");

        if (!MainGenerator.LoadedApis.IsDefaultOrEmpty)
        {
            writer.WrtLine("var version = eglQueryString((void*)EGL_NO_DISPLAY, EGL_VERSION);")
                  .WrtLine("_ = eglGetError();")
                  .WrtLine("if(version == null) (Major, Minor) = (1, 0);")
                  .WrtLine("else if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor)) return;");
        }

        var loadedExtensions = MainGenerator.LoadedExtensions;
        if (!loadedExtensions.IsDefaultOrEmpty)
        {
            writer.WrtLine("static bool IsExtensionSupported(ReadOnlySpan<byte> allExtensions, ReadOnlySpan<byte> extension)")
                  .AddIndentation()
                    .WrtLine("=> extensions.IndexOf(extension) != -1;")
                  .RemoveIndentation()
                  .WrtLine()
                  .WrtLine("var allExtensionsPointer = eglQueryString(null, EGL_EXTENSIONS);")
                  .WrtLine("ReadOnlySpan<byte> allExtensions = allExtensionsPointer != null ? MemoryMarshal.CreateReadOnlySpanFromNullTerminated(allExtensionsPointer) : default;");

            foreach (var extension in MainGenerator.LoadedExtensions)
                writer.WriteLine($"{extension.Name} = IsExtensionSupported(allExtensions, {ExtensionToUtf8ExtensionName(extension.Name)});");
        }
    }
}