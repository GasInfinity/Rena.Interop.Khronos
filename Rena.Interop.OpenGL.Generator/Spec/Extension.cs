using System.Xml;

namespace Rena.Interop.OpenGL.Generator;

public class Extension
{
    public const string XmlElementName = "extension";
    const string XmlName = "name";
    const string XmlSupported = "supported";
    const string XmlProtect = "protect";

    private readonly List<RequireRemove> requires = new();
    private readonly List<RequireRemove> removes = new();

    public string Name { get; init; }
    public string[] Supported { get; init; }
    public string Protect { get; init; }

    public IReadOnlyList<RequireRemove> Requires
        => requires;

    public IReadOnlyList<RequireRemove> Removes
        => removes;

    public Extension(XmlElement element)
    {
        Name = element.GetAttribute(XmlName);
        Supported = element.GetAttribute(XmlSupported).Split('|');
        Protect = element.GetAttribute(XmlProtect);

        foreach (XmlNode child in element)
        {
            switch (child.Name)
            {
                case RequireRemove.XmlRequireElementName:
                    {
                        requires.Add(new((child as XmlElement)!));
                        break;
                    }
                case RequireRemove.XmlRemoveElementName:
                    {
                        removes.Add(new((child as XmlElement)!));
                        break;
                    }
            }
        }
    }
}