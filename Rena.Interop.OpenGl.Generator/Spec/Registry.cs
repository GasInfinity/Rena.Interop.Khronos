using System.Xml;

namespace Rena.Interop.OpenGl.Generator;

public class Registry
{
    private readonly List<SpecEnums> enums = new();
    private readonly List<Commands> commands = new();
    private readonly List<Feature> features = new();
    private readonly List<Extensions> extensions = new();

    public IReadOnlyList<SpecEnums> EnumsList
        => enums;

    public IReadOnlyList<Commands> CommandsList
        => commands;

    public IReadOnlyList<Feature> FeatureList
        => features;

    public IReadOnlyList<Extensions> ExtensionsList
        => extensions;

    public Registry(XmlElement element)
    {
        foreach (XmlNode child in element)
        {
            switch (child.Name)
            {
                case SpecEnums.XmlElementName:
                    {
                        enums.Add(new((child as XmlElement)!));
                        break;
                    }
                case Commands.XmlElementName:
                    {
                        commands.Add(new((child as XmlElement)!));
                        break;
                    }
                case Feature.XmlElementName:
                    {
                        features.Add(new((child as XmlElement)!));
                        break;
                    }
                case Extensions.XmlElementName:
                    {
                        extensions.Add(new((child as XmlElement)!));
                        break;
                    }
            }
        }
    }
}