using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;

namespace Rena.Interop.OpenGl.Generator;

// TODO: Refactor this one day, it's only a MVP
public class Generator
{
    const string LoadProcType = "delegate* <byte*, void*>";

    private readonly string apiString;
    private readonly string functionPrefix;
    private readonly Dictionary<Command, string> functionTypeMap = new();
    private readonly Dictionary<Command, bool> includedFunctionMap = new();
    private readonly Dictionary<SpecEnum, bool> includedEnumMap = new();

    private readonly IEnumerable<Feature> apis;
    private readonly IEnumerable<Extension> extensions;
    public GeneratorOptions Options { get; }
    public Registry Registry { get; }


    public Generator(Registry registry, GeneratorOptions options)
    {
        Registry = registry;
        Options = options;

        apis = registry.FeatureList.Where(a => a.Api == Options.Api && Options.Version.IsIncluded(a.Number));
        if (options.IncludedExtensions is ["*"])
            extensions = registry.ExtensionsList.SelectMany(e => e.ExtensionList);
        else
            extensions = registry.ExtensionsList.SelectMany(e => e.ExtensionList.Where(e => IsExtensionSupported(e) && (options.IncludedExtensions?.Contains(e.Name) ?? false)));

        apiString = Options.Api.ToXmlString();
        functionPrefix = Options.Api switch
        {
            Api.Gl or Api.Gles1 or Api.Gles2 => "gl",
            Api.Egl => "egl",
            _ => string.Empty
        };
    }

