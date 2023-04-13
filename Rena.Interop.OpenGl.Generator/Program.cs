// See https://aka.ms/new-console-template for more information
using System.Xml;
using System.CommandLine;
using Rena.Interop.OpenGl.Generator;

using Version = Rena.Interop.OpenGl.Generator.Version;

public static class Program
{
    private static readonly Option<Api> ApiOption = new("--api", "Select the api to use") { IsRequired = true };

    private static readonly Option<GlProfile> ProfileOption = new("--profile", () => GlProfile.None, "Select the OpenGL profile to use (Only affects output when api=Gl)");

    private static readonly Option<string> OutputOption = new("--output", "The path where the files are generated") { IsRequired = true };

    private static readonly Option<string> ClassNameOption = new("--class-name", "The class name to use when generating the files") { IsRequired = true };

    private static readonly Option<string> NamespaceOption = new("--namespace", "The namespace to use when generating the files") { IsRequired = true };

    private static readonly Option<string> VersionOption = new("--api-version", "The version to use when generating the files") { IsRequired = true };

    public static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("OpenGL related bindings generator")
        {
            ApiOption,
            ProfileOption,
            OutputOption,
            ClassNameOption,
            NamespaceOption,
            VersionOption
        };

        rootCommand.SetHandler(Generate, ApiOption, ProfileOption, OutputOption, ClassNameOption, NamespaceOption, VersionOption);
        return await rootCommand.InvokeAsync(args);
    }
    public static void DisplayIntAndString(int delayOptionValue, string messageOptionValue)
    {
        Console.WriteLine($"--delay = {delayOptionValue}");
        Console.WriteLine($"--message = {messageOptionValue}");
    }
    private static async Task Generate(Api api, GlProfile profile, string output, string className, string @namespace, string version)
    {
        if (!Version.TryParse(version, out var realVersion))
            return;

        Console.WriteLine($"Generating for {api} with profile {profile}");
        using HttpClient client = new();
        var url = GetSpecUrl(api);
        var xml = await client.GetStringAsync(url);
        Console.WriteLine($"Downloaded xml from {url}");
        XmlDocument xmlDoc = new();
        xmlDoc.LoadXml(xml);
        Console.WriteLine("Loaded xml");
        Registry registry = new(xmlDoc.DocumentElement!);
        Console.WriteLine("Parsed xml");

        Console.WriteLine("Starting generation");
        Generator gen = new(registry, new()
        {
            OutputPath = output,
            ClassName = className,
            Namespace = @namespace,
            Api = api,
            Profile = profile,
            Version = realVersion,
        });

        gen.Generate();
    }

    private static string GetSpecUrl(Api api)
        => api switch
        {
            Api.Gl or Api.Gles1 or Api.Gles2 => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/gl.xml",
            Api.Egl => "https://raw.githubusercontent.com/KhronosGroup/EGL-Registry/main/api/egl.xml",
            Api.Glw => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/wgl.xml",
            Api.Glx => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/glx.xml",
            Api.Glsc2 => "",
            _ => string.Empty
        };
}