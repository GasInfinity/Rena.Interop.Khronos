using System.Xml;
using System.CommandLine;
using System.Collections.Immutable;
using System.CommandLine.Invocation;
using Rena.Interop.Khronos.Generator.Util;

namespace Rena.Interop.Khronos.Generator;

// TODO Refactor this mess again :skull:
public static class Program
{
    private static readonly Option<KhronosSpecification> SpecOption = new("--spec", "Select the spec to use")
    { 
        IsRequired = true,
        Arity = ArgumentArity.ExactlyOne
    };

    private static readonly Option<(KhronosApi, ApiVersion)[]> ApisOption = new("--apis", r => 
    {
        if((r.Tokens.Count & 1) != 0)
        {
            r.ErrorMessage = "--apis requires an even number of arguments";
            return [];
        }
        
        int apisLength = r.Tokens.Count / 2;
        (KhronosApi, ApiVersion)[] apis = new (KhronosApi, ApiVersion)[apisLength];

        int currentApi = 0;
        for(int i = 0; i < r.Tokens.Count; i += 2)
        {
            if(!System.Enum.TryParse(r.Tokens[i].Value, out KhronosApi api))
            {
                r.ErrorMessage = $"Invalid API: {r.Tokens[i].Value}";
                return [];
            }

            if(!ApiVersion.TryParse(r.Tokens[i + 1].Value, out ApiVersion v))
            {
                r.ErrorMessage = $"Invalid Version: {r.Tokens[i + 1].Value}";
                return [];
            }

            apis[currentApi++] = (api, v);
        }

        return apis;
    }, false, "Select the apis to use in this format: API Version, e.g: GL 4.6")
    { 
        IsRequired = true,
        AllowMultipleArgumentsPerToken = true,
    };

    private static readonly Option<ApiProfile> ProfileOption = new("--profile", () => ApiProfile.None, "Select the OpenGL profile to use (Only affects output when --apis contain GL)");
    private static readonly Option<string> OutputOption = new("--output", "The path where the file is generated") { IsRequired = true };
    private static readonly Option<string> NamespaceOption = new("--namespace", "The namespace to use when generating the file") { IsRequired = true };
    private static readonly Option<string> ClassNameOption = new("--class-name", "The class name to use when generating the file") { IsRequired = true };
    private static readonly Option<bool> GenAliasesOption = new("--gen-aliases", "Whether to generate aliases or not [e.g if(glDrawElementsBaseVertex is null) glDrawElementsBaseVertex = glDrawElementsBaseVertexEXT;]") { Arity = ArgumentArity.ZeroOrOne };
    private static readonly Option<string[]> ExtensionsOption = new("--extensions", () => Array.Empty<string>(), "The extensions of the apis to add") { Arity = ArgumentArity.OneOrMore, AllowMultipleArgumentsPerToken = true };

    private static Dictionary<KhronosSpecification, HashSet<KhronosApi>> SpecSupportedApis = new()
    {
        { KhronosSpecification.GL, [KhronosApi.GL, KhronosApi.GLES1, KhronosApi.GLES2, KhronosApi.GLSC2 ] },
        { KhronosSpecification.Vulkan, [KhronosApi.Vulkan, KhronosApi.VulkanSC ] },
        { KhronosSpecification.EGL, [KhronosApi.EGL] },
        { KhronosSpecification.WGL, [KhronosApi.WGL] },
        { KhronosSpecification.GLX, [KhronosApi.GLX] },
    };

    private static Dictionary<KhronosSpecification, ISpecificationLoader> SpecLoaders = new()
    {
        { KhronosSpecification.GL, new OpenGLSpecificationLoader() },
        { KhronosSpecification.Vulkan, new VulkanSpecificationLoader() },
        { KhronosSpecification.WGL, new WGLSpecificationLoader() },
        // TODO: Finish this!
        // { KhronosSpecification.EGL, new EGLSpecificationLoader() },
    };

