using System.Diagnostics.CodeAnalysis;

namespace Banking.Domain;

// "Flags" 
public enum AccountTypes {  Standard, Gold }
public class Account(IProvideBonusCalculationForAccounts _bonusCalculator)
{
    private decimal _balance = 5000M; // Fields - variables at class level (private by default)

    // Interfaces model functionality abstractly, classes provide implementation of one or more
    // interfaces. Interfaces describe a set of operations a type "can do"
    //private IProvideBonusCalculationForAccounts _bonusCalculator;
    //public Account(IProvideBonusCalculationForAccounts bonusCalculator)
    //{
    //    _bonusCalculator = bonusCalculator;
    //}

    public decimal GetBalance()
    {

        return _balance; // JFHCI
    }

    // If you give a valid transaction amount, I'll add this to your account.
    public virtual void Deposit(TransactionAmount amountToDeposit)
    {
        
        // Write the Code You wish you had 
        decimal bonus = _bonusCalculator.CalculateBonusForDeposit(_balance, amountToDeposit);
      

        _balance += amountToDeposit + bonus ; // failing test - you didn't interact correctly with the bonus calculator.
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