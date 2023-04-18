using System.Xml;

namespace Rena.Interop.OpenGL.Generator;

public class SpecEnum
{
    public const string XmlElementName = "enum";
    const string XmlValue = "value";
    const string XmlName = "name";
    const string XmlApi = "api";
    const string XmlType = "type";
    const string XmlGroup = "group";
    const string XmlAlias = "alias";

    public string Value { get; init; }
    public string Name { get; init; }
    public string Api { get; init; }
    public string Type { get; init; }
    public string Group { get; init; }
    public string Alias { get; init; }

    public SpecEnum(XmlElement element)
    {
        Value = element.GetAttribute(XmlValue);
        Name = element.GetAttribute(XmlName);
        Api = element.GetAttribute(XmlApi);
        Type = element.GetAttribute(XmlType);
        Group = element.GetAttribute(XmlGroup);
        Alias = element.GetAttribute(XmlAlias);
    }
}