    public static Task Main(string[] args)
    {
        var rootCommand = new RootCommand("Khronos related bindings generator")
        {
            SpecOption,
            ApisOption,
            ProfileOption,
            OutputOption,
            NamespaceOption,
            ClassNameOption,
            GenAliasesOption,
            ExtensionsOption,
        };

        rootCommand.SetHandler(Generate);
        return rootCommand.InvokeAsync(args);
    }

    private static async Task Generate(InvocationContext context)
    {
        KhronosSpecification spec = context.ParseResult.GetValueForOption(SpecOption);
        (KhronosApi, ApiVersion)[] apis = context.ParseResult.GetValueForOption(ApisOption)!;
        ApiProfile profile = context.ParseResult.GetValueForOption(ProfileOption);
        string output = context.ParseResult.GetValueForOption(OutputOption)!;
        string nmspace = context.ParseResult.GetValueForOption(NamespaceOption)!;
        string className = context.ParseResult.GetValueForOption(ClassNameOption)!;
        ImmutableHashSet<string> extensions = context.ParseResult.GetValueForOption(ExtensionsOption)!.ToImmutableHashSet();
        bool genAliases = context.ParseResult.GetValueForOption(GenAliasesOption);

        HashSet<KhronosApi> supportedApis = SpecSupportedApis[spec];

        foreach((var a, _) in apis)
        {
            if(!supportedApis.Contains(a))
            {
                context.Console.WriteLine($"Invalid API {a} for spec {spec}. Supported APIS: {string.Join(", ", supportedApis)}");
                return;
            }
        }

        if(!SpecLoaders.ContainsKey(spec))
        {
            context.Console.WriteLine($"Spec {spec} doesn't currently have a loader, sorry!");
            return;
        }

        if(supportedApis.Contains(KhronosApi.GL) && apis.Select(ia => ia.Item1).Any(a => a == KhronosApi.GL) && profile == ApiProfile.None)
        {
            context.Console.WriteLine($"Please, specify an OpenGL profile when generating the GL API.");
            return;
        }

        context.Console.WriteLine($"Downloading registry for {spec}");
        Registry registry = await LoadRegistry(spec);

        if(!Generation.TryCreateDirectories(output, context.Console))
        {
            context.Console.WriteLine($"Halting generation due to not being able to create the directories needed for it.");
            return;
        }

        context.Console.WriteLine($"Beggining generation of {spec} with APIs {string.Join(", ", apis)}");
        SpecificationOptions options = new(
            Namespace: nmspace,
            ClassName: className,
            IncludedApis: apis.ToImmutableArray(),
            IncludedExtensions: extensions,
            Profile: profile,
            SpecLoaders[spec]
        );

        SpecificationGenerator generator = new(registry, options);
        IndentingStringBuilder builder = new();

        builder.WriteLine("// <auto-generated/> ");
        builder.WriteLine($"// CLI args: {string.Join(' ', Environment.GetCommandLineArgs()[1..])}");
        builder.WriteLine();
        builder.WriteLine("using System.Runtime.InteropServices;\nusing System.Runtime.CompilerServices;\nusing System.Buffers;\nusing System.Buffers.Text;", true);
        generator.WriteAliases(builder);
        builder.WriteLine();
        builder.WriteLine($"namespace {nmspace};");
        builder.WriteLine();
        builder.WriteLine($"public static class {className}");

        using(builder.EnterBlock())
        {
            generator.WriteLoader(builder);
            builder.WriteLine();
            generator.WriteConstants(builder);
            generator.WriteTypes(builder);
            generator.WriteEnums(builder);
        }

        File.WriteAllText(output, builder.ToString());
        context.Console.WriteLine($"Written generated contents to {output}");
    }

    private async static Task<Registry> LoadRegistry(KhronosSpecification specification)
    {
        using HttpClient client = new();
        var xml = await client.GetStringAsync(specification.GetFileUrl());
        XmlDocument xmlDoc = new();
        xmlDoc.PreserveWhitespace = true;
        xmlDoc.LoadXml(xml);
        return new Registry(xmlDoc.DocumentElement!);
    }
}
