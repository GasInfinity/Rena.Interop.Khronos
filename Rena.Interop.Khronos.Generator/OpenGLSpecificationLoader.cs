using Rena.Interop.Khronos.Generator.Util;

namespace Rena.Interop.Khronos.Generator;

public sealed class OpenGLSpecificationLoader() : ISpecificationLoader
{
    public string PrettyEnumPrefix => "GL_";

    public void WriteCommandsWithLoadingClasses(IndentingStringBuilder builder,
                                                SpecificationOptions options,
                                                IEnumerable<Feature> includedFeatures, 
                                                IReadOnlyDictionary<string, Extension> includedExtensions,
                                                IReadOnlyDictionary<string, Command> includedCommands)
    { 
        bool hasGL3 = includedFeatures.Any(f => f.Number.Major >= 3);
        builder.WriteLine("public unsafe sealed class Commands");

        using(builder.EnterBlock())
        {
            builder.WriteLine("public readonly ushort Major;");
            builder.WriteLine("public readonly ushort Minor;");
            builder.WriteLine("public readonly bool IsEmbedded;");
            builder.WriteLine();

            foreach(ApiVersion v in includedFeatures.Select(f => f.Number).Distinct())
                builder.WriteLine($"public readonly bool Version{v.Major}{v.Minor};"); 

            if(includedExtensions.Count > 0)
            {
                builder.WriteLine();

                foreach((var ext, _) in includedExtensions)
                    builder.WriteLine($"public readonly bool {ext};"); 
            }

            builder.WriteLine();

            builder.WriteLine($"public Commands(delegate* unmanaged<byte*, void*> {Generation.LoadFunctionParameterName})");

            using (builder.EnterBlock())
            {
                builder.WriteLine(true, $$"""
                {{Generation.ToFixedLoadStatement("GetStringUtf8", "GetString", "delegate* unmanaged<StringName, GLubyte*>")}} 
                if(GetString == null) return;

                var version = GetString(StringName.Version);
                if(version is null) return;
                if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor, out IsEmbedded)) return;

                """);

                foreach(ApiVersion v in includedFeatures.Select(f => f.Number).Distinct())
                    builder.WriteLine($"Version{v.Major}{v.Minor} = Major > {v.Major} || (Major == {v.Major} && Minor >= {v.Minor});"); 

                if (includedExtensions.Count > 0)
                {
                    builder.WriteLine();
                    builder.WriteLine("static bool CompatIsExtensionSupported(ReadOnlySpan<byte> allExtensions, ReadOnlySpan<byte> extension) => allExtensions.IndexOf(extension) != -1;");
                    builder.WriteLine();

                    if(hasGL3)
                    {
                        // TODO: We could maybe use a FrozenDictionary and some more things?
                        builder.WriteLine(true, $$"""
                        static bool IsExtensionSupported(ReadOnlySpan<nint> extensionStrings, ReadOnlySpan<int> extensionLengths, ReadOnlySpan<byte> extension)
                        {
                            for(int i = 0; i < extensionStrings.Length; ++i)
                            {
                                if(MemoryMarshal.CreateReadOnlySpan(ref ((byte*)extensionStrings[i])[0], extensionLengths[i]).SequenceEqual(extension))
                                    return true;
                            }

                            return false;
                        }
                        """);

                        builder.WriteLine("if(Version30)");

                        using(builder.EnterBlock())
                        {
                            builder.WriteLine($$"""
                            {{Generation.ToFixedLoadStatement("GetStringiUtf8", "GetStringi", "delegate* unmanaged<StringName, GLuint, GLubyte*>")}}
                            {{Generation.ToFixedLoadStatement("GetIntegervUtf8", "GetIntegerv", "delegate* unmanaged<GetPName, GLint*, void>")}}
                            """);
                            
                            builder.WriteLine(true, $$"""
                            int extensionsLength;
                            GetIntegerv(GetPName.NumExtensions, (GLint*)&extensionsLength);

                            byte[] pointerDataLengths = ArrayPool<byte>.Shared.Rent(extensionsLength * sizeof(int));
                            byte[] pointerData = ArrayPool<byte>.Shared.Rent(extensionsLength * sizeof(nint));
                            Span<nint> extensions = MemoryMarshal.Cast<byte, nint>(pointerData.AsSpan()[..(extensionsLength * sizeof(nint))]);
                            Span<int> extensionsLengths = MemoryMarshal.Cast<byte, int>(pointerDataLengths.AsSpan()[..(extensionsLength * sizeof(int))]);
                            
                            for(int e = 0; e < extensionsLength; ++e)
                            {
                                byte* extensionPtr = (byte*)GetStringi(StringName.Extensions, (uint)e);
                                ReadOnlySpan<byte> extension = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(extensionPtr);
                                extensions[e] = (nint)extensionPtr;
                                extensionsLengths[e] = extension.Length;
                            }
                            """);

                            foreach((string extName, var ext) in includedExtensions)
                            {
                                builder.WriteLine($"this.{extName} = IsExtensionSupported(extensions, extensionsLengths, {extName}Utf8);");
                            }

                            builder.WriteLine(true, $"""
                            ArrayPool<byte>.Shared.Return(pointerDataLengths); 
                            ArrayPool<byte>.Shared.Return(pointerData); 
                            """);
                        }

                        builder.Write("else ");
                    }

                    builder.WriteLine($"if({(hasGL3 ? "!Version30" : "true")})");

                    using(builder.EnterBlock())
                    {
                        builder.WriteLine(true, $$"""
                        var allExtensionsPointer = GetString(StringName.Extensions);
                        ReadOnlySpan<byte> allExtensions = allExtensionsPointer != null ? MemoryMarshal.CreateReadOnlySpanFromNullTerminated(allExtensionsPointer) : default;

                        if(allExtensions.Length > 0)
                        """); 

                        using(builder.EnterBlock())
                        {
                            foreach ((string name, var extension) in includedExtensions)
                                builder.WriteLine($"this.{name} = CompatIsExtensionSupported(allExtensions, {name}Utf8);");
                        }
                    }
                }

                foreach(var feature in includedFeatures)
                {
                    builder.WriteLine();
                    builder.WriteLine($"if({(feature.Apis.Contains(KhronosApi.GL) ? "!" : string.Empty)}IsEmbedded && Version{feature.Number.Major}{feature.Number.Minor})");
                    using(builder.EnterBlock())
                    {
                        foreach(var req in feature.Requires)
                        {
                            if(req.Profile != ApiProfile.None && req.Profile != options.Profile)
                                continue;

                            foreach((var name, _) in req.Commands)
                            {
                                if(!includedCommands.TryGetValue(name, out var command))
                                    continue;

                                builder.WriteLine($"{Generation.ToFixedLoadStatement($"{name["gl".Length..]}Utf8", $"this.{name["gl".Length..]}", $"{command.SharpPointerType}")}");
                            }
                        }
                    }
                }

                foreach((string extName, var extension) in includedExtensions)
                {
                    builder.WriteLine();
                    builder.WriteLine($"if(this.{extName})");
                    using(builder.EnterBlock())
                    {
                        foreach(var req in extension.Requires)
                        {
                            if(req.Profile != ApiProfile.None && req.Profile != options.Profile)
                                continue;

                            foreach((var name, _) in req.Commands)
                            {
                                if(!includedCommands.TryGetValue(name, out var command))
                                    continue;

                                builder.WriteLine($"{Generation.ToFixedLoadStatement($"{name["gl".Length..]}Utf8", $"this.{name["gl".Length..]}", $"{command.SharpPointerType}")}");
                            }
                        }
                    }
                }

                builder.WriteLine();
                foreach((var name, var command) in includedCommands.Where(kv => !string.IsNullOrEmpty(kv.Value.Alias)))
                {
                    if(!includedCommands.TryGetValue(command.Alias, out Command a))
                        continue;

                    builder.WriteLine($"if(this.{command.Alias["gl".Length..]} == null && this.{name["gl".Length..]} != null) this.{command.Alias["gl".Length..]} = {(a.SharpPointerType != command.SharpPointerType ? $"({a.SharpPointerType})": string.Empty)}this.{name["gl".Length..]};"); 
                }
            }

            builder.WriteLine();
            foreach((var name, var command) in includedCommands)
                builder.WriteLine($"public readonly {command.SharpPointerType} {name["gl".Length..]};"); 

            builder.WriteLine();
            foreach((var name, _) in includedCommands)
                builder.WriteLine($"public static ReadOnlySpan<byte> {name["gl".Length..]}Utf8 => \"{name}\"u8;"); 

            if(includedExtensions.Count > 0)
            {
                builder.WriteLine();

                foreach((var ext, _) in includedExtensions)
                    builder.WriteLine($"public static ReadOnlySpan<byte> {ext}Utf8 => \"{ext}\"u8;"); 
            }

            builder.WriteLine(true, $$"""

            private static ReadOnlySpan<byte> OpenGLESCMPrefix => "OpenGL ES-CM"u8;
            private static ReadOnlySpan<byte> OpenGLESCXPrefix => "OpenGL ES-CX"u8;
            private static ReadOnlySpan<byte> OpenGLESPrefix => "OpenGL ES"u8;
            private static ReadOnlySpan<byte> OpenGLSCPrefix => "OpenGL SC"u8;

            private static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor, out bool isEmbedded)
            {
                if(value.StartsWith(OpenGLESCMPrefix))
                {
                    value = value[(OpenGLESCMPrefix.Length + 1)..];
                    isEmbedded = true;
                }
                else if(value.StartsWith(OpenGLESCXPrefix))
                {
                    value = value[(OpenGLESCXPrefix.Length + 1)..];
                    isEmbedded = true;
                }
                else if(value.StartsWith(OpenGLESPrefix))
                {
                    value = value[(OpenGLESPrefix.Length + 1)..];
                    isEmbedded = true;
                }
                else if(value.StartsWith(OpenGLSCPrefix))
                {
                    value = value[(OpenGLSCPrefix.Length + 1)..];
                    isEmbedded = true;
                }
                else
                {
                    isEmbedded = false;
                }

                return TryParseVersion(value, out major, out minor);
            }
            
            private static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor)
            {
                var dotIndex = value.IndexOf((byte)'.');
                var spaceIndex = value.IndexOf((byte)' ');

                if(dotIndex == -1)
                {
                    (major, minor) = (default, default);
                    return false;
                }

                var fromFirstDot = value[(dotIndex + 1)..];
                var nextDot = fromFirstDot.IndexOf((byte)'.');
                var lastIndex = nextDot != -1 ? nextDot : (spaceIndex != -1 ? spaceIndex : fromFirstDot.Length);

                if(Utf8Parser.TryParse(value[..dotIndex], out major, out _) && Utf8Parser.TryParse(fromFirstDot[..lastIndex], out minor, out _))
                    return true;

                major = minor = 0;
                return false;
            }
            """);
        }
    }
}
