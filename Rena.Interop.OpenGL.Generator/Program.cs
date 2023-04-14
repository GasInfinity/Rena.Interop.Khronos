using System.Xml;
using System.CommandLine;

namespace Rena.Interop.OpenGL.Generator;

public static class Program
{
    private static readonly Option<Api> ApiOption = new("--api", "Select the api to use") { IsRequired = true };

    private static readonly Option<GLProfile> ProfileOption = new("--profile", () => GLProfile.None, "Select the OpenGL profile to use (Only affects output when api=Gl)");

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
    private static async Task Generate(Api api, GLProfile profile, string output, string className, string @namespace, string version)
    {
        if (!Version.TryParse(version, out var realVersion))
            return;

        var url = GetSpecUrl(api);

        if(string.IsNullOrEmpty(url))
        {
            Console.WriteLine($"Can't download xml for api '{api}', url not implemented!");
            return;
        }

        Console.WriteLine($"Generating for '{api}' with profile '{profile}'");
        using HttpClient client = new();
        var xml = await client.GetStringAsync(url);
        Console.WriteLine($"Downloaded xml from {url}");
        XmlDocument xmlDoc = new();
        xmlDoc.LoadXml(xml);
        Registry registry = new(xmlDoc.DocumentElement!);

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
            Api.GL or Api.GLES1 or Api.GLES2 => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/gl.xml",
            Api.EGL => "https://raw.githubusercontent.com/KhronosGroup/EGL-Registry/main/api/egl.xml",
            Api.GLW => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/wgl.xml",
            Api.GLX => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/main/xml/glx.xml",
            Api.GLSC2 => string.Empty,
            _ => string.Empty
        };
}