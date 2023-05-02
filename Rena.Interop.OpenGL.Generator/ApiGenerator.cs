using System.CodeDom.Compiler;
using System.Globalization;
using static Rena.Interop.OpenGL.Generator.Generation;

namespace Rena.Interop.OpenGL.Generator;

public abstract class ApiGenerator
{
    public abstract string Prefix { get; }
    public Generator MainGenerator { get; }

    protected ApiGenerator(Generator generator)
        => MainGenerator = generator;

    public void WriteLoading(IndentedTextWriter writer)
    {
        WriteRequiredFields(writer);
        WriteLoaderFields(writer);

        var options = MainGenerator.Options;
        var loadedVersions = MainGenerator.LoadedVersions;
        var loadedApis = MainGenerator.LoadedApis;
        var loadedExtensions = MainGenerator.LoadedExtensions;
        var includedCommands = MainGenerator.IncludedCommands;
        var includedEnums = MainGenerator.IncludedEnums;

        writer.WrtLine($"public {options.ClassName}({LoadFunctionTypeName} loadFunc)")
              .WrtLine('{')
              .AddIndentation();
        WriteLoadingStatements(writer);
        writer.WriteLine();

        foreach (var version in loadedVersions)
            writer.WriteLine($"Version{version.Major}{version.Minor} = Major > {version.Major} | (Major == {version.Major} & Minor >= {version.Minor});");

        foreach (var api in loadedApis)
        {
            writer.WriteLine();
            if (options.Api is Api.GL)
                writer.WriteLine($"if({(api.GLApi.IsEmbedded() ? string.Empty : "!")}IsEmbedded & Version{api.Number.Major}{api.Number.Minor})");
            else
                writer.WriteLine($"if(Version{api.Number.Major}{api.Number.Minor})");
            writer.WrtLine('{')
                  .AddIndentation();

            foreach (var c in api.Requires.SelectMany(a => a.Commands))
            {
                var command = includedCommands.FirstOrDefault(com => com.Name == c.Name);

                if (command is null)
                    continue;

                GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName(command.Name), $"this.{FunctionNameToSharpFunctionMemberName(Prefix, command.Name)}", command.SharpPointerType);
            }

            writer.RemoveIndentation()
                  .WrtLine('}');
        }

        foreach (var extension in loadedExtensions)
        {
            writer.WriteLine();

            writer.WrtLine($"if({extension.Name})")
                  .WrtLine('{')
                  .AddIndentation();

            foreach (var c in extension.Requires.SelectMany(e => e.Commands))
            {
                var command = includedCommands.FirstOrDefault(com => com.Name == c.Name);

                if (command is null)
                    continue;

                GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName(command.Name), $"this.{FunctionNameToSharpFunctionMemberName(Prefix, command.Name)}", command.SharpPointerType);
            }

            writer.RemoveIndentation()
                  .WrtLine('}');
        }

        if (options.GenerateAliases)
        {
            foreach (var command in includedCommands)
            {
                if (string.IsNullOrEmpty(command.Alias))
                    continue;

                var aliasedFunction = FunctionNameToSharpFunctionMemberName(Prefix, command.Alias);
                var realFunction = FunctionNameToSharpFunctionMemberName(Prefix, command.Name);

                writer.WrtLine($"if(this.{aliasedFunction} is null)")
                    .AddIndentation()
                    .WrtLine($"this.{aliasedFunction} = this.{realFunction};")
                    .RemoveIndentation();
            }
        }

        writer.RemoveIndentation()
              .WrtLine('}');
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
            GenerateSharpFunctionMember(writer, Prefix, command);
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

    protected virtual void WriteRequiredFields(IndentedTextWriter writer)
    {
        writer.WriteLine($"public delegate void* {LoadFunctionTypeName}(byte* name);");
    }

    protected virtual void WriteLoaderFields(IndentedTextWriter writer)
    {
        if (!MainGenerator.LoadedApis.IsDefaultOrEmpty)
        {
            writer.WrtLine("public readonly ushort Major;")
                  .WrtLine("public readonly ushort Minor;")
                  .WrtLine();

            foreach (var version in MainGenerator.LoadedVersions)
                writer.WriteLine($"public readonly bool Version{version.Major}{version.Minor};");

            writer.WriteLine();
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

    protected virtual void WriteLoadingStatements(IndentedTextWriter writer)
    {
    }
}