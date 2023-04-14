using System.Xml;

namespace Rena.Interop.OpenGL.Generator;

public class SpecEnums
{
    public const string BitmaskType = "bitmask";

    public const string XmlElementName = "enums";
    const string XmlNamespace = "namespace";
    const string XmlType = "type";
    const string XmlGroup = "group";
    const string XmlStart = "start";
    const string XmlEnd = "end";
    const string XmlVendor = "vendor";
    const string XmlComment = "comment";

    private readonly List<SpecEnum> enums = new();

    public string Namespace { get; init; }
    public string Type { get; init; }
    public string Group { get; init; }
    public string Start { get; init; }
    public string End { get; init; }
    public string Vendor { get; init; }
    public string Comment { get; init; }

    public IReadOnlyList<SpecEnum> Enums
        => enums;

    public SpecEnums(XmlElement element)
    {
        Namespace = element.GetAttribute(XmlNamespace);
        Type = element.GetAttribute(XmlType);
        Group = element.GetAttribute(XmlGroup);
        Start = element.GetAttribute(XmlStart);
        End = element.GetAttribute(XmlEnd);
        Vendor = element.GetAttribute(XmlVendor);
        Comment = element.GetAttribute(XmlComment);

        foreach (XmlNode child in element)
        {
            if(child.Name is SpecEnum.XmlElementName)
                enums.Add(new((child as XmlElement)!));
        }
    }
}