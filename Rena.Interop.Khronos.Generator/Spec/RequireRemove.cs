using System.Xml;

namespace Rena.Interop.Khronos.Generator;

public record struct RequireRemove(KhronosApi Api, ApiProfile Profile, string Depends, Dictionary<string, RequireRemove.Command> Commands, Dictionary<KhronosApi, Dictionary<string, RequireRemove.EnumValue>> Enums, Dictionary<string, RequireRemove.Type> Types)
{
    public readonly Dictionary<string, Command> Commands = Commands;
    public readonly Dictionary<KhronosApi, Dictionary<string, EnumValue>> Enums = Enums;
    public readonly Dictionary<string, Type> Types = Types;

    public readonly KhronosApi Api = Api;
    public readonly ApiProfile Profile = Profile;
    public readonly string Depends = Depends;

    public static (bool Success, bool IsRemove) TryDeserialize(XmlNode n, int? defaultExtNumber, out RequireRemove r)
    {
        if(n is not XmlElement element || (n.Name != "require" && n.Name != "remove"))
        {
            r = default;
            return (false, false);
        }

        var commandsBuilder = new Dictionary<string, Command>();
        var enumsBuilder = new Dictionary<KhronosApi, Dictionary<string, EnumValue>>();
        var typesBuilder = new Dictionary<string, Type>();

        foreach (XmlNode child in element)
        {
            if(EnumValue.TryDeserialize(child, defaultExtNumber, out EnumValue v))
            {
                KhronosApi api = KhronosApiExtensions.Parse((child as XmlElement)!.GetAttribute("api"));
                if(!enumsBuilder.TryGetValue(api, out Dictionary<string, RequireRemove.EnumValue>? apiEnums))
                    enumsBuilder.Add(api, apiEnums = new());
                apiEnums.Add(v.Name, v);
                continue;
            }

            if(Command.TryDeserialize(child, out Command c))
            {
                commandsBuilder.Add(c.Name, c);
                continue;
            }

            if(Type.TryDeserialize(child, out Type t))
            {
                typesBuilder.Add(t.Name, t);
                continue;
            }
        }

        r = new(KhronosApiExtensions.Parse(element.GetAttribute("api")), ApiProfileExtensions.FromString(element.GetAttribute("profile")), element.GetAttribute("depends"), commandsBuilder, enumsBuilder, typesBuilder);
        return (true, n.Name == "remove");
    }

    public readonly struct Command(string Name)
    {
        public readonly string Name = Name;

        public static bool TryDeserialize(XmlNode n, out Command command)
        {
            if(n is not XmlElement element || n.Name != "command")
            {
                command = default;
                return false;
            }

            command = new(element.GetAttribute("name"));
            return true;
        }
    }

    public readonly struct EnumValue(string Name, string Extends, string Alias, long Value)
    {
        public readonly string Name = Name;
        public readonly string Extends = Extends;
        public readonly string Alias = Alias;
        public readonly long Value = Value;

        public static bool TryDeserialize(XmlNode n, int? defaultExtNumber, out EnumValue value)
        {
            const string Name = "enum";

            if(n is not XmlElement element || n.Name != Name)
            {
                value = default;
                return false;
            }

            string name = element.GetAttribute("name");
            string extends = element.GetAttribute("extends");
             
            if(string.IsNullOrEmpty(extends))
            {
                value = new(name, string.Empty, string.Empty, default);
                return true;
            }

            string val = element.GetAttribute("value");
            if(!string.IsNullOrEmpty(val))
            {
                value = new(name, extends, string.Empty, long.Parse(val));
                return true;
            }

            string offsetValue = element.GetAttribute("offset");
            if (string.IsNullOrEmpty(offsetValue))
            {
                string bitPosValue = element.GetAttribute("bitpos");

                if (string.IsNullOrEmpty(bitPosValue))
                {
                    string alias = element.GetAttribute("alias");

                    value = new(name, extends, alias, 0);
                    return true;
                }
                else
                {
                    int bitpos = int.Parse(bitPosValue);
                    long bitfield = (long)(1 << bitpos);

                    value = new(name, extends, string.Empty, bitfield); 
                    return true;
                }
            }

            int offset = int.Parse(offsetValue);
            string explicitExtNumber = element.GetAttribute("extnumber");
            int extNumber = defaultExtNumber ?? (string.IsNullOrEmpty(explicitExtNumber) ? 1 : int.Parse(explicitExtNumber));
            int direction = element.GetAttribute("dir") == "-" ? -1 : 1;

            long numericValue = direction * (1000000000 + (extNumber - 1) * 1000 + offset);
            value = new(name, extends, string.Empty, numericValue);
            return true;
        }
    }

    public readonly struct Type(string Name)
    {
        public readonly string Name = Name;

        public static bool TryDeserialize(XmlNode n, out Type type)
        {
            const string Name = "type";
            const string NameAttribute = "name";

            if(n is not XmlElement element || n.Name != Name)
            {
                type = default;
                return false;
            }

            type = new(element.GetAttribute(NameAttribute));
            return true;
        }
    }
}
