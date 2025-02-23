using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace Rena.Interop.Khronos.Generator;

public class Feature(string Name, ImmutableArray<KhronosApi> Apis, string Protect, ApiVersion Number, ImmutableArray<RequireRemove> Requires, ImmutableArray<RequireRemove> Removes)
{
    public readonly string Name = Name;
    public readonly ImmutableArray<KhronosApi> Apis = Apis;
    public readonly string Protect = Protect;
    public readonly ApiVersion Number = Number;

    public readonly ImmutableArray<RequireRemove> Requires = Requires;
    public readonly ImmutableArray<RequireRemove> Removes = Removes;

    public static bool TryDeserialize(XmlNode n, [NotNullWhen(true)] out Feature? feature)
    {
        if(n is not XmlElement element || n.Name != "feature")
        {
            feature = default;
            return false;
        }

        ApiVersion number = default;
        if (ApiVersion.TryParse(element.GetAttribute("number"), out ApiVersion version))
            number = version;

        var requires = ImmutableArray.CreateBuilder<RequireRemove>();
        var removes = ImmutableArray.CreateBuilder<RequireRemove>();
        foreach (XmlNode child in element)
        {
            (bool success, bool isRemove) = RequireRemove.TryDeserialize(child, null, out RequireRemove rr);

            if(!success)
                continue;

            if(isRemove)
            {
                removes.Add(rr);
                continue;
            }

            requires.Add(rr);
        }

        feature = new(element.GetAttribute("name"), element.GetAttribute("api").Split(',').Select(s => KhronosApiExtensions.Parse(s)).ToImmutableArray(), element.GetAttribute("protect"), number, requires.DrainToImmutable(), removes.DrainToImmutable());
        return true;
    }
}
