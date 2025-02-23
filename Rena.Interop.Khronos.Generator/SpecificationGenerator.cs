using Rena.Interop.Khronos.Generator.Util;

namespace Rena.Interop.Khronos.Generator;

public sealed class SpecificationGenerator
{
    private readonly SpecificationOptions options;
    private readonly List<Feature> includedFeatures = [];
    private readonly Dictionary<string, Extension> extensions = [];
    private readonly Dictionary<string, Command> commands = [];
    private readonly Dictionary<string, Constant> constants = [];
    private readonly Dictionary<string, Enum> enums = [];
    private readonly Dictionary<string, (HashSet<string> Enum, string Value)> remappedEnumSymbols = [];
    private readonly Dictionary<string, Type> types = [];

    public SpecificationGenerator(Registry registry, SpecificationOptions options)
    {
        this.options = options;

        IncludeGroupedEnums(registry);
        if(options.IncludedApis.Select(ka => ka.Item1).Any(a => a != KhronosApi.Vulkan && a != KhronosApi.VulkanSC))
        {
            IncludeTypes(registry);
        }

        IncludeFeatures(registry);
        IncludeRequiredTypes(registry); // HACK: Last batch of types, which are mostly XXXFlags in Vulkan
        PrettifyEnums();
    }

    private void IncludeRequiredTypes(Registry registry)
    {
        foreach((var api, var types) in registry.Types)
        {
            if(api != KhronosApi.None && !this.options.IncludedApis.Any(ia => ia.Item1 == api))
                continue;

            foreach((var name, var t) in types) 
            {
                if(!string.IsNullOrEmpty(t.Requires) && this.enums.ContainsKey(t.Requires))
                    this.types.TryAdd(name, t);
            }
        }
    }

    private void IncludeTypes(Registry registry)
    {
        foreach((var api, var types) in registry.Types)
        {
            if(api != KhronosApi.None && !this.options.IncludedApis.Any(ia => ia.Item1 == api))
                continue;

            foreach((var name, var t) in types) 
            {
                this.types.Add(name, t);
            }
        } 
    }

    private void IncludeGroupedEnums(Registry registry)
    {
        foreach((var api, var enms) in registry.Enums)
        {
            if(api != KhronosApi.None && !this.options.IncludedApis.Any(ia => ia.Item1 == api))
                continue;

            foreach((var name, var e) in enms) 
            {
                foreach((var n, var v) in e.Values)
                {
                    if(!this.remappedEnumSymbols.TryGetValue(n, out var pair))
                    {
                        this.remappedEnumSymbols.Add(n, pair = (new(), n));
                    }

                    pair.Enum.Add(name);
                }
            }
        }
    }

    private void IncludeFeatures(Registry registry)
    {
        this.includedFeatures.AddRange(registry.Features.Values.Where(kv => this.options.IncludedApis.Any(ia => kv.Apis.Contains(ia.Item1) && ia.Item2.IsIncluded(kv.Number))).OrderBy(f => f.Number));
        foreach(var feature in this.includedFeatures)
        {
            foreach(var require in feature.Requires)
            {
                if(require.Profile != ApiProfile.None && require.Profile != this.options.Profile)
                    continue;

                IncludeRequire(registry, require);
            }

            foreach(var remove in feature.Removes)
            {
                if(remove.Profile != ApiProfile.None && remove.Profile != this.options.Profile)
                    continue;

                IncludeRemove(registry, remove);
            }
        }

        foreach(var kv in registry.Extensions)
        {
            if(!this.options.IncludedExtensions.Contains(kv.Key) 
            || !kv.Value.Supported.Any(s => this.options.IncludedApis.Select(ia => ia.Item1).Contains(s)))
                continue;

            this.extensions.Add(kv.Key, kv.Value);
        }

        foreach((var name, var extension) in this.extensions)
        {
            foreach(var require in extension.Requires)
            {
                if(require.Profile != ApiProfile.None && require.Profile != this.options.Profile)
                    continue;

                IncludeRequire(registry, require);
            }

            foreach(var remove in extension.Removes)
            {
                if(remove.Profile != ApiProfile.None && remove.Profile != this.options.Profile)
                    continue;

                IncludeRemove(registry, remove);
            }
        }
    }

