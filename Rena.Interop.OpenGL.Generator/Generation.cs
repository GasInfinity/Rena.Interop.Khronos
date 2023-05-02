using System.CodeDom.Compiler;
using System.CommandLine;
using System.Globalization;

namespace Rena.Interop.OpenGL.Generator;

public static class Generation
{
    public const string LoadFunctionTypeName = "LoadFunction";
    public const string LoadFunctionParameterName = "loadFunc";

    public static bool TryCreateDirectories(string filePath, IConsole console)
    {
        var directoryPath = Path.GetDirectoryName(filePath);

        if (string.IsNullOrEmpty(directoryPath))
            return true;

        try
        {
            _ = Directory.CreateDirectory(directoryPath);
            console.WriteLine($"Created directory/directories at '{directoryPath}'");
            return true;
        }
        catch (Exception exception)
        {
            console.WriteLine($"Error while creating directory/directories at '{directoryPath}'. Exception: {exception}");
            return false;
        }
    }

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

    public static void GenerateSharpConstant(IndentedTextWriter writer, SpecEnum constant)
    {
        string value = SharpConstantValueFromRaw(constant.Value);
        string type = ConstantTypeFromValue(value);
        writer.WriteLine($"public const {type} {constant.Name} = unchecked(({type}){value});");
    }

    public static void GenerateSharpUtf8FunctionName(IndentedTextWriter writer, Command command)
        => writer.WriteLine($"public static ReadOnlySpan<byte> {FunctionToUtf8FunctionName(command.Name)} => \"{command.Name}\"u8;");

    public static void GenerateSharpFunctionMember(IndentedTextWriter writer, string apiPrefix, Command command)
        => writer.WriteLine($"public readonly {command.SharpPointerType} {FunctionNameToSharpFunctionMemberName(apiPrefix, command.Name)};");

    public static string NameToSharpFileName(ReadOnlySpan<char> name)
        => $"{name}.g.cs";
    public static string FunctionNameToSharpFunctionMemberName(string apiPrefix, string functionName)
    {
        if (functionName.StartsWith(apiPrefix))
            return functionName[apiPrefix.Length..];

        return functionName;
    }

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