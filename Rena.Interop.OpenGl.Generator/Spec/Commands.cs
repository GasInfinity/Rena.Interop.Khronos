using System.Xml;

namespace Rena.Interop.OpenGl.Generator;

public class Commands
{
    public const string XmlElementName = "commands";
    private readonly List<Command> commands = new();

    public IReadOnlyList<Command> CommandList
        => commands;

    public Commands(XmlElement element)
    {
        foreach (XmlNode child in element)
        {
            if (child.Name is Command.XmlElementName)
                commands.Add(new((child as XmlElement)!));
        }
    }
}