    private void IncludeRequire(Registry registry, RequireRemove require)
    {
        foreach((var name, var t) in require.Types)
        {
            foreach(var api in Enumerable.Repeat(KhronosApi.None, 1).Concat(this.options.IncludedApis.Select(p => p.Item1)))
            {
                if(registry.Types.TryGetValue(api, out var types) && types.TryGetValue(name, out var type))
                {
                    _ = this.types.TryAdd(name, type);
                    continue;
                }

                if(registry.Enums.TryGetValue(api, out var enms) && enms.TryGetValue(name, out var en))
                {
                    _ = this.enums.TryAdd(name, en);

                    foreach((var vName, var _) in en.Values)
                    {
                        if(!this.remappedEnumSymbols.TryGetValue(vName, out var pair))
                        {
                            this.remappedEnumSymbols.Add(vName, pair = (new(), vName));
                        }

                        pair.Enum.Add(en.Name);
                    }

                    continue;
                }
            }
        }

        foreach((var api, var enums) in require.Enums)
        {
            if(api != KhronosApi.None && !this.options.IncludedApis.Any(ia => ia.Item1 == api))
                continue;

            foreach((var name, var e) in enums)
            {
                if(string.IsNullOrEmpty(e.Extends))
                {
                    if(this.remappedEnumSymbols.TryGetValue(e.Name, out var res))
                    {
                        HashSet<string> symbolEnums = res.Enum;

                        foreach(string enm in symbolEnums)
                        {
                            Enum registryEnum = registry.Enums[api][enm];

                            if(!this.enums.TryGetValue(enm, out Enum includedEnum))
                            {
                                this.enums.Add(enm, includedEnum = new(registryEnum.Name, new(), registryEnum.IsBitmask));
                            }

                            if(!registryEnum.Values.TryGetValue(name, out EnumValue v))
                            {
                                // Happens sometimes, that the enum wants to alias something from the "global" api namespace, as it's not a hot path Linq is my friend
                                registryEnum = registry.Enums.Where(kv => this.options.IncludedApis.Select(ia => ia.Item1).Contains(kv.Key) || kv.Key == KhronosApi.None).Select(kv => kv.Value)
                                                             .Where(enums => enums.ContainsKey(enm))
                                                             .Select(enums => enums[enm])
                                                             .Where(enm => enm.Values.ContainsKey(name)).First();
                                v = registryEnum.Values[name];
                            }

                            while(!string.IsNullOrEmpty(v.Alias)) // Expand aliases, as OpenGL includes enums with an alias, without including the alias...
                            {
                                v = registry.Enums[api][this.remappedEnumSymbols[v.Alias].Enum.First()].Values[v.Alias];
                            }

                            // TryAdd as OpenGL duplicates lots of things....
                            _ = includedEnum.Values.TryAdd(name, registryEnum.Values[name]);
                        }

                        continue;
                    }

                    if(registry.Constants.TryGetValue(name, out Constant c))
                    {
                        this.constants.Add(name, c);
                        continue;
                    }
                    // TODO: Add API Constants 
                }

                if(this.enums.TryGetValue(e.Extends, out var en))
                {
                    en.Values.Add(e.Name, new(e.Alias, e.Value));
                    continue;
                }
            }
        }

        foreach((var name, var c) in require.Commands)
        {
            foreach(var api in Enumerable.Repeat(KhronosApi.None, 1).Concat(this.options.IncludedApis.Select(p => p.Item1)))
            {
                if(registry.Commands.TryGetValue(api, out var comm) && comm.TryGetValue(c.Name, out var co))
                {
                    _ = this.commands.TryAdd(c.Name, co);
                    continue;
                }
            }
        }
    }

