using System.Collections.Immutable;

namespace Rena.Interop.OpenGL.Generator;

public class GeneratorOptions
{
    public required string Namespace { get; init; } = string.Empty;
    public required string ClassName { get; init; } = string.Empty;
    public required string OutputPath { get; init; } = string.Empty;

    public required Api Api { get; init; }
    public required ImmutableArray<(GLApi Api, ApiVersion Version)> GLApis { get; init; } = ImmutableArray<(GLApi, ApiVersion)>.Empty;
    public required GLProfile Profile { get; init; }
    public ApiVersion ApiVersion { get; init; }
    public required ImmutableHashSet<string> IncludedExtensions { get; init; } = ImmutableHashSet<string>.Empty;
}