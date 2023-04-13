namespace Rena.Interop.OpenGl.Generator;

public class GeneratorOptions
{
    public string Namespace { get; init; } = string.Empty;
    public string ClassName { get; init; } = string.Empty;
    public string OutputPath { get; init; } = string.Empty;

    public Api Api { get; init; } = Api.None;
    public GlProfile Profile { get; init; }
    public Version Version { get; init; }
    public string[] IncludedExtensions { get; init; } = Array.Empty<string>();
}