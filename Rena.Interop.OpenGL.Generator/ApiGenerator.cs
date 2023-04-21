using System.CodeDom.Compiler;
using System.Globalization;
using static Rena.Interop.OpenGL.Generator.Generation;

namespace Rena.Interop.OpenGL.Generator;

public abstract class ApiGenerator
{
    public abstract string Prefix { get; }
    public Generator MainGenerator { get; }

    public ApiGenerator(Generator generator)
        => MainGenerator = generator;

    public virtual void WriteRequiredFields(IndentedTextWriter writer)
    {
        writer.WriteLine($"public delegate void* {LoadFunctionTypeName}(byte* name);");
    }

    public virtual void WriteLoaderFields(IndentedTextWriter writer)
    {
        if (!MainGenerator.LoadedApis.IsDefaultOrEmpty)
        {
            writer.WrtLine("public readonly ushort Major;")
                  .WrtLine("public readonly ushort Minor;")
                  .WrtLine();

            foreach (var version in MainGenerator.LoadedVersions)
                writer.WriteLine($"public readonly bool Version{version.Major}{version.Minor};");
        }

        var loadedExtensions = MainGenerator.LoadedExtensions;

        if (!loadedExtensions.IsDefaultOrEmpty)
        {
            writer.WriteLine();

            foreach (var extension in loadedExtensions)
            {
                writer.WrtLine($"internal static ReadOnlySpan<byte> {ExtensionToUtf8ExtensionName(extension.Name)} => \"{extension.Name}\"u8;")
                      .WrtLine($"public readonly bool {extension.Name};");
            }

            writer.WriteLine();
        }
    }

    public virtual void WriteLoadingStatements(IndentedTextWriter writer)
    {
    }

    public virtual void WriteFunctionDeclarations(IndentedTextWriter writer)
    {
        foreach (var command in MainGenerator.IncludedCommands)
            GenerateSharpFunction(writer, Prefix, command);
    }

    public virtual void WriteConstants(IndentedTextWriter writer)
    {
        foreach (var @enum in MainGenerator.IncludedEnums)
            GenerateSharpConstant(writer, @enum);
    }

    public virtual void WriteFunctionMembers(IndentedTextWriter writer)
    {
        foreach (var command in MainGenerator.IncludedCommands)
        {
            GenerateSharpUtf8FunctionName(writer, command);
            GenerateSharpFunctionMember(writer, command);
        }
    }

    public virtual void WriteUtilFields(IndentedTextWriter writer)
    {
        writer.WrtLine("const byte DotAscii = (byte)'.';")
              .WrtLine("const byte SpaceAscii = (byte)' ';")
              .WrtLine()
              .WrtLine("internal static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor)")
              .WrtLine('{')
              .AddIndentation()
                .WrtLine("var dotIndex = value.IndexOf(DotAscii);")
                .WrtLine("var spaceIndex = value.IndexOf(SpaceAscii);")
                .WrtLine()
                .WrtLine("if (dotIndex == -1)")
                .WrtLine('{')
                .AddIndentation()
                    .WrtLine("(major, minor) = (default, default);")
                    .WrtLine("return false;")
                .RemoveIndentation()
                .WrtLine('}')
                .WrtLine()
                .WrtLine("var fromFirstDot = value[(dotIndex + 1)..];")
                .WrtLine("var nextDot = fromFirstDot.IndexOf(DotAscii);")
                .WrtLine("var lastIndex = nextDot != -1 ? nextDot : (spaceIndex != -1 ? spaceIndex : fromFirstDot.Length);")
                .WrtLine()
                .WrtLine("if (Utf8Parser.TryParse(value[..dotIndex], out major, out _) && Utf8Parser.TryParse(fromFirstDot[..lastIndex], out minor, out _))")
                .AddIndentation()
                    .WrtLine("return true;")
                .RemoveIndentation()
                .WrtLine()
                .WrtLine("major = minor = 0;")
                .WrtLine("return false;")
              .RemoveIndentation()
              .WrtLine('}');
    }
}