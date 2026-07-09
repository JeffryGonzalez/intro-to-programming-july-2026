namespace StringCalculator;

public class NoNonNegativeNumbersException(List<int> negativeNumbers) : ArgumentException
{
    public List<int> NegativeNumbers { get; set; } = negativeNumbers;
}