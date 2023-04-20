using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Globalization;
using System.Text;

namespace Rena.Interop.OpenGL.Generator;

// TODO: Refactor this one day, it's only a MVP
public class Generator
{
    const string LoadFunctionName = "LoadFunction";

    private readonly string apiPrefix;

    private readonly List<Command> includedCommands = new();
    private readonly List<SpecEnum> includedEnums = new();
    private readonly Dictionary<Command, string> functionTypeMap = new();

    private readonly ImmutableArray<ApiVersion> versions;
    private readonly ImmutableArray<Feature> apis;
    private readonly ImmutableArray<Extension> extensions;
    public GeneratorOptions Options { get; }
    public Registry Registry { get; }


    public Generator(Registry registry, GeneratorOptions options)
    {
        Registry = registry;
        Options = options;

        if (Options.Api is Api.GL)
        {
            apis = Registry.FeatureList.Where(a => options.GLApis.Where(gl => a.GLApi == gl.Api && gl.Version.IsIncluded(a.Number)).Any()).OrderBy(a => a.Number).ToImmutableArray();
        }
        else
        {
            apis = Registry.FeatureList.Where(a => a.Api == options.Api && options.ApiVersion.IsIncluded(a.Number)).ToImmutableArray();
        }

        versions = apis.Select(a => a.Number).ToImmutableHashSet().Order().ToImmutableArray();
        apiPrefix = options.Api.GetPrefix();

        if (options.IncludedExtensions.Contains("*"))
            extensions = registry.ExtensionsList.SelectMany(e => e.ExtensionList).ToImmutableArray();
        else
            extensions = registry.ExtensionsList.SelectMany(e => e.ExtensionList.Where(e => (options.IncludedExtensions?.Contains(e.Name) ?? false))).ToImmutableArray();

        LoadIncludedApis();
        LoadIncludedExtensions();
    }

    public void Generate()
    {
        GenerateUtil();
        GenerateLoader();
        GenerateEnums();
        GenerateFunctionMembers();
        GenerateFunctions();
    }

