namespace StringCalculator;

/// <summary>
/// WARNING: This is a really overly done stupid version of String Calculator. Just showing off some things.
/// </summary>
public class Calculator(ILogStringCalculations _calculatorLogger, IProvideMaintenencNotifications _maintWebServer)
{
    
    private const int Limit = 1000;
    public int Add(Numbers numbers)
    {
        // anything greater or equal to 1000 is ignored.
        var numbersLessThanLimit = numbers.Normalized.Where(n => n <= Limit).ToList();
        
        // No negatives
        var negativeNumbers = numbersLessThanLimit.Where(n => n < 0).ToList();
        
        if (negativeNumbers.Count != 0)
        {
            throw new NoNonNegativeNumbersException(negativeNumbers);
        }
        var result = numbersLessThanLimit.Sum();
        // Todo - Part 2
        // Every result should be written to a logger. 
        try
        {
            _calculatorLogger.LogResult(result.ToString());

        } catch
        {
            _maintWebServer.NotifyOfStringCalculatorFailure("Broke!");

        }
        return result;
    }
}

public interface ILogStringCalculations
{
    void LogResult(string result);
}