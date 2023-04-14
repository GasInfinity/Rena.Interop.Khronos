using System.Xml;

namespace Rena.Interop.OpenGL.Generator;

public class Feature
{
    public const string XmlElementName = "feature";

    const string XmlApi = "api";
    const string XmlName = "name";
    const string XmlProtect = "protect";
    const string XmlNumber = "number";

    private readonly List<RequireRemove> requires = new();
    private readonly List<RequireRemove> removes = new();

    public Api Api { get; init; }
    public string Name { get; init; }
    public string Protect { get; init; }
    public Version Number { get; init; }

    public IReadOnlyList<RequireRemove> Requires
        => requires;

    public IReadOnlyList<RequireRemove> Removes
        => removes;

    public Feature(XmlElement element)
    {
        Api = ApiExtensions.FromXmlString(element.GetAttribute(XmlApi));
        Name = element.GetAttribute(XmlName);
        Protect = element.GetAttribute(XmlProtect);

        if(Version.TryParse(element.GetAttribute(XmlNumber), out Version version))
            Number = version;

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