    public void Generate()
    {
        GenerateUtil();
        GenerateLoader();
        GenerateEnums(Registry.EnumsList);
        GenerateFunctionMembers(Registry.CommandsList);
        GenerateFunctions(Registry.CommandsList);
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

public partial class {Options.ClassName}
{{
    internal static ReadOnlySpan<byte> OpenGlEsCmPrefix => ""OpenGL ES-CM""u8;
    internal static ReadOnlySpan<byte> OpenGlEsCxPrefix => ""OpenGL ES-CX""u8;
    internal static ReadOnlySpan<byte> OpenGlScPrefix => ""OpenGL SC""u8;
    internal static ReadOnlySpan<byte> OpenGlEsPrefix => ""OpenGL ES""u8;

    internal static bool TryParseVersion(ReadOnlySpan<byte> value, out ushort major, out ushort minor)
    {{
        const byte DotAscii = (byte)'.';
        const byte SpaceAscii = (byte)' ';
        
        if (value.StartsWith(OpenGlEsCmPrefix))
            value = value[(OpenGlEsCmPrefix.Length + 1)..];
        else if (value.StartsWith(OpenGlEsCxPrefix))
            value = value[(OpenGlEsCxPrefix.Length + 1)..];
        else if (value.StartsWith(OpenGlScPrefix))
            value = value[(OpenGlScPrefix.Length + 1)..];
        else if (value.StartsWith(OpenGlEsPrefix))
            value = value[(OpenGlEsPrefix.Length + 1)..];

        var dotIndex = value.IndexOf(DotAscii);
        var spaceIndex = value.IndexOf(SpaceAscii);
        
        if(dotIndex == -1)
        {{
            (major, minor) = (default, default);
            return false;
        }}
        
        var lastIndex = spaceIndex != -1 ? spaceIndex : value.Length;
        
        if (Utf8Parser.TryParse(value[..dotIndex], out major, out _)
        && Utf8Parser.TryParse(value[(dotIndex + 1)..lastIndex], out minor, out _))
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

        writer.WriteLine("using System.Runtime.InteropServices;");
        writer.WriteLine();
        writer.WriteLine($"namespace {Options.Namespace};");
        writer.WriteLine();
        writer.WriteLine($"public unsafe partial class {Options.ClassName}");
        writer.WriteLine('{');
        writer.Indent++;
        writer.WriteLine("public readonly ushort Major;");
        writer.WriteLine("public readonly ushort Minor;");

        foreach (var api in apis)
            writer.WriteLine($"public readonly bool Version{api.Number.Major}{api.Number.Minor};");

        writer.WriteLine();
        writer.WriteLine("// Extensions");
        foreach (var extension in extensions)
            writer.WriteLine($"public readonly bool {extension.Name[(apiString.Length + 1)..].Replace("3DFX", "ThreeDFX")};");

        writer.WriteLine();
        writer.WriteLine($"public {Options.ClassName}({LoadProcType} loadFunc)");
        writer.WriteLine('{');
        writer.Indent++;
        WriteApiSpecificLoading(writer);
        writer.WriteLine();

        foreach (var api in apis)
            writer.WriteLine($"Version{api.Number.Major}{api.Number.Minor} = Major > {api.Number.Major} || (Major == {api.Number.Major} && Minor >= {api.Number.Minor});");

        foreach (var api in apis)
        {
            writer.WriteLine();
            writer.WriteLine($"if(Version{api.Number.Major}{api.Number.Minor})");
            writer.WriteLine('{');
            writer.Indent++;

            foreach (var c in api.Requires.SelectMany(a => a.Commands))
            {
                var command = Registry.CommandsList.SelectMany(c => c.CommandList).First(com => com.Proto.Name == c.Name);

                if (!IsFunctionIncluded(command))
                    continue;

                writer.WriteLine($"fixed(byte* name = {GetUtf8StringFieldName(c.Name)})");
                writer.Indent++;
                writer.WriteLine($"{c.Name} = ({GenerateFunctionPointerType(command)})loadFunc(name);");
                writer.Indent--;
            }

            writer.Indent--;
            writer.WriteLine('}');
        }

        writer.WriteLine();
        WriteExtensionLoading(writer);
        writer.Indent--;
        writer.WriteLine('}');
        writer.Indent--;
        writer.WriteLine('}');
    }

    private void GenerateEnums(IReadOnlyList<SpecEnums> enumsList)
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
        foreach (var enums in enumsList)
            GenerateConstants(writer, enums);
        writer.Indent--;
        writer.WriteLine('}');
    }

    private void GenerateConstants(IndentedTextWriter writer, SpecEnums enums)
    {
        foreach (var constant in enums.Enums)
        {
            if (IsEnumIncluded(constant))
            {
                string value = ProcessConstantValue(constant.Value);
                string type = ProcessConstantValueType(value);
                writer.WriteLine($"public const {type} {constant.Name} = unchecked(({type}){value});");
            }
        }
    }

    private void GenerateFunctionMembers(IReadOnlyList<Commands> commandsList)
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
        foreach (var commands in commandsList)
            GenerateMemberNames(writer, commands);
        writer.WriteLine();
        foreach (var commands in commandsList)
            GenerateMembers(writer, commands);
        writer.Indent--;
        writer.WriteLine('}');
    }

    private void GenerateMemberNames(IndentedTextWriter writer, Commands commands)
    {
        foreach (var command in commands.CommandList)
        {
            if (IsFunctionIncluded(command))
                writer.WriteLine($"internal static ReadOnlySpan<byte> {GetUtf8StringFieldName(command.Proto.Name)} => \"{command.Proto.Name}\"u8;");
        }
    }

    private void GenerateMembers(IndentedTextWriter writer, Commands commands)
    {
        foreach (var command in commands.CommandList)
        {
            if (IsFunctionIncluded(command))
                writer.WriteLine($"private readonly {GenerateFunctionPointerType(command)} {command.Proto.Name};");
        }
    }

    private void GenerateFunctions(IReadOnlyList<Commands> commandsList)
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
        foreach (var commands in commandsList)
            GenerateFunction(writer, commands);
        writer.Indent--;
        writer.WriteLine('}');
    }

    private void GenerateFunction(IndentedTextWriter writer, Commands commands)
    {
        foreach (var command in commands.CommandList)
        {
            if (IsFunctionIncluded(command))
            {
                var realName = command.Proto.Name;
                var name = realName;

                if (name.StartsWith(functionPrefix))
                    name = name[functionPrefix.Length..];

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
        }
    }

    private void WriteApiSpecificLoading(IndentedTextWriter writer)
    {
        switch (Options.Api)
        {
            case Api.Gles1:
            case Api.Gles2:
            case Api.Gl:
                {
                    WriteGlLoading(writer);
                    break;
                }
            case Api.Egl:
                {
                    WriteEglLoading(writer);
                    break;
                }
        }
    }

    private static void WriteGlLoading(IndentedTextWriter writer)
    {
        writer.WriteLine($"fixed(byte* name = {GetUtf8StringFieldName("glGetString")})");
        writer.Indent++;
        writer.WriteLine($"glGetString = (delegate* unmanaged<int, byte*>)loadFunc(name);");
        writer.Indent--;
        writer.WriteLine("if(glGetString == null) return;");
        writer.WriteLine("var version = glGetString(GL_VERSION);");
        writer.WriteLine("if(version == null) return;");
        writer.WriteLine("if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor)) return;");
    }

    private void WriteEglLoading(IndentedTextWriter writer)
    {
        writer.WriteLine($"fixed(byte* name = {GetUtf8StringFieldName("eglGetDisplay")})");
        writer.Indent++;
        writer.WriteLine("eglGetDisplay = (delegate* unmanaged<void*, void*>)loadFunc(name);");
        writer.Indent--;

        writer.WriteLine($"fixed(byte* name = {GetUtf8StringFieldName("eglGetCurrentDisplay")})");
        writer.Indent++;
        writer.WriteLine("eglGetCurrentDisplay = (delegate* unmanaged<void*>)loadFunc(name);");
        writer.Indent--;

        writer.WriteLine($"fixed(byte* name = {GetUtf8StringFieldName("eglQueryString")})");
        writer.Indent++;
        writer.WriteLine("eglQueryString = (delegate* unmanaged<void*, int, byte*>)loadFunc(name);");
        writer.Indent--;

        writer.WriteLine($"fixed(byte* name = {GetUtf8StringFieldName("eglGetError")})");
        writer.Indent++;
        writer.WriteLine("eglGetError = (delegate* unmanaged<int>)loadFunc(name);");
        writer.Indent--;

        writer.WriteLine("if(eglGetDisplay == null || eglGetCurrentDisplay == null || eglQueryString == null || eglGetError == null) return;");

        writer.WriteLine("var display = eglGetCurrentDisplay();");

        if (Options.Version.IsIncluded(new() { Major = 1, Minor = 4 }))
            writer.WriteLine("if(display == (void*)EGL_NO_DISPLAY) display = eglGetDisplay((void*)EGL_DEFAULT_DISPLAY);");

        if (Options.Version.IsIncluded(new() { Major = 1, Minor = 5 }))
            writer.WriteLine("if(display == (void*)EGL_NO_DISPLAY) return;");

        writer.WriteLine("var version = eglQueryString(display, EGL_VERSION);");
        writer.WriteLine("_ = eglGetError();");

        writer.WriteLine("if(version == null) (Major, Minor) = (1, 0);");
        writer.WriteLine("else if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor)) return;");
    }

    private void WriteExtensionLoading(IndentedTextWriter writer)
    {
        // TODO: Extension Loading
    }

    private bool IsExtensionSupported(Extension extension)
        => extension.Supported.Contains(Options.Api == Api.Gl
                                     ? (Options.Profile == GlProfile.Core ? "glcore" : "gl")
                                     : Options.Api.ToXmlString());

    private bool IsFunctionIncluded(Command command)
    {
        if (includedFunctionMap.TryGetValue(command, out var included))
            return included;

        var isRemoved = apis.Any(a => a.Removes.Any(r => (r.Profile is GlProfile.None || Options.Profile is GlProfile.None || r.Profile == Options.Profile)
                      && r.Commands.Any(c => c.Name == command.Proto.Name)));

        if (isRemoved)
            return false;

        var isIncluded = apis.Any(a => a.Requires.Any(r => (r.Profile is GlProfile.None || Options.Profile is GlProfile.None || r.Profile == Options.Profile)
                      && r.Commands.Any(c => c.Name == command.Proto.Name)));

        var reallyIncluded = isIncluded || extensions.Any(e => e.Requires.Any(r => r.Commands.Any(c => c.Name == command.Proto.Name)));
        _ = includedFunctionMap.TryAdd(command, reallyIncluded);
        return reallyIncluded;
    }

    private bool IsEnumIncluded(SpecEnum @enum)
    {
        if (includedEnumMap.TryGetValue(@enum, out var included))
            return included;

        var isRemoved = apis.Any(a => a.Removes.Any(r => (r.Profile is GlProfile.None || Options.Profile is GlProfile.None || r.Profile == Options.Profile)
                      && r.Enums.Any(e => e.Name == @enum.Name)));

        if (isRemoved)
            return false;

        var isIncluded = apis.Any(a => a.Requires.Any(r => (r.Profile is GlProfile.None || Options.Profile is GlProfile.None || r.Profile == Options.Profile)
                      && r.Enums.Any(e => e.Name == @enum.Name)));

        var reallyIncluded = isIncluded || extensions.Any(e => e.Requires.Any(r => r.Enums.Any(e => e.Name == @enum.Name)));
        _ = includedEnumMap.TryAdd(@enum, reallyIncluded);
        return reallyIncluded;
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

        var number = value.AsSpan();

        if (number.StartsWith(Prefix))
            number = number[Prefix.Length..];

        if (int.TryParse(number, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _))
            return "int";
        if (uint.TryParse(number, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _))
            return "uint";
        if (long.TryParse(number, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _))
            return "long";
        return "ulong";
    }

    private static string GetUtf8StringFieldName(string functionName)
        => $"{functionName}FunctionName";
}