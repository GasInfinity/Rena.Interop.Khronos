using System.Collections.Immutable;
using System.Xml;

namespace Rena.Interop.Khronos.Generator;

public class Registry
{
    public readonly ImmutableDictionary<KhronosApi, Dictionary<string, Type>> Types;
    public readonly ImmutableDictionary<string, Constant> Constants;
    public readonly ImmutableDictionary<KhronosApi, Dictionary<string, Enum>> Enums;
    public readonly ImmutableDictionary<KhronosApi, Dictionary<string, Command>> Commands;
    public readonly ImmutableDictionary<string, Feature> Features;
    public readonly ImmutableDictionary<string, Extension> Extensions;

    public Registry(XmlElement element)
    {
        Dictionary<KhronosApi, Dictionary<string, Type>> types = new();
        Dictionary<KhronosApi, Dictionary<string, Enum>> enums = new();
        Dictionary<string, Constant> constants = new();
        Dictionary<KhronosApi, Dictionary<string, Command>> commands = new();
        Dictionary<string, Feature> features = new();
        Dictionary<string, Extension> extensions = new();

        foreach (XmlNode child in element)
        {
            if(Type.TryDeserializeTo(child, types))
                continue;

            if(Enum.TryDeserializeTo(child, enums, constants))
                continue;
            
            if(Command.TryDeserializeTo(child, commands))
                continue;

            if(Extension.TryDeserializeTo(child, extensions))
            {
                continue;
            }

            if(Feature.TryDeserialize(child, out Feature? feature))
            {
                features.Add(feature.Name, feature);
                continue;
            }
        }

        Types = types.ToImmutableDictionary();
        Enums = enums.ToImmutableDictionary();
        Commands = commands.ToImmutableDictionary();
        Features = features.ToImmutableDictionary();
        Extensions = extensions.ToImmutableDictionary();
        Constants = constants.ToImmutableDictionary();
    }
}