    private void GenerateUtil()
    {
        var output = $"{Options.OutputPath}/{Options.ClassName}.Util.cs";

        var dirName = Path.GetDirectoryName(output);

        if (!string.IsNullOrEmpty(dirName))
            _ = Directory.CreateDirectory(dirName);

        using FileStream utilFile = File.Create(output);
        using StreamWriter utilWriter = new(utilFile);
        using IndentedTextWriter writer = new(utilWriter);

        writer.WriteLine(@$"
using System.Buffers.Text;

namespace {Options.Namespace};

public unsafe partial class {Options.ClassName}
{{
    public delegate void* {LoadFunctionName}(byte* name);

    const byte DotAscii = (byte)'.';
    const byte SpaceAscii = (byte)' ';
    
    internal static ReadOnlySpan<byte> OpenGlEsCmPrefix => ""OpenGL ES-CM""u8;
    internal static ReadOnlySpan<byte> OpenGlEsCxPrefix => ""OpenGL ES-CX""u8;
    internal static ReadOnlySpan<byte> OpenGlScPrefix => ""OpenGL SC""u8;
    internal static ReadOnlySpan<byte> OpenGlEsPrefix => ""OpenGL ES""u8;

    internal static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor, out bool isEmbedded)
    {{
        if (value.StartsWith(OpenGlEsCmPrefix))
        {{
            value = value[(OpenGlEsCmPrefix.Length + 1)..];
            isEmbedded = true;
        }}
        else if (value.StartsWith(OpenGlEsCxPrefix))
        {{
            value = value[(OpenGlEsCxPrefix.Length + 1)..];
            isEmbedded = true;
        }}
        else if (value.StartsWith(OpenGlEsPrefix))
        {{
            value = value[(OpenGlEsPrefix.Length + 1)..];
            isEmbedded = true;
        }}
        else if (value.StartsWith(OpenGlScPrefix))
        {{
            value = value[(OpenGlScPrefix.Length + 1)..];
            isEmbedded = true;
        }}
        else
        {{
            isEmbedded = false;
        }}   

        return TryParseVersion(value, out major, out minor);
    }}

    internal static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor)
    {{
        var dotIndex = value.IndexOf(DotAscii);
        var spaceIndex = value.IndexOf(SpaceAscii);

        if (dotIndex == -1)
        {{
            (major, minor) = (default, default);
            return false;
        }}

        var fromFirstDot = value[(dotIndex + 1)..];
        var nextDot = fromFirstDot.IndexOf(DotAscii);
        var lastIndex = nextDot != -1 ? nextDot : (spaceIndex != -1 ? spaceIndex : fromFirstDot.Length);
        
        if (Utf8Parser.TryParse(value[..dotIndex], out major, out _)
        && Utf8Parser.TryParse(fromFirstDot[..lastIndex], out minor, out _))
            return true;

        major = minor = 0;
        return false;
    }}
}}
        ");
    }

    private void GenerateLoader()
    {
        var output = $"{Options.OutputPath}/{Options.ClassName}.Load.cs";

        var dirName = Path.GetDirectoryName(output);

        if (!string.IsNullOrEmpty(dirName))
            _ = Directory.CreateDirectory(dirName);

        using FileStream loaderFile = File.Create(output);
        using StreamWriter loaderWriter = new(loaderFile);
        using IndentedTextWriter writer = new(loaderWriter);

        writer.WriteLine("using System.Buffers;");
        writer.WriteLine("using System.Runtime.InteropServices;");
        writer.WriteLine();
        writer.WriteLine($"namespace {Options.Namespace};");
        writer.WriteLine();
        writer.WriteLine($"public unsafe partial class {Options.ClassName}");
        writer.WriteLine('{');
        writer.Indent++;

        switch (Options.Api) // Required things in each api
        {
            case Api.GL:
                {
                    if (includedCommands.Find(c => c.Proto.Name is "glGetString") is null)
                        writer.WriteLine($"internal static ReadOnlySpan<byte> {GetUtf8StringFieldName("glGetString")} => \"glGetString\"u8;");

                    if (includedCommands.Find(c => c.Proto.Name is "glGetStringi") is null)
                        writer.WriteLine($"internal static ReadOnlySpan<byte> {GetUtf8StringFieldName("glGetStringi")} => \"glGetStringi\"u8;");

                    if (includedEnums.Find(e => e.Name is "GL_EXTENSIONS") is null)
                        writer.WriteLine("internal const int GL_EXTENSIONS = 0x1F03;");

                    if (includedEnums.Find(e => e.Name is "GL_NUM_EXTENSIONS") is null)
                        writer.WriteLine("internal const int GL_NUM_EXTENSIONS = 0x821D;");
                    break;
                }
        }

        if (!apis.IsDefaultOrEmpty) // To support only generating extensions
        {
            writer.WriteLine("public readonly ushort Major;");
            writer.WriteLine("public readonly ushort Minor;");

            if (Options.Api is Api.GL)
                writer.WriteLine("public readonly bool IsEmbedded;");

            writer.WriteLine();

            foreach (var version in versions)
                writer.WriteLine($"public readonly bool Version{version.Major}{version.Minor};");

            writer.WriteLine();
        }

        if (!extensions.IsDefaultOrEmpty)
        {
            writer.WriteLine("// Extensions");

            foreach (var extension in extensions)
            {
                writer.WriteLine($"internal static ReadOnlySpan<byte> {GetUtf8StringExtensionName(extension.Name)} => \"{extension.Name}\"u8;");
                writer.WriteLine($"public readonly bool {extension.Name};");
            }

            writer.WriteLine();
        }

        writer.WriteLine($"public {Options.ClassName}({LoadFunctionName} loadFunc)");
        writer.WriteLine('{');
        writer.Indent++;
        WriteApiSpecificLoading(writer);
        writer.WriteLine();

        foreach (var version in versions)
            writer.WriteLine($"Version{version.Major}{version.Minor} = Major > {version.Major} || (Major == {version.Major} && Minor >= {version.Minor});");

        foreach (var api in apis)
        {
            writer.WriteLine();
            if (Options.Api is Api.GL)
                writer.WriteLine($"if({(api.GLApi.IsEmbedded() ? string.Empty : "!")}IsEmbedded & Version{api.Number.Major}{api.Number.Minor})");
            else
                writer.WriteLine($"if(Version{api.Number.Major}{api.Number.Minor})");
            writer.WriteLine('{');
            writer.Indent++;

            foreach (var c in api.Requires.SelectMany(a => a.Commands))
            {
                var command = includedCommands.Find(com => com.Proto.Name == c.Name);

                if (command is null)
                    continue;

                GenerateFixedLoadStatement(writer, GenerateFunctionPointerType(command), GetUtf8StringFieldName(command.Proto.Name), $"this.{command.Proto.Name}");
            }

            writer.Indent--;
            writer.WriteLine('}');
        }

        foreach (var extension in extensions)
        {
            writer.WriteLine();

            writer.WriteLine($"if({extension.Name})");
            writer.WriteLine('{');
            writer.Indent++;

            foreach (var c in extension.Requires.SelectMany(e => e.Commands))
            {
                var command = includedCommands.Find(com => com.Proto.Name == c.Name);

                if (command is null)
                    continue;

                GenerateFixedLoadStatement(writer, GenerateFunctionPointerType(command), GetUtf8StringFieldName(command.Proto.Name), $"this.{command.Proto.Name}");
            }

            writer.Indent--;
            writer.WriteLine('}');
        }

        writer.Indent--;
        writer.WriteLine('}');
        writer.Indent--;
        writer.WriteLine('}');
    }

    private void GenerateEnums()
    {
        var output = $"{Options.OutputPath}/{Options.ClassName}.Constants.cs";

        var dirName = Path.GetDirectoryName(output);

        if (!string.IsNullOrEmpty(dirName))
            _ = Directory.CreateDirectory(dirName);

        using FileStream enumFile = File.Create(output);
        using StreamWriter enumWriter = new(enumFile);
        using IndentedTextWriter writer = new(enumWriter);

        writer.WriteLine($"namespace {Options.Namespace};");
        writer.WriteLine();
        writer.WriteLine($"public partial class {Options.ClassName}");
        writer.WriteLine('{');
        writer.Indent++;
        foreach (var @enum in includedEnums)
            GenerateConstant(writer, @enum);
        writer.Indent--;
        writer.WriteLine('}');
    }

    private void GenerateConstant(IndentedTextWriter writer, SpecEnum constant)
    {
        string value = ProcessConstantValue(constant.Value);
        string type = ProcessConstantValueType(value);
        writer.WriteLine($"public const {type} {constant.Name} = unchecked(({type}){value});");
    }

    private void GenerateFunctionMembers()
    {
        var output = $"{Options.OutputPath}/{Options.ClassName}.FunctionMembers.cs";

        var dirName = Path.GetDirectoryName(output);

        if (!string.IsNullOrEmpty(dirName))
            _ = Directory.CreateDirectory(dirName);

        using FileStream functionsFile = File.Create(output);
        using StreamWriter functionsWriter = new(functionsFile);
        using IndentedTextWriter writer = new(functionsWriter);

        writer.WriteLine($"namespace {Options.Namespace};");
        writer.WriteLine();
        writer.WriteLine($"public unsafe partial class {Options.ClassName}");
        writer.WriteLine('{');
        writer.Indent++;
        foreach (var command in includedCommands)
            GenerateMemberName(writer, command);
        writer.WriteLine();
        foreach (var command in includedCommands)
            GenerateMembers(writer, command);
        writer.Indent--;
        writer.WriteLine('}');
    }

    private void GenerateMemberName(IndentedTextWriter writer, Command command)
        => writer.WriteLine($"internal static ReadOnlySpan<byte> {GetUtf8StringFieldName(command.Proto.Name)} => \"{command.Proto.Name}\"u8;");

    private void GenerateMembers(IndentedTextWriter writer, Command command)
        => writer.WriteLine($"private readonly {GenerateFunctionPointerType(command)} {command.Proto.Name};");

    private void GenerateFunctions()
    {
        var output = $"{Options.OutputPath}/{Options.ClassName}.Functions.cs";

        var dirName = Path.GetDirectoryName(output);

        if (!string.IsNullOrEmpty(dirName))
            _ = Directory.CreateDirectory(dirName);

        using FileStream functionsFile = File.Create(output);
        using StreamWriter functionsWriter = new(functionsFile);
        using IndentedTextWriter writer = new(functionsWriter);

        writer.WriteLine($"namespace {Options.Namespace};");
        writer.WriteLine();
        writer.WriteLine($"public unsafe partial class {Options.ClassName}");
        writer.WriteLine('{');
        writer.Indent++;
        foreach (var command in includedCommands)
            GenerateFunction(writer, command);
        writer.Indent--;
        writer.WriteLine('}');
    }

    private void GenerateFunction(IndentedTextWriter writer, Command command)
    {
        var realName = command.Proto.Name;
        var name = realName;

        if (name.StartsWith(apiPrefix))
            name = name[apiPrefix.Length..];

        writer.Write($"public {command.Proto.Type} {name}(");

        var paramCount = command.Parameters.Count;
        var i = 1;
        foreach (var param in command.Parameters)
        {
            writer.Write($"{param.Type} @{param.Name}");

            if (i++ < paramCount)
                writer.Write(", ");
        }

        writer.WriteLine(')');
        writer.Indent++;
        writer.Write($"=> {realName}(");

        i = 1;
        foreach (var param in command.Parameters)
        {
            writer.Write($"@{param.Name}");

            if (i++ < paramCount)
                writer.Write(", ");
        }

        writer.WriteLine(");");
        writer.Indent--;
    }

    private void WriteApiSpecificLoading(IndentedTextWriter writer)
    {
        switch (Options.Api)
        {
            case Api.GL:
                {
                    WriteGLLoading(writer);
                    break;
                }
            case Api.EGL:
                {
                    WriteEGLLoading(writer);
                    break;
                }
        }
    }

    private void WriteGLLoading(IndentedTextWriter writer)
    {
        writer.WriteLine("delegate* unmanaged<int, byte*> glGetString;");
        GenerateFixedLoadStatement(writer, "delegate* unmanaged<int, byte*>", GetUtf8StringFieldName("glGetString"), "glGetString");
        writer.WriteLine("if(glGetString == null) return;");

        if (!apis.IsDefaultOrEmpty)
        {
            writer.WriteLine(@"
        var version = glGetString(GL_VERSION);
        if(version is null) return;
        if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor, out IsEmbedded)) return;");
        }

        if (!extensions.IsDefaultOrEmpty)
        {
            writer.WriteLine(@"
        static bool IsExtensionSupported(ReadOnlySpan<nint> extensions, ReadOnlySpan<byte> extension)
        {
            foreach(var e in extensions)
            {
                if(extension.SequenceEqual(MemoryMarshal.CreateReadOnlySpanFromNullTerminated((byte*)e)))
                    return true;
            }

            return false;
        }");

            writer.WriteLine("delegate* unmanaged<int, uint, byte*> glGetStringi;");
            GenerateFixedLoadStatement(writer, "delegate* unmanaged<int, uint, byte*>", GetUtf8StringFieldName("glGetStringi"), "glGetStringi");

            writer.WriteLine("delegate* unmanaged<int, int*, void> glGetIntegerv;");
            GenerateFixedLoadStatement(writer, "delegate* unmanaged<int, int*, void>", GetUtf8StringFieldName("glGetIntegerv"), "glGetIntegerv");

            writer.WriteLine(@"
        if(glGetStringi is not null && glGetIntegerv is not null) // Fast path (OpenGL 3+)
        {
            int extensionsLength;
            glGetIntegerv(""GL_NUM_EXTENSIONS"", &extensionsLength);
            byte[] pointerData = ArrayPool<byte>.Shared.Rent(extensionsLength * sizeof(nint));
            Span<nint> extensions = MemoryMarshal.Cast<byte, nint>(pointerData.AsSpan()[..(extensionsLength * sizeof(nint))]);

            for(int e = 0; e < extensionsLength; ++e)
                extensions[e] = (nint)glGetStringi(GL_EXTENSIONS, i);
            
            ");
            writer.Indent++;
            foreach (var extension in extensions)
                writer.WriteLine($"{extension.Name} = IsExtensionSupported(extensions, {GetUtf8StringExtensionName(extension.Name)});");

            writer.WriteLine();
            writer.WriteLine("ArrayPool<byte>.Shared.Return(pointerData);");
            writer.Indent--;
            writer.WriteLine('}');
        }
    }

    private void WriteEGLLoading(IndentedTextWriter writer)
    {
        writer.WriteLine("delegate* unmanaged<void*, int, byte*> eglQueryString;");
        GenerateFixedLoadStatement(writer, "delegate* unmanaged<void*, int, byte*>", GetUtf8StringFieldName("eglQueryString"), "eglQueryString");

        writer.WriteLine("delegate* unmanaged<int> eglGetError;");
        GenerateFixedLoadStatement(writer, "delegate* unmanaged<int>", GetUtf8StringFieldName("eglGetError"), "eglGetError");

        writer.WriteLine("if(eglQueryString is null || eglGetError is null) return;");

        if (apis.IsDefaultOrEmpty)
        {
            writer.WriteLine(@"
            var version = eglQueryString((void*)EGL_NO_DISPLAY, EGL_VERSION);
            _ = eglGetError();
            if(version == null) (Major, Minor) = (1, 0);
            else if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor)) return;");
        }
    }

    private void LoadIncludedApis()
    {
        foreach (var api in apis)
        {
            foreach (var requires in api.Requires)
                LoadRequires(requires);

            foreach (var removes in api.Removes)
                LoadRemoves(removes);
        }
    }

    private void LoadIncludedExtensions()
    {
        foreach (var extension in extensions)
        {
            if (extension.Supported != Options.Api
            || (extension.SupportedProfile is not GLProfile.None && extension.SupportedProfile != Options.Profile)
            || !extension.GLSupported.Where(gl => Options.GLApis.Select(g => g.Api).Contains(gl)).Any())
                continue;

            foreach (var requires in extension.Requires)
                LoadRequires(requires);

            foreach (var removes in extension.Removes)
                LoadRemoves(removes);
        }
    }

    private void LoadRequires(RequireRemove requires)
    {
        if (requires.Profile is not GLProfile.None & (requires.GLApi is GLApi.GL & requires.Profile != Options.Profile))
            return;

        foreach (var command in requires.Commands)
        {
            if (includedCommands.Find(c => c.Proto.Name == command.Name) is not null)
                continue;

            var c = Registry.CommandsList.SelectMany(c => c.CommandList).First(com => com.Proto.Name == command.Name);
            includedCommands.Add(c);
        }

        foreach (var specEnum in requires.Enums)
        {
            if (includedEnums.Find(e => e.Name == specEnum.Name) is not null)
                continue;

            var e = Registry.EnumsList.SelectMany(e => e.Enums).First(@enum => @enum.Name == specEnum.Name);
            includedEnums.Add(e);
        }
    }

    private void LoadRemoves(RequireRemove removes)
    {
        if (removes.Profile is not GLProfile.None & (removes.GLApi is GLApi.GL & removes.Profile != Options.Profile))
            return;

        foreach (var command in removes.Commands)
            includedCommands.RemoveAll(c => c.Proto.Name == command.Name);

        foreach (var specEnum in removes.Enums)
            includedEnums.RemoveAll(e => e.Name == specEnum.Name);
    }

    private string GenerateFunctionPointerType(Command command)
    {
        if (functionTypeMap.TryGetValue(command, out var type))
            return type;

        StringBuilder builder = new();
        builder.Append("delegate* unmanaged<");

        foreach (var param in command.Parameters)
            builder.Append($"{param.Type}, ");

        builder.Append($"{command.Proto.Type}>");

        var processedType = builder.ToString();
        _ = functionTypeMap.TryAdd(command, processedType);
        return processedType;
    }

    private static string ProcessConstantValue(string value)
    {
        const string EglCast = "EGL_CAST(";

        if (value.StartsWith(EglCast))
            return value[(value.IndexOf(',') + 1)..value.IndexOf(')')];

        return value;
    }

    private static string ProcessConstantValueType(string value)
    {
        const string Prefix = "0x";

        var numberStyle = NumberStyles.Integer;
        var number = value.AsSpan();

        if (number.StartsWith(Prefix))
        {
            number = number[Prefix.Length..];
            numberStyle = NumberStyles.HexNumber;
        }

        if (int.TryParse(number, numberStyle, CultureInfo.InvariantCulture, out _))
            return "int";
        if (uint.TryParse(number, numberStyle, CultureInfo.InvariantCulture, out _))
            return "uint";
        if (long.TryParse(number, numberStyle, CultureInfo.InvariantCulture, out _))
            return "long";
        return "ulong";
    }

    private static void GenerateFixedLoadStatement(IndentedTextWriter writer, string functionType, string fixedString, string functionName)
    {
        writer.WriteLine($"fixed(byte* name = {fixedString})");
        writer.Indent++;
        writer.WriteLine($"{functionName} = ({functionType})loadFunc(name);");
        writer.Indent--;
    }

    private static string GetUtf8StringFieldName(string functionName)
        => $"{functionName}FunctionName";

    private static string GetUtf8StringExtensionName(string extensionName)
        => $"{extensionName}ExtensionName";
}