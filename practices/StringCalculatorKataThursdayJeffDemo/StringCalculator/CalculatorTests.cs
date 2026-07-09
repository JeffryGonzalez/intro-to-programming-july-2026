namespace StringCalculator;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    [Fact]
    public void EmptyStringReturnsZero()
    {
        var result = _calculator.Add("");
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("12", 12)]
    [InlineData("108", 108)]
    public void SingleDigits(string nums, int expected)
    {
        var answer = _calculator.Add(nums);
        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,2", 4)]
    [InlineData("12,3", 15)]
    [InlineData("108,300", 408)]
    public void TwoNumbers(string nums, int expected)
    {
        var answer = _calculator.Add(nums);
        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    [InlineData("120, 10, 10", 140)]
    public void Arbitrary(string nums, int expected)
    {
        var answer = _calculator.Add(nums);
        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("1\n5", 6)]
    [InlineData("1,2\n3", 6)]
    public void MixedDelimiters(string nums, int expected)
    {
        var answer = _calculator.Add(nums);
        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("//#\n1#2#3", 6)]
    [InlineData("//#\n1,2#3", 6)]
    [InlineData("//;\n1;2,5", 8)]
    [InlineData("//;\n1;2\n5", 8)]
    public void CustomDelimiters(string nums, int expected)
    {
        var answer = _calculator.Add(nums);
        Assert.Equal(expected, answer);
    }

    // Showing how to do MemberData. Can also do ClassData - see the docs.
    public static IEnumerable<TheoryDataRow<string, int[]>> NegativesTheoryValues =>
    [
        new("-32", [-32]), 
        new("1,-3\n-18", [-3, -18])
    ];

    [Theory]
    [MemberData(nameof(NegativesTheoryValues))]
    public void NoNonNegativeNumbers(string nums, int[] numbers)
    {
        var ex = Assert.Throws<NoNonNegativeNumbersException>(() => _calculator.Add(nums));
        Assert.Equivalent(numbers, ex.NegativeNumbers);
    }

    [Theory]
    [InlineData("1000,1", 1001)]
    [InlineData("1001,1", 1)]
    public void NumbersBiggerThanLimitAreIgnored(string nums, int expected)
    {
        var answer = _calculator.Add(nums);
        Assert.Equal(expected, answer);
    }
}