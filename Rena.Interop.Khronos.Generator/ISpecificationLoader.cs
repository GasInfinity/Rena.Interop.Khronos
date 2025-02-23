using Rena.Interop.Khronos.Generator.Util;

namespace Rena.Interop.Khronos.Generator;

public interface ISpecificationLoader
{
    string PrettyEnumPrefix { get; }

    void WriteCommandsWithLoadingClasses(IndentingStringBuilder builder,
                                         SpecificationOptions options,
                                         IEnumerable<Feature> includedFeatures, 
                                         IReadOnlyDictionary<string, Extension> includedExtensions,
                                         IReadOnlyDictionary<string, Command> includedCommands);
}
