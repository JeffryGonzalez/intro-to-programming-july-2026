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

 
}