    private void IncludeRemove(Registry registry, RequireRemove remove)
    {
        foreach((var name, var t) in remove.Types)
        {
            if(!this.types.Remove(name))
                this.enums.Remove(name);
        }

        foreach((var api, var apiEnums) in remove.Enums)
        {
            if(api != KhronosApi.None && !this.options.IncludedApis.Any(ia => ia.Item1 == api))
                continue;

            foreach((var name, var e) in apiEnums)
            {
                if(this.remappedEnumSymbols.TryGetValue(e.Name, out var symbolPair))
                {
                    foreach(string enm in symbolPair.Enum)
                    {
                        if(!this.enums.TryGetValue(enm, out Enum includedEnum))
                            continue;

                        includedEnum.Values.Remove(e.Name);

                        if(includedEnum.Values.Count == 0)
                        {
                            this.enums.Remove(enm);
                            symbolPair.Enum.Remove(enm);
                        }
                    }
                }
            }
        }

        foreach((var name, var c) in remove.Commands)
        {
            this.commands.Remove(c.Name);
        }
    }

    private void PrettifyEnums()
    {
        Dictionary<string, Enum> addedEnums = this.enums.ToDictionary();
        this.enums.Clear();
        this.remappedEnumSymbols.Clear();
        
        foreach((var enumName, var e) in addedEnums)
        {
            (var mapping, var newEnum) = e.StripLongestCommonSubstringToPascalcase(this.options.Loader.PrettyEnumPrefix);
            
            foreach((var realName, var prettyName) in mapping)
            {
                if(!this.remappedEnumSymbols.TryGetValue(realName, out var pair))
                {
                    this.remappedEnumSymbols.Add(realName, pair = (new(), prettyName));
                }

                pair.Enum.Add(enumName);

            }

            this.enums.Add(enumName, newEnum);
        }
    }

    public void WriteAliases(IndentingStringBuilder builder)
    {
        foreach((var name, var t) in this.types)
        {
            switch(t.TypeKind)
            {
                case Type.Kind.Typedef:
                    {

                        if(t.Data is not string functionPointer)
                        {
                            IType baseType = (t.Data as IType)!;

                            while(baseType is UnknownType u)
                                baseType = (this.types[u.Name].Data as IType)!;

                            if(baseType.PointerStrippedType is StructType or UnknownType)
                            {
                                builder.WriteLine($"using unsafe {name} = global::{this.options.Namespace}.{this.options.ClassName}.{baseType.SharpType};");
                                continue;
                            }

                            builder.WriteLine($"using unsafe {name} = {baseType.SharpType};");
                            continue;
                        }
                        
                        builder.WriteLine($"using unsafe {name} = {functionPointer.Replace("<<NAMESPACE>>", $"global::{this.options.Namespace}.{this.options.ClassName}.")};");
                        break;
                    }
            }
        }
    }

