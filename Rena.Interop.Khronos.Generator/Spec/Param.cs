using System.Xml;

namespace Rena.Interop.Khronos.Generator;

public class Param
{
    public readonly IType Type;
    public readonly string Name;

    public Param(XmlElement element)
    {
        Name = element["name"]?.InnerText ?? string.Empty;

        var possibleArrayStart = element.InnerText.LastIndexOf('[');
        bool isArray = possibleArrayStart != -1;
        ReadOnlySpan<char> typeName = isArray ? element.InnerText.AsSpan()[..(possibleArrayStart - Name.Length)].Trim() : element.InnerText.AsSpan()[..^Name.Length].Trim();
        
        IType parsedType = IType.ParseFrom(typeName);
        string group = element.GetAttribute("group");
        Type = !string.IsNullOrEmpty(group) ? IType.ParseFrom($"{group}{new string('*', parsedType.PointerDepth)}") : (isArray ? new PointerType() { InnerType = parsedType } : parsedType);
    }
}
