using System.Text;
using System.Xml;
using Microsoft.Extensions.ObjectPool;

namespace Rena.Interop.Khronos.Generator;

public readonly record struct Command
{
    public readonly OrderedDictionary<string, Param> Parameters;
    public readonly Proto? Proto;
    public readonly string Alias;
    public readonly string SharpPointerType;
    public readonly string Name;

    public bool IsAlias
        => Proto == null;

    public Command(Proto? proto, string name, string alias, OrderedDictionary<string, Param> parameters)
    {
        Proto = proto;
        Name = name;
        Alias = alias;
        Parameters = parameters;

        if(!IsAlias)
            SharpPointerType = SharpPointerTypeFromCommand(this);
        else
            SharpPointerType = string.Empty;
    }

    public static bool TryDeserializeTo(XmlNode n, Dictionary<KhronosApi, Dictionary<string, Command>> definedCommands)
    {
        if(n is not XmlElement element || n.Name != "commands")
            return false;

        foreach(XmlNode c in element)
        {
            if(c is not XmlElement child || c.Name != "command")
                continue;

            KhronosApi api = KhronosApiExtensions.Parse(child.GetAttribute("api"));

            if(!definedCommands.TryGetValue(api, out Dictionary<string, Command>? apiCommands))
                definedCommands.Add(api, apiCommands = new());

            Proto? proto = null;
            string name = string.Empty;
            if(child["proto"] is XmlElement protoElement)
            {
                proto = new(protoElement); 
                name = proto.Name;
            }
            else
            {
                name = child.GetAttribute("name");
            }

            string alias = child["alias"]?.GetAttribute("name") ?? child.GetAttribute("alias");

            OrderedDictionary<string, Param> parameters = [];
            foreach(XmlNode p in child)
            {
                if(p is not XmlElement param || p.Name != "param")
                    continue;

                Param parameter = new(param);
                parameters.TryAdd(parameter.Name, parameter);
            }

            apiCommands.Add(name, new Command(proto, name, alias, parameters));
        }

        return true;
    }

    private static readonly DefaultObjectPool<StringBuilder> BuilderPool = new(new DefaultPooledObjectPolicy<StringBuilder>());
    private static string SharpPointerTypeFromCommand(Command command)
    {
        StringBuilder builder = BuilderPool.Get();
        builder.Append("delegate* unmanaged<");

        foreach (var param in command.Parameters.Values)
            builder.Append($"{param.Type}, ");

        builder.Append($"{command.Proto!.Type}>");

        var functionType = builder.ToString();
        builder.Clear();
        BuilderPool.Return(builder);
        return functionType;
    }
}
