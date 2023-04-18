using System.Xml;

namespace Rena.Interop.OpenGL.Generator;

public class RequireRemove
{
    public const string XmlRequireElementName = "require";
    public const string XmlRemoveElementName = "remove";
    const string XmlProfile = "profile";
    const string XmlApi = "api";

    private readonly List<Command> commands = new();
    private readonly List<SpecEnum> enums = new();

    public Api Api { get; init; }
    public GLApi GLApi { get; init; }
    public GLProfile Profile { get; init; }

    public IReadOnlyList<Command> Commands
        => commands;

    public IReadOnlyList<SpecEnum> Enums
        => enums;

    public RequireRemove(XmlElement element)
    {
        Api = ApiExtensions.FromFeatureString(element.GetAttribute(XmlApi), out var glApi);
        GLApi = glApi;

        Profile = GLProfileExtensions.FromXmlString(element.GetAttribute(XmlProfile));

        foreach (XmlNode child in element)
        {
            switch (child.Name)
            {
                case Command.XmlElementName:
                    {
                        commands.Add(new((child as XmlElement)!));
                        break;
                    }
                case SpecEnum.XmlElementName:
                    {
                        enums.Add(new((child as XmlElement)!));
                        break;
                    }
            }
        }
    }

    public readonly struct Command
    {
        public const string XmlElementName = "command";
        const string XmlName = "name";

        public string Name { get; init; }

        public Command(XmlElement element)
            => Name = element.GetAttribute(XmlName);
    }

    public readonly struct SpecEnum
    {
        public const string XmlElementName = "enum";
        const string XmlName = "name";

        public string Name { get; init; }

        public SpecEnum(XmlElement element)
            => Name = element.GetAttribute(XmlName);
    }
}