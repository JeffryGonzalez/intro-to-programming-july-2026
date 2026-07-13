namespace Banking.Domain;

public class OverdraftException : ArgumentOutOfRangeException
{
    public decimal CurrentBalance { get; internal set; }
}
