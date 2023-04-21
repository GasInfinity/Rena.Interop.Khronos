using System.CodeDom.Compiler;
using System.Globalization;

namespace Rena.Interop.OpenGL.Generator;

public static class Generation
{
    public const string LoadFunctionTypeName = "LoadFunction";
    public const string LoadFunctionParameterName = "loadFunc";

    public static IndentedTextWriter AddIndentation(this IndentedTextWriter writer)
    {
        writer.Indent++;
        return writer;
    }

    public static IndentedTextWriter RemoveIndentation(this IndentedTextWriter writer)
    {
        writer.Indent--;
        return writer;
    }

    public static IndentedTextWriter Wrt(this IndentedTextWriter writer, string? value)
    {
        writer.Write(value);
        return writer;
    }

    public static IndentedTextWriter WrtLine(this IndentedTextWriter writer, string? value)
    {
        writer.WriteLine(value);
        return writer;
    }

    public static IndentedTextWriter WrtLine(this IndentedTextWriter writer, char value)
    {
        writer.WriteLine(value);
        return writer;
    }

    public static IndentedTextWriter WrtLine(this IndentedTextWriter writer)
    {
        writer.WriteLine();
        return writer;
    }

    public static void GenerateFixedLoadStatement(IndentedTextWriter writer, ReadOnlySpan<char> fixedValue, ReadOnlySpan<char> fieldName, ReadOnlySpan<char> castedType)
    {
        const string FixedVariableName = "name";

        writer.WrtLine($"fixed(byte* {FixedVariableName} = {fixedValue})")
              .AddIndentation()
                .WrtLine($"{fieldName} = ({castedType}){LoadFunctionParameterName}({FixedVariableName});")
              .RemoveIndentation();
    }

    public static void GenerateSharpFunction(IndentedTextWriter writer, ReadOnlySpan<char> apiPrefix, Command command)
    {
        var name = command.Name.AsSpan();

        if (name.StartsWith(apiPrefix))
            name = name[apiPrefix.Length..];

        writer.Write($"public {command.Proto.Type} {name}(");

        var paramCount = command.Parameters.Count;
        var i = 0;
        foreach (var param in command.Parameters)
        {
            writer.Write($"{param.Type} @{param.Name}");

            if (++i < paramCount)
                writer.Write(", ");
        }

        writer.WriteLine(')');
        writer.AddIndentation();
        writer.Write($"=> {command.Name}(");

        i = 1;
        foreach (var param in command.Parameters)
        {
            writer.Write($"@{param.Name}");

            if (i++ < paramCount)
                writer.Write(", ");
        }

        writer.WriteLine(");");
        writer.RemoveIndentation();
    }

    public static void GenerateSharpConstant(IndentedTextWriter writer, SpecEnum constant)
    {
        string value = SharpConstantValueFromRaw(constant.Value);
        string type = ConstantTypeFromValue(value);
        writer.WriteLine($"public const {type} {constant.Name} = unchecked(({type}){value});");
    }

    public static void GenerateSharpUtf8FunctionName(IndentedTextWriter writer, Command command)
        => writer.WriteLine($"internal static ReadOnlySpan<byte> {FunctionToUtf8FunctionName(command.Name)} => \"{command.Name}\"u8;");

    public static void GenerateSharpFunctionMember(IndentedTextWriter writer, Command command)
        => writer.WriteLine($"private readonly {command.SharpPointerType} {command.Name};");

    public static string FunctionToUtf8FunctionName(ReadOnlySpan<char> functionName)
        => $"{functionName}FunctionName";

    public static string ExtensionToUtf8ExtensionName(ReadOnlySpan<char> extensionName)
        => $"{extensionName}ExtensionName";

    public static string SharpConstantValueFromRaw(string value)
    {
        const string EglCast = "EGL_CAST(";

        if (value.StartsWith(EglCast))
            return value[(value.IndexOf(',') + 1)..value.IndexOf(')')];

        return value;
    }

    public static string ConstantTypeFromValue(string value)
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
}