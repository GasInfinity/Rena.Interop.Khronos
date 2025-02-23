namespace Rena.Interop.Khronos.Generator;

public enum ApiProfile : byte
{
    None,
    Compatibility,
    Core
}

public static class ApiProfileExtensions
{
    public static string ToString(this ApiProfile api)
        => api switch
        {
            ApiProfile.Compatibility => "compatibility",
            ApiProfile.Core => "core",
            _ => string.Empty
        };

    public static ApiProfile FromString(string value)
        => value switch
        {
            "compatibility" => ApiProfile.Compatibility,
            "core" => ApiProfile.Core,
            _ => ApiProfile.None
        };
}
