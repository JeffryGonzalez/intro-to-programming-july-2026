
namespace Banking.Domain;

public class TransactionAmount
{
    private decimal _amount;
    public decimal Value { get { return _amount; } set { _amount = value; } }

    private TransactionAmount(decimal amount)
    {
        if(amount <= 0)
        {
            throw new InvalidTransactionAmountException();
        } else
        {
            Value = amount;
        }
    }

    /// <summary>
    /// Gives you a transaction amount or throws an exception from a decimal
    /// </summary>
    /// <param name="amount">An amount > 0</param>
    /// <returns>TransactionAmount</returns>
    
    public static  TransactionAmount From(decimal amount)
    {
        return new TransactionAmount(amount); // Use my own constructor
    }

    public static TransactionAmount From(int amount)
    {
        return new(amount);
    }

    public static implicit operator Decimal(TransactionAmount amount) => amount.Value;
    public static implicit operator TransactionAmount(decimal value) => new(value);
}
