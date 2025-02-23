using System.Xml;

namespace Rena.Interop.Khronos.Generator;

public readonly record struct Constant(IType Type, string Value)
{
    public readonly IType Type = Type;
    public readonly string Value = Value;

    public static bool TryDeserializeRangeTo(XmlNode n, Dictionary<string, Constant> definedConstants)
    {
        if(n.Name != "enums" || n is not XmlElement element)
            return false;

        foreach(XmlNode c in element)
        {
            if(c.Name != "enum" || c is not XmlElement constant)
                continue;

            string name = constant.GetAttribute("name");
            string type = constant.GetAttribute("type");
            string value = constant.GetAttribute("value");

            
            definedConstants.Add(name, new(IType.ParseFrom(type), value));
        }

        return true;
    }
}
