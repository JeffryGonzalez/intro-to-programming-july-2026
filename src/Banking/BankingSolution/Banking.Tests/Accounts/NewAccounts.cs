
using Banking.Domain;

namespace Banking.Tests.Accounts;

// AccountTests

public class NewAccounts
{
    [Fact]
    public void HaveTheCorrectBalance()
    {
      // Arange - Given
        var account = new Account();

        // Act - When
        decimal balance = account.GetBalance();

        // Assert - Then    
        Assert.Equal(5000M, balance);
    }
}
