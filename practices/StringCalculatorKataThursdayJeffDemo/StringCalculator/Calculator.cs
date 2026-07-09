namespace StringCalculator;

/// <summary>
/// WARNING: This is a really overly done stupid version of String Calculator. Just showing off some things.
/// </summary>
public class Calculator
{
    private const int Limit = 1000;
    public int Add(Numbers numbers)
    {
        var numbersLessThanLimit = numbers.Normalized.Where(n => n <= Limit).ToList();
        
        var negativeNumbers = numbersLessThanLimit.Where(n => n < 0).ToList();
        
        if (negativeNumbers.Count != 0)
        {
            throw new NoNonNegativeNumbersException(negativeNumbers);
        }
        var result = numbersLessThanLimit.Sum();
        // Todo - Part 2
        return result;
    }
}