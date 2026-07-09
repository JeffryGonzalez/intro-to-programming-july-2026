using System.Text.RegularExpressions;

namespace StringCalculator;

public partial class Numbers
{
    [GeneratedRegex(@"^\/\/(.)\n(.+)$", RegexOptions.Singleline)]
    private static partial Regex CustomDelimitersRegex();

    private static readonly char[] Delimiters = [',', '\n'];

    private Numbers(string numbers)
    {
        Value = numbers switch
        {
            "" => "0",
            _ => numbers
        };
    }

    private string Value { get; }
    public static implicit operator string(Numbers numbers) => numbers.Value;
    public static implicit operator Numbers(string n) => new(n);
    public override string ToString() => Value;

    /*
     * This is an example of a named tuple return type. This returns a bool, string, and char.
     * We don't tend to use this a lot in application code, but it's cool to see.
     */
    private static (bool matched, string nums, char delimiter) MatchAgainstRegex(string nums)
    {
        var numbersToParse = nums;
        var matches = CustomDelimitersRegex().Match(numbersToParse);
        if (matches.Success)
        {
            var customDelimiter = matches.Groups[1].Value;
            var numbersToParseResult = matches.Groups[2].Value;
            return (true, numbersToParseResult, char.Parse(customDelimiter));
        }
        else
        {
            return (false, numbersToParse, ' ');
        }
    }

    public int[] Normalized
    {
        get
        {
            var (matched, nums, delimiter) = MatchAgainstRegex(Value);
            // Kind of icky, but trying to throw examples of stuff here, creating a new array of
            // delimiters if there is a match.
            var fixedDelimiters = matched ? [.. Delimiters, delimiter] : Delimiters;
            // add the code to handle the delimiters, etc. and just return a string[], or even int[]
            return nums.Split(fixedDelimiters).Select(int.Parse).ToArray();
        }
    }
}