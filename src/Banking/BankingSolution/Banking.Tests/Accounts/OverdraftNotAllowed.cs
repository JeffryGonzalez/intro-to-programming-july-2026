namespace Banking.Tests.Accounts;

public class OverdraftNotAllowed
{
    // If you take more than you have in a withdrawal, your balance doesn't reduce.

    [Fact]
    public void DoesNotReduceBalance()
    {
        // even if an exception is thrown, we want to be sure the balance isn't
        // modified.
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + .01M;

        try
        {
            account.Withdraw(amountToWithdraw);
        }
        catch
        {
            // gulp
        }
        finally
        {
            Assert.Equal(openingBalance, account.GetBalance());

        }


    }

    // I want a test that proves the exception is thrown on overdraft
    [Fact]
    public void OverdraftExceptionIsThrown()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + .01M;


        var caught = Assert.Throws<OverdraftException>(() => account.Withdraw(amountToWithdraw));

        Assert.Equal(openingBalance, caught.CurrentBalance);
    }
}
