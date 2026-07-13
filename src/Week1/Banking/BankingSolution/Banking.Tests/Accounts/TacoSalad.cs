

namespace Banking.Tests.Accounts;

public class TransactionAmountTests
{

    [Fact]
    public void UsingTheAccountForRealzUnitIntegration()
    {
        var account1 = new Account(new StandardBonusCalculator());
        var account2 = new Account(new TimeBoundBonusCalculator(TimeProvider.System));

        // builder.Services.AddScoped<IProvideTimeBoundBonusCalculation,...>
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-0.01)]
    // whatever other examples you need.
    public void InvalidTransactionAmountsOnDeposit(decimal amount)
    {
      
        Assert.Throws<InvalidTransactionAmountException>(
            () => TransactionAmount.From(amount));

        
    }

    [Fact]
    public void UsingImplicitOperators()
    {
        TransactionAmount deposit = 123.38M;

        TransactionAmount other = 1000.23M;

        TransactionAmount x = deposit * other;

        TransactionAmount depositAmount = TransactionAmount.From(82.23M);
        decimal depositAsDecimal = depositAmount;
       
        Assert.Equal(depositAsDecimal, depositAmount.Value);



    }

}
