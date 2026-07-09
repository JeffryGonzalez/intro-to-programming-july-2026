using System.Diagnostics.CodeAnalysis;

namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000M; // Fields - variables at class level (private by default)

    public decimal GetBalance()
    {

        return _balance; // JFHCI
    }

    // If you give a valid transaction amount, I'll add this to your account.
    public void Deposit(TransactionAmount amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    public void Withdraw(TransactionAmount amountToWithdraw)
    {

        if (WouldCauseOverdraft(amountToWithdraw))
        {
            var ex = new OverdraftException
            {
                CurrentBalance = _balance
            };
            throw ex;
        }
        _balance -= amountToWithdraw;
    }

    private bool WouldCauseOverdraft(decimal amountToWithdraw)
    {
        return amountToWithdraw > _balance;
    }

    public static Account CreateAccount(string firstName, string lastName, char mi)
    {
        // firstName can't be null, lastName has to be at least three letter, mi can't be empty, etc.?
        var errors = new List<string>();
        if (firstName == "Jeff")
        {
            errors.Add("Dumb First Name");
        }
        if (lastName == "")
        {
            errors.Add("Lastname is blank");
        }
        if (errors.HasSome)
        {
            var ex = new AccountCreationException
            {
                Errors = errors
            };
            throw ex;
        }
        return new Account();
    }


}


public class AccountCreationException : ArgumentOutOfRangeException
{

    public List<string> Errors { get; internal set; } = [];

}


public static class ListExtensions
{
    extension(IList<string> strings)
    {
        public bool HasSome
        {
            get
            {
                return strings.Count > 0;
            }
        }
    }
}