

namespace StringCalculator;
public class CalculatorTests
{
    private Calculator calculator;
    public CalculatorTests()
    {
        calculator = new Calculator();
    }
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("12", 12)]
    [InlineData("108", 108)]
    public void SingleDigits(string nums, int expected)
    {
        var answer = calculator.Add(nums);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,2", 4)]
    [InlineData("12,3", 15)]
    [InlineData("108,300", 408)]

    public void TwoNumbers(string nums, int expected)
    {
        var answer = calculator.Add(nums);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    [InlineData("120, 10, 10", 140)]
    public void Arbitrary(string nums, int expected)
    {
        var answer = calculator.Add(nums);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("1\n5", 6)]
    [InlineData("1,2\n3", 6)]
    public void MixedDelimeters(string nums, int expected)
    {
        var answer = calculator.Add(nums);

        Assert.Equal(expected, answer);
    }
}