    public void WriteTypes(IndentingStringBuilder builder)
    {
        foreach((var name, var t) in this.types)
        {
            switch(t.TypeKind)
            {
                case Type.Kind.Typedef:
                    {
                        if(t.Data is not IType type)
                            continue;
                        
                        if(type.PointerStrippedType is StructType structType 
                        && !this.types.ContainsKey(structType.SharpType))
                            builder.WriteLine($"public readonly struct {structType.SharpType};");

                        // string typeAliased = type.PointerDepth > 0 ? "nint" : type.SharpType;
                        //
                        // builder.WriteLine($"public readonly unsafe partial record struct {t.Name}({typeAliased} Value)");
                        // using(builder.EnterBlock())
                        // {
                        //     builder.WriteLine($"public readonly {typeAliased} Value = Value;");
                        //     builder.WriteLine($"public static implicit operator {t.Name}({typeAliased} value) => new(value);");
                        //     builder.WriteLine($"public static implicit operator {typeAliased}({t.Name} value) => value.Value;");
                        // }
                        break;
                    }
                case Type.Kind.Handle:
                    {
                        builder.WriteLine($"public readonly unsafe partial record struct {t.Name}(nint Value)");
                        using(builder.EnterBlock())
                        {
                            builder.WriteLine($"public readonly nint Value = Value;");
                            builder.WriteLine($"public static implicit operator {t.Name}(void* value) => new((nint)value);");
                            builder.WriteLine($"public static implicit operator void*({t.Name} value) => (void*)value.Value;");
                            builder.WriteLine($"public static implicit operator nint({t.Name} value) => value.Value;");
                            builder.WriteLine($"public static implicit operator {t.Name}(nint value) => new(value);");
                        }
                        break;
                    }
                case Type.Kind.Struct:
                case Type.Kind.Union:
                    {
                        Type.StructDeclaration declaration = (t.Data as Type.StructDeclaration)!;

                        if(declaration.Fields.Count == 0)
                        {
                            builder.WriteLine($"public readonly struct {t.Name};");
                            break;
                        }

                        if(t.TypeKind == Type.Kind.Union)
                            builder.Write("[StructLayout(LayoutKind.Explicit)] ");

                        builder.WriteLine($"public unsafe struct {t.Name}()");
                        using (builder.EnterBlock())
                        {
                            foreach(((var fieldApi, var fieldName), var field) in declaration.Fields)
                            {
                                if(fieldApi != KhronosApi.None && options.IncludedApis.Select(ia => ia.Item1).Contains(fieldApi))
                                    continue;

                                if(t.TypeKind == Type.Kind.Union)
                                    builder.Write("[FieldOffset(0)] ");

                                if(string.IsNullOrEmpty(field.Value))
                                {
                                    IType fieldType = field.Type;

                                    if(fieldType is ArrayType at)
                                    {
                                        string escapedFieldName = Utilities.EscapeIdentifier(fieldName);
                                        string randomArrayTypeName = Utilities.GenerateRandomIdentifier();
                                        builder.WriteLine($"public {randomArrayTypeName} {escapedFieldName};");
                                        builder.WriteLine($"[InlineArray(unchecked((int){at.Length}))] public struct {randomArrayTypeName} {{ private {at.InnerType.SharpType} _; }}");
                                        continue;
                                    }

                                    builder.WriteLine($"public {fieldType.SharpType} {Utilities.EscapeIdentifier(fieldName)};");
                                    continue; 
                                }

                                if(this.remappedEnumSymbols.TryGetValue(field.Value, out var symbol))
                                {
                                    builder.WriteLine($"public {field.Type.SharpType} {Utilities.EscapeIdentifier(fieldName)} = {symbol.Enum.First()}.{symbol.Value};");
                                    continue;
                                }

                                builder.WriteLine($"public {field.Type.SharpType} {Utilities.EscapeIdentifier(fieldName)} = {field.Value};");
                            }
                        }
                        break;
                    }
            }
            
        }
    }

    public void WriteConstants(IndentingStringBuilder builder)
    {
        if(this.constants.Count == 0)
            return;

        builder.WriteLine($"public static unsafe class Constants");

        using(builder.EnterBlock())
        {
            foreach((var name, var c) in this.constants)
            {
                string sharpValue = c.Value.Replace("UL", "U").Replace("ULL", "UL");
                builder.WriteLine($"public const {c.Type.SharpType} {Utilities.SnakeToPascalcase(name.AsSpan()["VK_".Length..])} = unchecked(({c.Type.SharpType}){sharpValue});");                
            }
        }
    }

    public void WriteEnums(IndentingStringBuilder builder)
    {
        foreach((var name, var e) in this.enums)
        {
            if(e.IsBitmask)
                builder.Write("[Flags] ");

            builder.WriteLine($"public enum {(!string.IsNullOrEmpty(e.Name) ? e.Name : "Ungrouped")} : uint");
            using(builder.EnterBlock())
            {
                foreach((var valueName, var value) in e.Values)
                {
                    builder.Write($"{valueName} = ");

                    if(!string.IsNullOrEmpty(value.Alias))
                    {
                        (HashSet<string> aliasEnum, string prettyName) = this.remappedEnumSymbols[value.Alias];

                        if(!aliasEnum.Contains(name))
                        {
                            string first = aliasEnum.First();
                            builder.Write($"{(!string.IsNullOrEmpty(first) ? first : "Ungrouped")}.");
                        }

                        builder.Write($"{prettyName}");
                    }
                    else
                    {
                        builder.Write($"0x{((uint)value.Value):X}");
                    }

                    builder.WriteLine(",");
                }
            }
        }
    }

    public void WriteLoader(IndentingStringBuilder builder)
    {
        this.options.Loader.WriteCommandsWithLoadingClasses(builder, this.options, this.includedFeatures, this.extensions, this.commands);
    }
}
