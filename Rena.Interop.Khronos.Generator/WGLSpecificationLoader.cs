using Rena.Interop.Khronos.Generator.Util;

namespace Rena.Interop.Khronos.Generator;

// For WGL it only makes sense to load extensions
public sealed class WGLSpecificationLoader : ISpecificationLoader
{
    public string PrettyEnumPrefix => "WGL_";

    public void WriteCommandsWithLoadingClasses(IndentingStringBuilder builder, 
                                                SpecificationOptions options,
                                                IEnumerable<Feature> includedFeatures,
                                                IReadOnlyDictionary<string, Extension> includedExtensions,
                                                IReadOnlyDictionary<string, Command> includedCommands)
    {
        Dictionary<string, Command> extensionCommands = includedCommands.Where(kv => includedFeatures.Any(f => f.Requires.Any(r => !r.Commands.ContainsKey(kv.Key)))).ToDictionary();

        builder.WriteLine("public unsafe sealed class ExtensionCommands");
        using(builder.EnterBlock())
        {
            if(includedExtensions.Count > 0)
            {
                foreach((var ext, _) in includedExtensions)
                    builder.WriteLine($"public readonly bool {ext};"); 

                builder.WriteLine();
            }

            builder.WriteLine($"public Commands(nint hdc, delegate* unmanaged<byte*, void*> {Generation.LoadFunctionParameterName})");

            using (builder.EnterBlock())
            {
                bool hasEXTExtensionsString = includedExtensions.ContainsKey("WGL_EXT_extensions_string");
                bool hasARBExtensionsString = includedExtensions.ContainsKey("WGL_ARB_extensions_string");

                builder.WriteLine("static bool IsExtensionSupported(ReadOnlySpan<byte> allExtensions, ReadOnlySpan<byte> extension) => allExtensions.IndexOf(extension) != -1;");

                if(hasARBExtensionsString)
                    builder.WriteLine(Generation.ToFixedLoadStatement("GetExtensionsStringARBUtf8", "GetExtensionsStringARB", "delegate* unmanaged<void*, byte*>"));

                if(hasEXTExtensionsString)
                    builder.WriteLine(Generation.ToFixedLoadStatement("GetExtensionsStringEXTUtf8", "GetExtensionsStringEXT", "delegate* unmanaged<byte*>"));

                if(hasARBExtensionsString)
                {
                    builder.WriteLine($"if(this.GetExtensionsStringARB != null)");

                    using(builder.EnterBlock())
                        WriteExtensionLoading(builder, includedExtensions, "this.GetExtensionsStringARB(hdc)");
                }

                if(hasEXTExtensionsString)
                {
                    if(hasARBExtensionsString)
                        builder.Write("else ");

                    builder.WriteLine($"if(this.GetExtensionsStringEXT != null)");

                    using(builder.EnterBlock())
                        WriteExtensionLoading(builder, includedExtensions, "this.GetExtensionsStringEXT()");
                }

                builder.WriteLine($"{(hasEXTExtensionsString || hasARBExtensionsString ? "else" : string.Empty)}");

                using(builder.EnterBlock())
                {
                    builder.WriteLine("delegate* unmanaged<uint, byte*> glGetString;");
                    builder.WriteLine($"{Generation.ToFixedLoadStatement("GLGetStringUtf8", "glGetString", "delegate* unmanaged<uint, byte*>")}");
                    WriteExtensionLoading(builder, includedExtensions, "glGetString(0x1F03u /* GL_EXTENSIONS */)");
                }

                foreach((string extName, var extension) in includedExtensions)
                {
                    builder.WriteLine();
                    builder.WriteLine($"if(this.{extName})");
                    using(builder.EnterBlock())
                    {
                        foreach(var req in extension.Requires)
                        {
                            foreach((var name, _) in req.Commands)
                            {
                                if(!includedCommands.TryGetValue(name, out var command))
                                    continue;
                
                                ReadOnlySpan<char> normalizedName = name.StartsWith("wgl") ? name["wgl".Length..] : name;
                                builder.WriteLine($"{Generation.ToFixedLoadStatement($"{normalizedName}Utf8", $"this.{normalizedName}", $"{command.SharpPointerType}")}");
                            }
                        }
                    }
                }
            }

            if(extensionCommands.Count > 0)
            {
                builder.WriteLine();
                foreach((var name, var command) in extensionCommands)
                {
                    ReadOnlySpan<char> normalizedName = name.StartsWith("wgl") ? name["wgl".Length..] : name;
                    builder.WriteLine($"public readonly {command.SharpPointerType} {normalizedName};"); 
                }

                builder.WriteLine();
                foreach((var name, _) in extensionCommands)
                {
                    ReadOnlySpan<char> normalizedName = name.StartsWith("wgl") ? name["wgl".Length..] : name;
                    builder.WriteLine($"public static ReadOnlySpan<byte> {normalizedName}Utf8 => \"{name}\"u8;"); 
                }
            }

            builder.WriteLine("public static ReadOnlySpan<byte> GLGetStringUtf8 => \"glGetString\";");

            if(includedExtensions.Count > 0)
            {
                builder.WriteLine();

                foreach((var ext, _) in includedExtensions)
                    builder.WriteLine($"public static ReadOnlySpan<byte> {ext}Utf8 => \"{ext}\"u8;"); 
            }
        }
    }
    
    private void WriteExtensionLoading(IndentingStringBuilder builder, IReadOnlyDictionary<string, Extension> includedExtensions, string loadingExpression)
    {
        builder.WriteLine(true, $$"""
        var allExtensionsPointer = {{loadingExpression}};
        ReadOnlySpan<byte> allExtensions = allExtensionsPointer != null ? MemoryMarshal.CreateReadOnlySpanFromNullTerminated(allExtensionsPointer) : default;

        if(allExtensions.Length > 0)
        """); 

        using(builder.EnterBlock())
        {
            foreach ((string name, var extension) in includedExtensions)
                builder.WriteLine($"this.{name} = IsExtensionSupported(allExtensions, {name}Utf8);");
        } 
    }
}
