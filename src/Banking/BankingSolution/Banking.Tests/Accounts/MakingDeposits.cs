
using Banking.Domain;

namespace Banking.Tests.Accounts;

public class MakingDeposits
{
    [Theory]
    [InlineData(112.01)]
    [InlineData(5001.23)]
 
    public void IncreasesTheBalance(decimal amountToDeposit)
    {
        // Given
        var account = new Account();
        
        var openingBalance = account.GetBalance();
        // When

        // "Fixing to run this method == yellow"
        account.Deposit(amountToDeposit);

        // then

        Assert.Equal(amountToDeposit + openingBalance, account.GetBalance());

    }


    //[Fact]
    //public void CanDepositNegativeValues()
    //{
    //    var account = new Account();
    //    var openingBalance = account.GetBalance();

    //    account.Deposit(-100);

    //    Assert.Equal(4900, account.GetBalance());
    //}

    [Fact(Skip ="Contemplate this")]
    public void DemoDeleteMe()
    {
        var damiansAccount = new Account(); // instance is a object built from a class
        var richardsAccount = new Account(); // instance 2


        Assert.Equal(damiansAccount.GetBalance(), richardsAccount.GetBalance());

        richardsAccount.Deposit(3000);

        Assert.Equal(damiansAccount.GetBalance(), richardsAccount.GetBalance());

    }
}
