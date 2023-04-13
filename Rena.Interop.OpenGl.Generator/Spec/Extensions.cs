using System.Xml;

namespace Rena.Interop.OpenGl.Generator;

public class Extensions
{
    public const string XmlElementName = "extensions";

    private readonly List<Extension> extensions = new();

    public IReadOnlyList<Extension> ExtensionList
        => extensions;

    public Extensions(XmlElement element)
    {
        foreach(XmlNode child in element)
        {
            if(child.Name is Extension.XmlElementName)
                extensions.Add(new((child as XmlElement)!));
        }
    }
}