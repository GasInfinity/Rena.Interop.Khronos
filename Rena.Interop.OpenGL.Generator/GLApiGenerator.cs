using System.CodeDom.Compiler;
using static Rena.Interop.OpenGL.Generator.Generation;

namespace Rena.Interop.OpenGL.Generator;

public sealed class GLApiGenerator : ApiGenerator
{
    public override string Prefix
        => "gl";

    public GLApiGenerator(Generator generator) : base(generator)
    {
    }

    public override void WriteLoaderFields(IndentedTextWriter writer)
    {
        base.WriteLoaderFields(writer);
        writer.WriteLine("public readonly bool IsEmbedded;");
    }

    public override void WriteRequiredFields(IndentedTextWriter writer)
    {
        base.WriteRequiredFields(writer);

        var includedCommands = MainGenerator.IncludedCommands;
        var includedEnums = MainGenerator.IncludedEnums;

        if (!includedCommands.Any(c => c.Name is "glGetString"))
            writer.WriteLine($"internal static ReadOnlySpan<byte> {FunctionToUtf8FunctionName("glGetString")} => \"glGetString\"u8;");

        if (!includedCommands.Any(c => c.Name is "glGetStringi"))
            writer.WriteLine($"internal static ReadOnlySpan<byte> {FunctionToUtf8FunctionName("glGetStringi")} => \"glGetStringi\"u8;");

        if (!includedCommands.Any(c => c.Name is "glGetIntegerv"))
            writer.WriteLine($"internal static ReadOnlySpan<byte> {FunctionToUtf8FunctionName("glGetIntegerv")} => \"glGetIntegerv\"u8;");

        if (!includedEnums.Any(e => e.Name is "GL_EXTENSIONS"))
            writer.WriteLine("internal const int GL_EXTENSIONS = 0x1F03;");

        if (!includedEnums.Any(e => e.Name is "GL_NUM_EXTENSIONS"))
            writer.WriteLine("internal const int GL_NUM_EXTENSIONS = 0x821D;");
    }

    public override void WriteLoadingStatements(IndentedTextWriter writer)
    {
        base.WriteLoadingStatements(writer);

        writer.WriteLine("delegate* unmanaged<int, byte*> glGetString;");
        GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName("glGetString"), "glGetString", "delegate* unmanaged<int, byte*>");
        writer.WriteLine("if(glGetString == null) return;");

        if (!MainGenerator.LoadedApis.IsDefaultOrEmpty)
        {
            writer.WrtLine("var version = glGetString(GL_VERSION);")
                  .WrtLine("if(version is null) return;")
                  .WrtLine("if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor, out IsEmbedded)) return;");
        }

