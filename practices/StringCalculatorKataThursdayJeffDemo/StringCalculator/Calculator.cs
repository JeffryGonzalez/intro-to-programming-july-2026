
using System.Text.RegularExpressions;

public partial class Calculator
{
    [GeneratedRegex(@"^\/\/(.)\n(.+)$", RegexOptions.Singleline)]
    private static partial Regex CustomDelimetersRegex();

    private static char[] delimeters = [',', '\n'];

    public int Add(string numbers)
    {
        var (matched, nums, delimeter) = MatchAgainstRegex(numbers);
        char[] fixedDelimeters = matched ? [.. delimeters, delimeter] : delimeters;
        return nums == "" ? 0 :
             nums.Split(fixedDelimeters)
             .Sum(int.Parse);

    }

    private static (bool, string, char) MatchAgainstRegex(string nums)
    {
        var numbersToParse = nums;

        var matches = CustomDelimetersRegex().Match(numbersToParse);
        if (matches.Success)
        {
            var customDelimeter = matches.Groups[1].Value;
            var numbersToParseResult = matches.Groups[2].Value;
            return (true, numbersToParseResult, char.Parse(customDelimeter));
        }
        else
        {
            return (false, numbersToParse, ' ');
        }
    }
}
