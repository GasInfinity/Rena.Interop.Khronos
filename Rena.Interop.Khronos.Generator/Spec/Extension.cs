using System.Collections.Immutable;
using System.Xml;

namespace Rena.Interop.Khronos.Generator;

public class Extension(ImmutableArray<KhronosApi> Supported, int Number, string Type, ImmutableArray<RequireRemove> Requires, ImmutableArray<RequireRemove> Removes)
{
    public readonly ImmutableArray<KhronosApi> Supported = Supported;
    public readonly string Type = Type;
    public readonly int Number = Number;
    
    public readonly ImmutableArray<RequireRemove> Requires = Requires;
    public readonly ImmutableArray<RequireRemove> Removes = Removes;
    
    public static bool TryDeserializeTo(XmlNode n, Dictionary<string, Extension> extensions)
    {
        if(n is not XmlElement element || n.Name != "extensions")
            return false;

        foreach(XmlNode child in element)
        {
            if(child is not XmlElement c || c.Name != "extension")
                continue;

            string type = c.GetAttribute("type");
            string possibleNumber = c.GetAttribute("number");
            int number = string.IsNullOrEmpty(possibleNumber) ? 0 : int.Parse(possibleNumber);
            var requires = ImmutableArray.CreateBuilder<RequireRemove>();
            var removes = ImmutableArray.CreateBuilder<RequireRemove>();
            foreach (XmlNode ch in c)
            {
                (bool success, bool isRemove) = RequireRemove.TryDeserialize(ch, null, out RequireRemove rr);

                if(!success)
                    continue;

                if(isRemove)
                {
                    removes.Add(rr);
                    continue;
                }

                requires.Add(rr);
            }

            string name = c.GetAttribute("name");

            extensions.Add(name, new(c.GetAttribute("supported").Split(',').SelectMany(s => s.Split('|')).Select(s => KhronosApiExtensions.Parse(s)).ToImmutableArray(), number, type, requires.DrainToImmutable(), removes.DrainToImmutable()));
        }

        return true;
    }
}
