using Rena.Interop.Khronos.Generator.Util;

namespace Rena.Interop.Khronos.Generator;

// HACK: Finish Inline Arrays and that's it
public sealed class VulkanSpecificationLoader() : ISpecificationLoader
{
    private static bool IsGlobalCommand(string name, Command c)
    {
        if(name == "vkGetInstanceProcAddr") // Special function...
            return true;

        IType first = c.Parameters.First().Value.Type.PointerStrippedType;

        if(first is KnownType)
            return true;

        return first is UnknownType u && ((u.Name != "VkInstance" && u.Name.StartsWith("VkInstance")) || (u.Name != "VkPhysicalDevice" && u.Name.StartsWith("VkPhysicalDevice")));
    }

    private static bool IsInstanceCommand(string name, Command c)
        => name == "vkGetDeviceProcAddr" || c.Parameters.First().Value.Type.PointerStrippedType is UnknownType u && (u.Name == "VkInstance" || u.Name == "VkPhysicalDevice");

    public string PrettyEnumPrefix => "VK_";

    public void WriteCommandsWithLoadingClasses(IndentingStringBuilder builder,
                                                SpecificationOptions options,
                                                IEnumerable<Feature> includedFeatures, 
                                                IReadOnlyDictionary<string, Extension> includedExtensions, 
                                                IReadOnlyDictionary<string, Command> includedCommands)
    {
        bool hasVk11 = includedFeatures.Any(f => f.Number.Minor >= 1);

        Dictionary<string, Command> globalCommands = includedCommands.Where(static kv => IsGlobalCommand(kv.Key, kv.Value)).ToDictionary();
        Dictionary<string, Command> instanceCommands = includedCommands.Except(globalCommands).Where(static kv => IsInstanceCommand(kv.Key, kv.Value)).ToDictionary();
        Dictionary<string, Command> deviceCommands = includedCommands.Except(globalCommands).Except(instanceCommands).ToDictionary();

        Dictionary<string, Extension> instanceExtensions = includedExtensions.Where(kv => kv.Value.Type == "instance").ToDictionary();
        Dictionary<string, Extension> deviceExtensions = includedExtensions.Except(instanceExtensions).ToDictionary();
        
        builder.WriteLine("public unsafe static class Utilities");

        using(builder.EnterBlock())
        {
            builder.WriteLine("public static void DecodeApiVersion(uint version, out ushort major, out ushort minor, out ushort patch)");

            using(builder.EnterIndentedRegion())
                builder.WriteLine("=> (major, minor, patch) = ((ushort)((version >> 22) & 0x7FU), (ushort)((version >> 12) & 0x3FFU), (ushort)(version & 0xFFFU));");

            builder.WriteLine();
            builder.WriteLine(true, $$"""
            public static bool IsExtensionSupported(ReadOnlySpan<nint> extensionStrings, ReadOnlySpan<byte> extension)
            {
                for(int i = 0; i < extensionStrings.Length; ++i)
                {
                    if(MemoryMarshal.CreateReadOnlySpanFromNullTerminated((byte*)extensionStrings[i]).SequenceEqual(extension))
                        return true;
                }

                return false;
            } 
            """);
        }

        builder.WriteLine("public unsafe sealed class GlobalCommands");

        using(builder.EnterBlock())
        {
            builder.WriteLine("public readonly ushort InstanceMajor;");
            builder.WriteLine("public readonly ushort InstanceMinor;");
            builder.WriteLine("public readonly ushort InstancePatch;");
            builder.WriteLine();

            foreach(Feature feature in includedFeatures)
                builder.WriteLine($"public readonly bool Version{feature.Number.Major}{feature.Number.Minor};"); 

            builder.WriteLine();
            builder.WriteLine($"public GlobalCommands(delegate* unmanaged<VkInstance, byte*, void*> {Generation.LoadFunctionParameterName})");

            using (builder.EnterBlock())
            {
                if(hasVk11)
                {
                    builder.WriteLine(true, $$"""
                    {{Generation.ToFixedLoadStatement("EnumerateInstanceVersionUtf8", "this.EnumerateInstanceVersion", "delegate* unmanaged<uint*, VkResult>", null, "null")}}

                    if(this.EnumerateInstanceVersion != null)
                    {
                        uint apiVersion;
                        EnumerateInstanceVersion(&apiVersion); 
                        Utilities.DecodeApiVersion(apiVersion, out InstanceMajor, out InstanceMinor, out InstancePatch);
                    }
                    else
                    {
                        (InstanceMajor, InstanceMinor, InstancePatch) = (1, 0, 0);
                    }
                    """);
                }
                else
                {
                    builder.WriteLine("(InstanceMajor, InstanceMinor, InstancePatch) = (1, 0, 0);");
                }

                builder.WriteLine();
                foreach(Feature feature in includedFeatures)
                {
                    ApiVersion version = feature.Number;
                    builder.WriteLine($"Version{version.Major}{version.Minor} = InstanceMajor > {version.Major} || (InstanceMajor == {version.Major} && InstanceMinor >= {version.Minor});"); 
                }

                foreach(Feature feature in includedFeatures)
                {
                    ApiVersion version = feature.Number;

                    builder.WriteLine();
                    builder.WriteLine($"if(Version{feature.Number.Major}{feature.Number.Minor})");
                    using(builder.EnterBlock())
                    {
                        foreach(var req in feature.Requires)
                        {
                            foreach((var name, _) in req.Commands)
                            {
                                if(!globalCommands.TryGetValue(name, out var command))
                                    continue;

                                builder.WriteLine($"{Generation.ToFixedLoadStatement($"{name["vk".Length..]}Utf8", $"this.{name["vk".Length..]}", $"{command.SharpPointerType}", null, "null")}");
                            }
                        }
                    }
                }
            }

            builder.WriteLine();

            foreach((var name, var command) in globalCommands)
                builder.WriteLine($"public readonly {command.SharpPointerType} {name["vk".Length..]};");

            builder.WriteLine();
            foreach((var name, _) in globalCommands)
                builder.WriteLine($"public static ReadOnlySpan<byte> {name["vk".Length..]}Utf8 => \"{name}\"u8;");
        }

        builder.WriteLine();
        builder.WriteLine("public unsafe sealed class InstanceCommands");

        using(builder.EnterBlock())
        {
            builder.WriteLine($"public readonly GlobalCommands GVk;");

            if(instanceExtensions.Count > 0)
            {
                builder.WriteLine();

                foreach((var ext, _) in instanceExtensions)
                    builder.WriteLine($"public readonly bool {ext};"); 
            }

            builder.WriteLine();
            builder.WriteLine($"public InstanceCommands(VkInstance instance, ReadOnlySpan<nint> enabledExtensions, GlobalCommands gvk)");

            using (builder.EnterBlock())
            {
                builder.WriteLine($"var loader = gvk.GetInstanceProcAddr;");
                builder.WriteLine("this.GVk = gvk;");

                if (instanceExtensions.Count > 0)
                {
                    builder.WriteLine();
                    
                    foreach((var extName, var extension) in instanceExtensions)
                        builder.WriteLine($"this.{extName} = Utilities.IsExtensionSupported(enabledExtensions, {extName}Utf8);");
                }

                foreach(Feature feature in includedFeatures)
                {
                    ApiVersion version = feature.Number;

                    builder.WriteLine();
                    builder.WriteLine($"if(gvk.Version{feature.Number.Major}{feature.Number.Minor})");
                    using(builder.EnterBlock())
                    {
                        foreach(var req in feature.Requires)
                        {
                            foreach((var name, _) in req.Commands)
                            {
                                if(!instanceCommands.TryGetValue(name, out var command))
                                    continue;

                                builder.WriteLine($"{Generation.ToFixedLoadStatement($"{name["vk".Length..]}Utf8", $"this.{name["vk".Length..]}", $"{command.SharpPointerType}", null, "instance")}");
                            }
                        }
                    }
                }

                builder.WriteLine();
                foreach((var name, var command) in instanceCommands.Where(kv => !string.IsNullOrEmpty(kv.Value.Alias)))
                {
                    if(!instanceCommands.ContainsKey(command.Alias))
                        continue;

                    builder.WriteLine($"if(this.{command.Alias["vk".Length..]} == null && this.{name["vk".Length..]} != null) this.{command.Alias["vk".Length..]} = this.{name["vk".Length..]};"); 
                }
            }

            builder.WriteLine();
            foreach((var name, var command) in instanceCommands)
                builder.WriteLine($"public readonly {command.SharpPointerType} {name["vk".Length..]};");

            builder.WriteLine();
            foreach((var name, _) in instanceCommands)
                builder.WriteLine($"public static ReadOnlySpan<byte> {name["vk".Length..]}Utf8 => \"{name}\"u8;");

            if(instanceExtensions.Count > 0)
            {
                builder.WriteLine();
                
                builder.Write("public static ReadOnlySpan<byte> AllExtensions => \"");
                
                foreach((var ext, _) in instanceExtensions)
                    builder.Write($"{ext}\\0");

                builder.WriteLine("\"u8;");
                builder.WriteLine();

                int lastIndex = 0;
                foreach((var ext, _) in instanceExtensions)
                {
                    builder.WriteLine($"public static ReadOnlySpan<byte> {ext}Utf8 => AllExtensions.Slice({lastIndex}, {ext.Length});");
                    lastIndex += ext.Length + 1; // Zero terminated
                }
            }
        }

        builder.WriteLine();
        builder.WriteLine("public unsafe sealed class DeviceCommands");

        using(builder.EnterBlock())
        {
            builder.WriteLine("public readonly InstanceCommands IVk;");
            builder.WriteLine();

            foreach(Feature feature in includedFeatures)
                builder.WriteLine($"public readonly bool Version{feature.Number.Major}{feature.Number.Minor};"); 

            if(deviceExtensions.Count > 0)
            {
                builder.WriteLine();

                foreach((var ext, _) in deviceExtensions)
                    builder.WriteLine($"public readonly bool {ext};"); 
            }

            builder.WriteLine();
            builder.WriteLine($"public DeviceCommands(VkDevice device, ushort major, ushort minor, ReadOnlySpan<nint> enabledExtensions, InstanceCommands ivk)");

            using (builder.EnterBlock())
            {
                builder.WriteLine($"var loader = ivk.GetDeviceProcAddr;");
                builder.WriteLine("this.IVk = ivk;"); 
                
                foreach(Feature feature in includedFeatures)
                {
                    ApiVersion version = feature.Number;
                    builder.WriteLine($"Version{version.Major}{version.Minor} = major > {version.Major} || (major == {version.Major} && minor >= {version.Minor});"); 
                }
                
                if (deviceExtensions.Count > 0)
                {
                    builder.WriteLine();
                    
                    foreach((var extName, var extension) in deviceExtensions)
                        builder.WriteLine($"this.{extName} = Utilities.IsExtensionSupported(enabledExtensions, {extName}Utf8);");
                }

                foreach(Feature feature in includedFeatures)
                {
                    ApiVersion version = feature.Number;

                    builder.WriteLine();
                    builder.WriteLine($"if(Version{feature.Number.Major}{feature.Number.Minor})");
                    using(builder.EnterBlock())
                    {
                        foreach(var req in feature.Requires)
                        {
                            foreach((var name, _) in req.Commands)
                            {
                                if(!deviceCommands.TryGetValue(name, out var command))
                                    continue;

                                builder.WriteLine($"{Generation.ToFixedLoadStatement($"{name["vk".Length..]}Utf8", $"this.{name["vk".Length..]}", $"{command.SharpPointerType}", null, "device")}");
                            }
                        }
                    }
                }

                builder.WriteLine();
                foreach((var name, var command) in deviceCommands.Where(kv => !string.IsNullOrEmpty(kv.Value.Alias)))
                {
                    if(!deviceCommands.ContainsKey(command.Alias))
                        continue;

                    builder.WriteLine($"if(this.{command.Alias["vk".Length..]} == null && this.{name["vk".Length..]} != null) this.{command.Alias["vk".Length..]} = this.{name["vk".Length..]};"); 
                }
            }

            builder.WriteLine();
            foreach((var name, var command) in deviceCommands)
                builder.WriteLine($"public readonly {command.SharpPointerType} {name["vk".Length..]};");

            builder.WriteLine();
            foreach((var name, _) in deviceCommands)
                builder.WriteLine($"public static ReadOnlySpan<byte> {name["vk".Length..]}Utf8 => \"{name}\"u8;");

            if(deviceExtensions.Count > 0)
            {
                builder.WriteLine();
                
                builder.Write("public static ReadOnlySpan<byte> AllExtensions => \"");
                
                foreach((var ext, _) in deviceExtensions)
                    builder.Write($"{ext}\\0");

                builder.WriteLine("\"u8;");
                builder.WriteLine();

                int lastIndex = 0;
                foreach((var ext, _) in deviceExtensions)
                {
                    builder.WriteLine($"public static ReadOnlySpan<byte> {ext}Utf8 => AllExtensions.Slice({lastIndex}, {ext.Length});");
                    lastIndex += ext.Length + 1; // Zero terminated
                }
            }
        }
    }
}
