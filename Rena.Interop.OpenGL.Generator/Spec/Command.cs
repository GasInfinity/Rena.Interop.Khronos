using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace Rena.Interop.OpenGL.Generator;

public class Command
{
    public const string XmlElementName = "command";

    private readonly List<Param> parameters = new();
    public Proto Proto { get; init; }

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
    }
}