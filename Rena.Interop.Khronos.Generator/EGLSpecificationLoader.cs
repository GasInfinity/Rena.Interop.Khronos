using Rena.Interop.Khronos.Generator.Util;

namespace Rena.Interop.Khronos.Generator;

public sealed class EGLSpecificationLoader : ISpecificationLoader
{
    public string PrettyEnumPrefix => "EGL_";

    public void WriteCommandsWithLoadingClasses(IndentingStringBuilder builder, 
                                                SpecificationOptions options,
                                                IEnumerable<Feature> includedFeatures,
                                                IReadOnlyDictionary<string, Extension> includedExtensions,
                                                IReadOnlyDictionary<string, Command> includedCommands)
    {
        builder.WriteLine("public unsafe sealed class Commands");

        using(builder.EnterBlock())
        {
            builder.WriteLine("public readonly ushort Major;");
            builder.WriteLine("public readonly ushort Minor;");
            builder.WriteLine();

            foreach(Feature feature in includedFeatures)
                builder.WriteLine($"public readonly bool Version{feature.Number.Major}{feature.Number.Minor};"); 

            if(includedExtensions.Count > 0)
            {
                builder.WriteLine();

                foreach((var ext, _) in includedExtensions)
                    builder.WriteLine($"public readonly bool {ext};"); 
            }
            
            builder.WriteLine();
            builder.WriteLine($"public Commands(EGLDisplay display, delegate* unmanaged<byte*, void*> {Generation.LoadFunctionParameterName})");

            using (builder.EnterBlock())
            {
                builder.WriteLine(true, $$"""
                {{Generation.ToFixedLoadStatement("QueryStringUtf8", "QueryString", "delegate* unmanaged<EGLDisplay, Ungrouped, GLubyte*>")}} 
                {{Generation.ToFixedLoadStatement("GetErrorUtf8", "GetError", "delegate* unmanaged<EGLint>")}} 
                if(QueryString == null || GetError == null) return;

                var version = QueryString((EGLDisplay)null, Ungrouped.Version);
                if(version is null) return;
                if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor, out IsEmbedded)) return;

                """);
            }
        }
    }
}
