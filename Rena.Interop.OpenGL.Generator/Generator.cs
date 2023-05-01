using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.CommandLine;
using static Rena.Interop.OpenGL.Generator.Generation;

namespace Rena.Interop.OpenGL.Generator;

// TODO: Refactor this one day, it's only a MVP
public class Generator
{
    const string LoadFunctionName = "LoadFunction";

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
            LoadedApis = Registry.FeatureList.Where(a => options.GLApis.Where(gl => a.GLApi == gl.Api && gl.Version.IsIncluded(a.Number)).Any()).OrderBy(a => a.Number).ToImmutableArray();
        else
            LoadedApis = Registry.FeatureList.Where(a => a.Api == options.Api && options.ApiVersion.IsIncluded(a.Number)).ToImmutableArray();

        LoadedVersions = LoadedApis.Select(a => a.Number).ToImmutableHashSet().Order().ToImmutableArray();

        if (options.IncludedExtensions.Contains("*"))
            LoadedExtensions = registry.ExtensionsList.SelectMany(e => e.ExtensionList).ToImmutableArray();
        else
            LoadedExtensions = registry.ExtensionsList.SelectMany(e => e.ExtensionList.Where(e => (options.IncludedExtensions?.Contains(e.Name) ?? false))).ToImmutableArray();

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
        console.WriteLine("Generating Util.cs");
        GenerateUtil();
        console.WriteLine("Generating Load.cs");
        GenerateLoader();
        console.WriteLine("Generating Constants.cs");
        GenerateEnums();
        console.WriteLine("Generating FunctionMembers.cs");
        GenerateFunctionMembers();
    }

    private void GenerateUtil()
    {
        var output = $"{Options.OutputPath}/{Options.ClassName}.Util.cs";

        var dirName = Path.GetDirectoryName(output);

        if (!string.IsNullOrEmpty(dirName))
            _ = Directory.CreateDirectory(dirName);

        using FileStream utilFile = File.Create(output);
        using StreamWriter utilWriter = new(utilFile);
        using IndentedTextWriter writer = new(utilWriter);

        writer.WrtLine("using System.Buffers.Text;")
              .WrtLine()
              .WrtLine($"namespace {Options.Namespace};")
              .WrtLine()
              .WrtLine($"public unsafe partial class {Options.ClassName}")
              .WrtLine('{')
              .AddIndentation();
        ApiGenerator.WriteUtilFields(writer);
        writer.RemoveIndentation()
              .WrtLine('}');
    }

    private void GenerateLoader()
    {
        var output = $"{Options.OutputPath}/{Options.ClassName}.Load.cs";

        var dirName = Path.GetDirectoryName(output);

        if (!string.IsNullOrEmpty(dirName))
            _ = Directory.CreateDirectory(dirName);

        using FileStream loaderFile = File.Create(output);
        using StreamWriter loaderWriter = new(loaderFile);
        using IndentedTextWriter writer = new(loaderWriter);

        writer.WrtLine("using System.Buffers;")
              .WrtLine("using System.Runtime.InteropServices;")
              .WrtLine()
              .WrtLine($"namespace {Options.Namespace};")
              .WrtLine()
              .WrtLine($"public unsafe partial class {Options.ClassName}")
              .WrtLine('{')
              .AddIndentation();

        ApiGenerator.WriteRequiredFields(writer);
        ApiGenerator.WriteLoaderFields(writer);

        writer.WrtLine($"public {Options.ClassName}({LoadFunctionName} loadFunc)")
              .WrtLine('{')
              .AddIndentation();
        ApiGenerator.WriteLoadingStatements(writer);
        writer.WriteLine();

        foreach (var version in LoadedVersions)
            writer.WriteLine($"Version{version.Major}{version.Minor} = Major > {version.Major} | (Major == {version.Major} & Minor >= {version.Minor});");

        foreach (var api in LoadedApis)
        {
            writer.WriteLine();
            if (Options.Api is Api.GL)
                writer.WriteLine($"if({(api.GLApi.IsEmbedded() ? string.Empty : "!")}IsEmbedded & Version{api.Number.Major}{api.Number.Minor})");
            else
                writer.WriteLine($"if(Version{api.Number.Major}{api.Number.Minor})");
            writer.WrtLine('{')
                  .AddIndentation();

            foreach (var c in api.Requires.SelectMany(a => a.Commands))
            {
                var command = includedCommands.Find(com => com.Name == c.Name);

                if (command is null)
                    continue;

                GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName(command.Name), $"this.{FunctionNameToSharpFunctionMemberName(ApiGenerator.Prefix, command.Name)}", command.SharpPointerType);
            }

            writer.RemoveIndentation()
                  .WrtLine('}');
        }

        foreach (var extension in LoadedExtensions)
        {
            writer.WriteLine();

            writer.WrtLine($"if({extension.Name})")
                  .WrtLine('{')
                  .AddIndentation();

            foreach (var c in extension.Requires.SelectMany(e => e.Commands))
            {
                var command = includedCommands.Find(com => com.Name == c.Name);

                if (command is null)
                    continue;

                GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName(command.Name), $"this.{FunctionNameToSharpFunctionMemberName(ApiGenerator.Prefix, command.Name)}", command.SharpPointerType);
            }

            writer.RemoveIndentation()
                  .WrtLine('}');
        }

        if (Options.GenerateAliases)
        {
            foreach (var command in includedCommands)
            {
                if (string.IsNullOrEmpty(command.Alias))
                    continue;

                writer.WrtLine($"if(this.{FunctionNameToSharpFunctionMemberName(ApiGenerator.Prefix, command.Alias)} is null)")
                    .AddIndentation()
                    .WrtLine($"this.{FunctionNameToSharpFunctionMemberName(ApiGenerator.Prefix, command.Alias)} = this.{FunctionNameToSharpFunctionMemberName(ApiGenerator.Prefix, command.Name)};")
                    .RemoveIndentation();
            }
        }

        writer.RemoveIndentation()
              .WrtLine('}')
              .RemoveIndentation()
              .WrtLine('}');
    }

    private void GenerateEnums()
    {
        var output = $"{Options.OutputPath}/{Options.ClassName}.Constants.cs";

        var dirName = Path.GetDirectoryName(output);

        if (!string.IsNullOrEmpty(dirName))
            _ = Directory.CreateDirectory(dirName);

        using FileStream enumFile = File.Create(output);
        using StreamWriter enumWriter = new(enumFile);
        using IndentedTextWriter writer = new(enumWriter);

        writer.WriteLine($"namespace {Options.Namespace};");
        writer.WriteLine();
        writer.WriteLine($"public partial class {Options.ClassName}");
        writer.WriteLine('{');
        writer.AddIndentation();
        ApiGenerator.WriteConstants(writer);
        writer.RemoveIndentation();
        writer.WriteLine('}');
    }

    private void GenerateFunctionMembers()
    {
        var output = $"{Options.OutputPath}/{Options.ClassName}.FunctionMembers.cs";

        var dirName = Path.GetDirectoryName(output);

        if (!string.IsNullOrEmpty(dirName))
            _ = Directory.CreateDirectory(dirName);

        using FileStream functionsFile = File.Create(output);
        using StreamWriter functionsWriter = new(functionsFile);
        using IndentedTextWriter writer = new(functionsWriter);

        writer.WriteLine($"namespace {Options.Namespace};");
        writer.WriteLine();
        writer.WriteLine($"public unsafe partial class {Options.ClassName}");
        writer.WriteLine('{');
        writer.AddIndentation();
        ApiGenerator.WriteFunctionMembers(writer);
        writer.RemoveIndentation();
        writer.WriteLine('}');
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

            var c = Registry.CommandsList.SelectMany(c => c.CommandList).First(com => com.Name == command.Name);
            includedCommands.Add(c);
        }

        foreach (var specEnum in requires.Enums)
        {
            if (includedEnums.Find(e => e.Name == specEnum.Name) is not null)
                continue;

            var e = Registry.EnumsList.SelectMany(e => e.Enums).First(@enum => @enum.Name == specEnum.Name);
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
}