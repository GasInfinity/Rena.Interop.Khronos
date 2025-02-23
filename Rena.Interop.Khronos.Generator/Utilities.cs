using System.Text;
using System.Text.RegularExpressions;

namespace Rena.Interop.Khronos.Generator;

public static partial class Utilities
{
    [GeneratedRegex("_", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex UnderscoreGeneratedRegex();

    public static string SnakeToPascalcase(ReadOnlySpan<char> value)
        => string.Create(value.Length - UnderscoreGeneratedRegex().Count(value), value, static (span, value) => {
            int idx = 0;

            bool shouldBeUpper = true;
            int i = 0;
            for(; idx < value.Length; ++idx)
            {
                if(value[idx] == '_')
                {
                    shouldBeUpper = true;
                    continue;
                }

                span[i++] = shouldBeUpper ? char.ToUpper(value[idx]) : char.ToLower(value[idx]);
                shouldBeUpper = char.IsDigit(value[idx]);
            }
        });

    public static int LongestCommonSuffixLengthIgnoreCase(IEnumerable<string> values, bool underscored = true)
    {
        string? first = values.FirstOrDefault();

        if(first == null)
            return 0;

        ReadOnlySpan<char> longestCommon = first.AsSpan();
        foreach(string value in values.Skip(1))
        {
            int i = value.Length, j = longestCommon.Length;
            while(i > 0 && j > 0 && char.ToUpperInvariant(value[i - 1]) == char.ToUpperInvariant(longestCommon[j - 1])) 
            {
                --i; --j;
            }

            longestCommon = longestCommon[j..];

            if(longestCommon.Length == 0)
                break;
        }

        if(underscored && !longestCommon.StartsWith('_'))
            return longestCommon.IndexOf('_') is int underscore ? (underscore != -1 ? longestCommon.Length - underscore : 0) : longestCommon.Length; 

        return longestCommon.Length;
    }

    public static int LongestCommonPrefixLengthIgnoreCase(IEnumerable<string> values, bool underscored = true)
    {
        string? first = values.FirstOrDefault();

        if(first == null)
            return 0;

        ReadOnlySpan<char> longestCommon = first.AsSpan();
        foreach(string value in values.Skip(1))
        {
            int i = 0;
            while(i < value.Length && i < longestCommon.Length && char.ToUpperInvariant(value[i]) == char.ToUpperInvariant(longestCommon[i])) ++i;
            longestCommon = longestCommon[..i];

            if(longestCommon.Length == 0)
                break;
        }

        // We want to split till underscores, so we do this final check
        if(underscored && !longestCommon.EndsWith('_'))
            return longestCommon.LastIndexOf('_') is int lastUnderscore ? (lastUnderscore != -1 ? lastUnderscore : 0) : longestCommon.Length; 

        return longestCommon.Length;
    }

    const string ValidStartChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string ValidContinueChars = "_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string GenerateRandomIdentifier()
    {
        var result = new StringBuilder();
        result.Append(ValidStartChars[Random.Shared.Next(ValidStartChars.Length)]);
        for (int i = 1; i < 16; i++)
            result.Append(ValidContinueChars[Random.Shared.Next(ValidContinueChars.Length)]);
        
        return result.ToString();
    }

    public static string EscapeIdentifier(string value)
        => ReservedWords.TryGetValue(value, out string? escaped) ? escaped : value;

    private static readonly Dictionary<string, string> ReservedWords = new Dictionary<string, string>()
    {
        { "object", "@object" }
    };
}
