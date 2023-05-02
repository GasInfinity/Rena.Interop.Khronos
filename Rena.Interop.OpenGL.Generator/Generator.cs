using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.CommandLine;
using static Rena.Interop.OpenGL.Generator.Generation;

namespace Rena.Interop.OpenGL.Generator;

public class Generator
{
    private readonly IConsole console;
    private readonly List<Command> includedCommands = new();
    private readonly List<SpecEnum> includedEnums = new();

    public readonly ApiGenerator ApiGenerator;
    public readonly ImmutableArray<ApiVersion> LoadedVersions;
    public readonly ImmutableArray<Feature> LoadedApis;
    public readonly ImmutableArray<Extension> LoadedExtensions;
    public GeneratorOptions Options { get; }
    public Registry Registry { get; }

    public IReadOnlyList<Command> IncludedCommands
        => includedCommands;

    public IReadOnlyList<SpecEnum> IncludedEnums
        => includedEnums;

    public Generator(Registry registry, GeneratorOptions options, IConsole console)
    {
        this.console = console;

        Registry = registry;
        Options = options;

        if (Options.Api is Api.GL)
            LoadedApis = Registry.FeatureList.Where(a => options.GLApis.Any(gl => a.GLApi == gl.Api && gl.Version.IsIncluded(a.Number))).OrderBy(a => a.Number).ToImmutableArray();
        else
            LoadedApis = Registry.FeatureList.Where(a => a.Api == options.Api && options.ApiVersion.IsIncluded(a.Number)).ToImmutableArray();

        LoadedVersions = LoadedApis.Select(a => a.Number).ToImmutableHashSet().Order().ToImmutableArray();

        if (options.IncludedExtensions.Contains("*"))
            LoadedExtensions = registry.ExtensionsList.SelectMany(e => e.ExtensionList).ToImmutableArray();
        else
            LoadedExtensions = registry.ExtensionsList.SelectMany(e => e.ExtensionList.Where(e => options.IncludedExtensions?.Contains(e.Name) ?? false)).ToImmutableArray();

        LoadIncludedApis();
        LoadIncludedExtensions();

        ApiGenerator = options.Api switch // TODO: GLX and WGL
        {
            Api.GL => new GLApiGenerator(this),
            Api.EGL => new EGLApiGenerator(this),
            _ => throw new NotImplementedException()
        };
    }

    public void Generate()
    {
        if (Options.GenerateSingleFile)
            GenerateSingleFile();
        else
            GenerateMultipleFiles();
    }

    private void GenerateSingleFile()
    {
        var fileName = NameToSharpFileName(Options.ClassName);
        console.WriteLine($"Generating single file '{fileName}'");

        var filePath = $"{Options.OutputPath}/{fileName}";
        if (TryCreateDirectories(filePath, console))
        {
            console.WriteLine("Stopping generation due to one or more errors");
            return;
        }

        try
        {
            using FileStream file = File.OpenWrite(filePath);
            using StreamWriter fileWriter = new(file);
            using IndentedTextWriter fileIndentedWriter = new(fileWriter);

            fileIndentedWriter.WrtLine("using System.Buffers;")
                              .WrtLine("using System.Buffers.Text;")
                              .WrtLine("using System.Runtime.InteropServices;")
                              .WrtLine()
                              .WrtLine($"namespace {Options.Namespace};")
                              .WrtLine()
                              .WrtLine($"public unsafe class {Options.ClassName}")
                              .WrtLine('{')
                              .AddIndentation();
            ApiGenerator.WriteUtilFields(fileIndentedWriter);
            fileIndentedWriter.WriteLine();
            ApiGenerator.WriteConstants(fileIndentedWriter);
            fileIndentedWriter.WriteLine();
            ApiGenerator.WriteFunctionMembers(fileIndentedWriter);
            fileIndentedWriter.WriteLine();
            ApiGenerator.WriteLoading(fileIndentedWriter);
            fileIndentedWriter.RemoveIndentation()
                              .WrtLine('}');
        }
        catch (Exception exception)
        {
            console.WriteLine($"Stopping generation of file '{fileName}' due to an unexpected exception. Exception: {exception}");
        }
    }

    private void GenerateMultipleFiles()
    {
        if (!TryGenerateFile(FileKind.Util))
            return;

        if (!TryGenerateFile(FileKind.Loader))
            return;

        if (!TryGenerateFile(FileKind.Constants))
            return;

        if (!TryGenerateFile(FileKind.Functions))
            return;
    }

