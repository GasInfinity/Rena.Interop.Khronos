using System.CodeDom.Compiler;
using System.CommandLine;
using Rena.Interop.Khronos.Generator.Util;

namespace Rena.Interop.Khronos.Generator;

public static class Generation
{
    public const string LoadFunctionParameterName = "loader";

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

    public static string ToFixedLoadStatement(ReadOnlySpan<char> fixedValue, ReadOnlySpan<char> fieldName, ReadOnlySpan<char> castedType, string? parameterName = null, string? firstArgument = null)
        => $"fixed(byte* name = {fixedValue}) {fieldName} = ({castedType}){parameterName ?? LoadFunctionParameterName}({(string.IsNullOrEmpty(firstArgument) ? string.Empty : $"{firstArgument}, ")}name);";

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
}