        if (!MainGenerator.LoadedExtensions.IsDefaultOrEmpty)
        {
            writer.WriteLine("var hasLoadedExtensions = false;");

            WriteGL3ExtensionLoading(writer);
            WriteGLExtensionLoading(writer);
        }
    }

    private void WriteGL3ExtensionLoading(IndentedTextWriter writer)
    {
        writer.WrtLine("static bool IsExtensionSupported(ReadOnlySpan<nint> extensionStrings, ReadOnlySpan<byte> extension)")
              .WrtLine('{')
              .AddIndentation()
                .WrtLine("foreach(var e in extensionStrings)")
                .WrtLine('{')
                .AddIndentation()
                    .WrtLine("if(extension.SequenceEqual(MemoryMarshal.CreateReadOnlySpanFromNullTerminated((byte*)e)))")
                    .AddIndentation()
                        .WrtLine("return true;")
                    .RemoveIndentation()
                .RemoveIndentation()
                .WrtLine('}')
              .WrtLine()
              .WrtLine("return false;")
              .RemoveIndentation()
              .WrtLine('}');

        writer.WriteLine("delegate* unmanaged<int, uint, byte*> glGetStringi;");
        GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName("glGetStringi"), "glGetStringi", "delegate* unmanaged<int, uint, byte*>");

        writer.WriteLine("delegate* unmanaged<int, int*, void> glGetIntegerv;");
        GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName("glGetIntegerv"), "glGetIntegerv", "delegate* unmanaged<int, int*, void>");

        writer.WrtLine("if(glGetStringi is not null & glGetIntegerv is not null) // Fast path (OpenGL 3+)")
              .WrtLine('{')
              .AddIndentation()
                .WrtLine("hasLoadedExtensions = true;")
                .WrtLine("int extensionsLength;")
                .WrtLine("glGetIntegerv(\"GL_NUM_EXTENSIONS\", &extensionsLength);")
                .WrtLine("byte[] pointerData = ArrayPool<byte>.Shared.Rent(extensionsLength * sizeof(nint));")
                .WrtLine("Span<nint> extensions = MemoryMarshal.Cast<byte, nint>(pointerData.AsSpan()[..(extensionsLength * sizeof(nint))]);")
                .WrtLine()
                .WrtLine("for(int e = 0; e < extensionsLength; ++e)")
                .AddIndentation()
                    .WrtLine("extensions[e] = (nint)glGetStringi(GL_EXTENSIONS, i);")
                .RemoveIndentation()
                .WrtLine();

        foreach (var extension in MainGenerator.LoadedExtensions)
            writer.WriteLine($"{extension.Name} = IsExtensionSupported(extensions, {ExtensionToUtf8ExtensionName(extension.Name)});");

        writer.WrtLine()
              .WrtLine("ArrayPool<byte>.Shared.Return(pointerData);")
              .RemoveIndentation()
              .WrtLine('}');
    }

    private void WriteGLExtensionLoading(IndentedTextWriter writer)
    {
        writer.WrtLine("static bool IsExtensionSupported(ReadOnlySpan<byte> allExtensions, ReadOnlySpan<byte> extension)")
              .AddIndentation()
                .WrtLine("=> extensions.IndexOf(extension) != -1;")
              .RemoveIndentation()
              .WrtLine()
              .WrtLine("if(!hasLoadedExtensions)")
              .WrtLine('{')
              .AddIndentation()
                .WrtLine("var allExtensionsPointer = glGetString(GL_EXTENSIONS);")
                .WrtLine("ReadOnlySpan<byte> allExtensions = allExtensionsPointer != null ? MemoryMarshal.CreateReadOnlySpanFromNullTerminated(allExtensionsPointer) : default;")
                .WrtLine();

        foreach (var extension in MainGenerator.LoadedExtensions)
            writer.WriteLine($"{extension.Name} = IsExtensionSupported(allExtensions, {ExtensionToUtf8ExtensionName(extension.Name)});");

        writer.RemoveIndentation()
              .WrtLine('}');
    }

    public override void WriteUtilFields(IndentedTextWriter writer)
    {
        base.WriteUtilFields(writer);

        writer.WrtLine("internal static ReadOnlySpan<byte> OpenGlEsCmPrefix => \"OpenGL ES-CM\"u8;")
              .WrtLine("internal static ReadOnlySpan<byte> OpenGlEsCxPrefix => \"OpenGL ES-CX\"u8;")
              .WrtLine("internal static ReadOnlySpan<byte> OpenGlEsPrefix => \"OpenGL ES\"u8;")
              .WrtLine("internal static ReadOnlySpan<byte> OpenGlScPrefix => \"OpenGL SC\"u8;")
              .WrtLine()
              .WrtLine("internal static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor, out bool isEmbedded)")
              .WrtLine('{')
              .AddIndentation()
                .WrtLine("if (value.StartsWith(OpenGlEsCmPrefix))")
                .WrtLine('{')
                .AddIndentation()
                    .WrtLine("value = value[(OpenGlEsCmPrefix.Length + 1)..];")
                    .WrtLine("isEmbedded = true;")
                .RemoveIndentation()
                .WrtLine('}')
                .WrtLine("else if (value.StartsWith(OpenGlEsCxPrefix))")
                .WrtLine('{')
                .AddIndentation()
                    .WrtLine("value = value[(OpenGlEsCxPrefix.Length + 1)..];")
                    .WrtLine("isEmbedded = true;")
                .RemoveIndentation()
                .WrtLine('}')
                .WrtLine("else if (value.StartsWith(OpenGlEsPrefix))")
                .WrtLine('{')
                .AddIndentation()
                    .WrtLine("value = value[(OpenGlEsPrefix.Length + 1)..];")
                    .WrtLine("isEmbedded = true;")
                .RemoveIndentation()
                .WrtLine('}')
                .WrtLine("else if (value.StartsWith(OpenGlScPrefix))")
                .WrtLine('{')
                .AddIndentation()
                    .WrtLine("value = value[(OpenGlScPrefix.Length + 1)..];")
                    .WrtLine("isEmbedded = true;")
                .RemoveIndentation()
                .WrtLine('}')
                .WrtLine("else")
                .WrtLine('{')
                .AddIndentation()
                    .WrtLine("isEmbedded = false;")
                .RemoveIndentation()
                .WrtLine('}')
                .WrtLine()
                .WrtLine("return TryParseVersion(value, out major, out minor);")
              .RemoveIndentation()
              .WrtLine('}');
    }
}