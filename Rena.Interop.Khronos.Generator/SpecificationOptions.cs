using System.Collections.Immutable;

namespace Rena.Interop.Khronos.Generator;

public readonly record struct SpecificationOptions(string Namespace, string ClassName, ImmutableArray<(KhronosApi, ApiVersion)> IncludedApis, ImmutableHashSet<string> IncludedExtensions, ApiProfile Profile, ISpecificationLoader Loader)
{
    public readonly string Namespace = Namespace;
    public readonly string ClassName = ClassName;
    public readonly ImmutableArray<(KhronosApi, ApiVersion)> IncludedApis = IncludedApis;
    public readonly ImmutableHashSet<string> IncludedExtensions = IncludedExtensions;
    public readonly ApiProfile Profile = Profile;
    public readonly ISpecificationLoader Loader = Loader;
}
