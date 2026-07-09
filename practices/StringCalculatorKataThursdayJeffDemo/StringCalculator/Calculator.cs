
using System.Text.RegularExpressions;

public partial class Calculator
{
    [GeneratedRegex(@"^//(.)\n(.*)$", RegexOptions.IgnoreCase)]
    private static partial Regex CustomDelimetersRegex();
    public int Add(string numbers)
    {
        if(numbers == "")
        {
            return 0;
        }
        var delimeters = new List<char>()
        {
            ',',
            '\n'
        };
        var matches = Calculator.CustomDelimetersRegex().Match(numbers);
        if(matches.Success)
        {
            var lhs = matches.Groups[1].Captures[0].Value;
            var rhs = matches.Groups[2].Captures[0].Value;
            delimeters.Add(char.Parse(lhs));
            numbers = rhs;
            
        }

        return numbers == "" ? 0 :
             numbers.Split([.. delimeters])
             .Sum(int.Parse);

    }
}
