using System.Xml;

namespace Rena.Interop.OpenGl.Generator;

public class Proto
{
    public const string XmlElementName = "proto";

    const string XmlName = "name";
    const string XmlGroup = "group";
    
    public IType Type { get; init; }
    public string Name { get; init; }
    public string Group { get; init; }
    
    public Proto(XmlElement element)
    {
        Name = element[XmlName]?.InnerText ?? string.Empty;
        Type = IType.ParseFrom(element.InnerText.AsSpan()[..^Name.Length]);
        Group = element.GetAttribute(XmlGroup);
    }
}