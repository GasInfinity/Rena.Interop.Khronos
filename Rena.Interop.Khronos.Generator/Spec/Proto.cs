using System.Xml;

namespace Rena.Interop.Khronos.Generator;

public class Proto
{
    public const string XmlElementName = "proto";

    public readonly IType Type;
    public readonly string Name;

    public Proto(XmlElement element)
    {
        Name = element["name"]?.InnerText ?? string.Empty;

        string group = element.GetAttribute("group");
        
        IType parsedType = IType.ParseFrom(element.InnerText.AsSpan()[..^Name.Length]);
        Type = !string.IsNullOrEmpty(group) ? IType.ParseFrom($"{group}{new string('*', parsedType.PointerDepth)}") : parsedType;
    }
}
