


using Banking.Tests.TestDoubles;

namespace Banking.Tests.Accounts;

// AccountTests

public class NewAccounts
{
    [Fact]
    public void HaveTheCorrectBalance()
    {
      // Arange - Given
        var account = new Account(new DummyBonusCalculator());

        // Act - When
        decimal balance = account.GetBalance();

        // Assert - Then    
        Assert.Equal(5000M, balance);
    }
}
