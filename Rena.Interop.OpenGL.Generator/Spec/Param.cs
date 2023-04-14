using System.Xml;

namespace Rena.Interop.OpenGL.Generator;

public class Param
{
    public const string XmlElementName = "param";
    const string XmlName = "name";
    const string XmlGroup = "group";

    public IType Type { get; init; }
    public string Name { get; init; }
    public string Group { get; init; }

    public Param(XmlElement element)
    {
        Name = element[XmlName]?.InnerText ?? string.Empty;
        Type = IType.ParseFrom(element.InnerText.AsSpan()[..^Name.Length]);
        Group = element.GetAttribute(XmlGroup);
    }
}