    private bool TryGenerateFile(FileKind kind)
    {
        var fileName = NameToSharpFileName($"{Options.ClassName}.{kind}");
        var filePath = $"{Options.OutputPath}/{fileName}";

        console.WriteLine($"Generating file '{fileName}'");

        if (!TryCreateDirectories(filePath, console))
        {
            console.WriteLine($"Stopping generation of file '{fileName}' due to one or more errors");
            return false;
        }

        try
        {
            using FileStream file = File.OpenWrite(filePath);
            using StreamWriter fileWriter = new(file);
            using IndentedTextWriter fileIndentedWriter = new(fileWriter);

            fileIndentedWriter.WrtLine("using System.Buffers;")
                              .WrtLine("using System.Buffers.Text;")
                              .WrtLine("using System.Runtime.InteropServices;")
                              .WrtLine()
                              .WrtLine($"namespace {Options.Namespace};")
                              .WrtLine()
                              .WrtLine($"public unsafe partial class {Options.ClassName}")
                              .WrtLine('{')
                              .AddIndentation();

            switch (kind)
            {
                case FileKind.Util:
                    {
                        ApiGenerator.WriteUtilFields(fileIndentedWriter);
                        break;
                    }
                case FileKind.Loader:
                    {
                        ApiGenerator.WriteLoading(fileIndentedWriter);
                        break;
                    }
                case FileKind.Constants:
                    {
                        ApiGenerator.WriteConstants(fileIndentedWriter);
                        break;
                    }
                case FileKind.Functions:
                    {
                        ApiGenerator.WriteFunctionMembers(fileIndentedWriter);
                        break;
                    }
            }

            fileIndentedWriter.RemoveIndentation()
                              .WrtLine('}');
            return true;
        }
        catch (Exception exception)
        {
            console.WriteLine($"Stopping generation of file '{fileName}' due to an unexpected exception. Exception: {exception}");
            return false;
        }
    }

    private void LoadIncludedApis()
    {
        foreach (var api in LoadedApis)
        {
            foreach (var requires in api.Requires)
                LoadRequires(requires);

            foreach (var removes in api.Removes)
                LoadRemoves(removes);
        }
    }

    private void LoadIncludedExtensions()
    {
        foreach (var extension in LoadedExtensions)
        {
            if (extension.Supported != Options.Api
            || (extension.Supported is Api.GL & (extension.SupportedProfile is not GLProfile.None & extension.SupportedProfile != Options.Profile)
            && !extension.GLSupported.Any(gl => Options.GLApis.Select(g => g.Api).Contains(gl))))
                continue;

            foreach (var requires in extension.Requires)
                LoadRequires(requires);

            foreach (var removes in extension.Removes)
                LoadRemoves(removes);
        }
    }

    private void LoadRequires(RequireRemove requires)
    {
        if (requires.Profile is not GLProfile.None & (requires.GLApi is GLApi.GL & requires.Profile != Options.Profile))
            return;

        foreach (var command in requires.Commands)
        {
            if (includedCommands.Find(c => c.Name == command.Name) is not null)
                continue;

            var c = Registry.CommandsList.SelectMany(c => c.CommandList).FirstOrDefault(com => com.Name == command.Name);

            if (c is null) // Shouldn't happen
                continue;

            includedCommands.Add(c);
        }

        foreach (var specEnum in requires.Enums)
        {
            if (includedEnums.Find(e => e.Name == specEnum.Name) is not null)
                continue;

            var e = Registry.EnumsList.SelectMany(e => e.Enums).FirstOrDefault(@enum => @enum.Name == specEnum.Name);

            if (e is null) // Shouldn't happen
                continue;

            includedEnums.Add(e);
        }
    }

    private void LoadRemoves(RequireRemove removes)
    {
        if (removes.Profile is not GLProfile.None & (removes.GLApi is GLApi.GL & removes.Profile != Options.Profile))
            return;

        foreach (var command in removes.Commands)
            includedCommands.RemoveAll(c => c.Name == command.Name);

        foreach (var specEnum in removes.Enums)
            includedEnums.RemoveAll(e => e.Name == specEnum.Name);
    }

    private enum FileKind
    {
        Util,
        Loader,
        Constants,
        Functions
    }
}