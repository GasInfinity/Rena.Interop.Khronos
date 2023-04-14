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

    public GLProfile Profile { get; init; }
    public Api Api { get; init; }

    public IReadOnlyList<Command> Commands
        => commands;

    public IReadOnlyList<SpecEnum> Enums
        => enums;

    public RequireRemove(XmlElement element)
    {
        Profile = GLProfileExtensions.FromXmlString(element.GetAttribute(XmlProfile));
        Api = ApiExtensions.FromXmlString(element.GetAttribute(XmlApi));

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