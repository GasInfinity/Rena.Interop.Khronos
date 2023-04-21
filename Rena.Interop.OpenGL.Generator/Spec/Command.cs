using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;
using Microsoft.Extensions.ObjectPool;

namespace Rena.Interop.OpenGL.Generator;

public class Command
{
    public const string XmlElementName = "command";

    private readonly List<Param> parameters = new();
    public Proto Proto { get; init; }
    public string SharpPointerType { get; init; }
    public string Name
        => Proto.Name;

    public IReadOnlyList<Param> Parameters
        => parameters;

    public Command(XmlElement element)
    {
        Proto = new(element[Proto.XmlElementName]!);

        foreach (XmlNode child in element)
        {
            if (child.Name == Param.XmlElementName)
                parameters.Add(new((child as XmlElement)!));
        }

        SharpPointerType = SharpPointerTypeFromCommand(this);
    }

    private static readonly DefaultObjectPool<StringBuilder> BuilderPool = new(new DefaultPooledObjectPolicy<StringBuilder>());
    private static string SharpPointerTypeFromCommand(Command command)
    {
        StringBuilder builder = BuilderPool.Get();
        builder.Append("delegate* unmanaged<");

        foreach (var param in command.Parameters)
            builder.Append($"{param.Type}, ");

        builder.Append($"{command.Proto.Type}>");

        var functionType = builder.ToString();
        builder.Clear();
        BuilderPool.Return(builder);
        return functionType;
    }
}