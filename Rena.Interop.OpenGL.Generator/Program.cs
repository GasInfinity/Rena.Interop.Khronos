using System.Xml;
using System.CommandLine;
using System.Collections.Immutable;
using System.CommandLine.Invocation;

namespace Rena.Interop.OpenGL.Generator;

public static class Program
{
    private static readonly Option<Api> ApiOption = new("--api", "Select the api to use") { IsRequired = true };

    private static readonly Option<GLApi[]> GLApisOption = new("--gl-apis", () => Array.Empty<GLApi>(), "Select the GL apis to use") { Arity = ArgumentArity.OneOrMore, AllowMultipleArgumentsPerToken = true };
    private static readonly Option<string[]> GLVersionsOption = new("--gl-versions", () => Array.Empty<string>(), "Select the GL api versions to use (Length must match with provided apis)") { Arity = ArgumentArity.OneOrMore, AllowMultipleArgumentsPerToken = true };
    private static readonly Option<GLProfile> ProfileOption = new("--profile", () => GLProfile.Compatibility, "Select the OpenGL profile to use (Only affects output when --api=GL and --gl-apis contains GL)");
    private static readonly Option<string> OutputOption = new("--output", "The path where the files are generated") { IsRequired = true };
    private static readonly Option<string> ClassNameOption = new("--class-name", "The class name to use when generating the files") { IsRequired = true };
    private static readonly Option<string> NamespaceOption = new("--namespace", "The namespace to use when generating the files") { IsRequired = true };
    private static readonly Option<string> ApiVersionOption = new("--api-version", () => string.Empty, "The version to use when generating the files") { };
    private static readonly Option<string[]> ApiExtensionsOption = new("--api-extensions", () => Array.Empty<string>(), "The extensions to generate (Supports '*' wildcard to generate every extension you want)") { Arity = ArgumentArity.OneOrMore, AllowMultipleArgumentsPerToken = true };
    private static readonly Option<bool> GenAliasesOption = new("--gen-aliases", "Whether to generate aliases or not [e.g if(glDrawElementsBaseVertex is null) glDrawElementsBaseVertex = glDrawElementsBaseVertexEXT;]") { Arity = ArgumentArity.ZeroOrOne };
    private static readonly Option<bool> GenSingleFileOption = new("--gen-single-file", "Whether to generate in multiple files or only one") { Arity = ArgumentArity.ZeroOrOne };

    public static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("OpenGL related bindings generator")
        {
            ApiOption,
            GLApisOption,
            GLVersionsOption,
            ProfileOption,
            OutputOption,
            ClassNameOption,
            NamespaceOption,
            ApiVersionOption,
            ApiExtensionsOption,
            GenAliasesOption,
            GenSingleFileOption
        };

        rootCommand.SetHandler(Generate);
        return await rootCommand.InvokeAsync(args);
    }

    private static async Task Generate(InvocationContext context)
    {
        Api api = context.ParseResult.GetValueForOption(ApiOption);
        GLApi[] glApis = context.ParseResult.GetValueForOption(GLApisOption)!;
        string[] glVersionsString = context.ParseResult.GetValueForOption(GLVersionsOption)!;
        GLProfile glProfile = context.ParseResult.GetValueForOption(ProfileOption);
        string output = context.ParseResult.GetValueForOption(OutputOption)!;
        string className = context.ParseResult.GetValueForOption(ClassNameOption)!;
        string @namespace = context.ParseResult.GetValueForOption(NamespaceOption)!;
        string apiVersionString = context.ParseResult.GetValueForOption(ApiVersionOption)!;
        string[] extensions = context.ParseResult.GetValueForOption(ApiExtensionsOption)!;
        bool genAliases = context.ParseResult.GetValueForOption(GenAliasesOption);
        bool genSingleFile = context.ParseResult.GetValueForOption(GenSingleFileOption);

        ApiVersion apiVersion = default;

        if (api is not Api.GL)
            apiVersion = ApiVersion.Parse(apiVersionString);

        if (glApis.Length != glVersionsString.Length)
            throw new InvalidOperationException($"Mismatch between GL apis and GL versions!");

        ImmutableArray<ApiVersion> glVersions = glVersionsString.Select(v => ApiVersion.Parse(v)).ToImmutableArray();

        var totalGLApisBuilder = ImmutableArray.CreateBuilder<(GLApi, ApiVersion)>(glApis.Length);

        for (int i = 0; i < glApis.Length; ++i)
            totalGLApisBuilder.Add((glApis[i], glVersions[i]));

        var totalGLApis = totalGLApisBuilder.MoveToImmutable();
        var url = GetSpecUrl(api);
        context.Console.WriteLine($"Generating for '{api}'");

        if (totalGLApis.Length > 0)
        {
            foreach (var glApi in totalGLApis)
                context.Console.WriteLine($"With GLApi '{glApi.Item1}' version '{glApi.Item2}'");

            context.Console.WriteLine($"With profile '{glProfile}'");
        }

        context.Console.WriteLine($"Downloading registry for {api}");
        Registry registry = await LoadRegistry(api);

        context.Console.WriteLine("Starting generation");
        Generator gen = new(registry, new()
        {
            OutputPath = output,
            ClassName = className,
            Namespace = @namespace,
            Api = api,
            GLApis = totalGLApis,
            Profile = glProfile,
            ApiVersion = apiVersion,
            IncludedExtensions = extensions.ToImmutableHashSet(),
            GenerateAliases = genAliases,
            GenerateSingleFile = genSingleFile,
        }, context.Console);

        gen.Generate();
    }

    private async static Task<Registry> LoadRegistry(Api api)
    {
        using HttpClient client = new();
        var xml = await client.GetStringAsync(GetSpecUrl(api));
        XmlDocument xmlDoc = new();
        xmlDoc.LoadXml(xml);
        return new Registry(xmlDoc.DocumentElement!);
    }

    private static string GetSpecUrl(Api api)
        => api switch
        {
            Api.GL => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/gl.xml",
            Api.EGL => "https://raw.githubusercontent.com/KhronosGroup/EGL-Registry/main/api/egl.xml",
            Api.WGL => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/wgl.xml",
            Api.GLX => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/glx.xml",
            _ => string.Empty
        };
}