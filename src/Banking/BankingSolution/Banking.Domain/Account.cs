namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000M; // Fields - variables at class level (private by default)

    public decimal GetBalance()
    {
        
        return _balance; // JFHCI
    }

    public void Deposit(decimal amountToDeposit)
    {
     
        _balance += amountToDeposit;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        _balance -= amountToWithdraw;
    }
}