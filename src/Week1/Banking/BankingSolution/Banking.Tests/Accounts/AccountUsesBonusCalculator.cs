using Banking.Tests.TestDoubles;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Tests.Accounts;

public  class AccountUsesBonusCalculator
{
    [Fact]
    public void UsesCalculatorAndAppliedBonus()
    {
        var account = new Account(new StubbedBonusCalculator());
        var amountToDeposit = 108.23M;

        account.Deposit(amountToDeposit);

        Assert.Equal(5150.65M, account.GetBalance());

    }

    [Fact]
    public void UsesCalculatorAndAppliesBonusWithSubstitute()
    {
        // Arrange
        var sub = Substitute.For<IProvideBonusCalculationForAccounts>();
        var account = new Account(sub);
        TransactionAmount amountToDeposit = 420.69M; // April 20, 1969 - Jeff's Birthday. 
        var openingBalance = 5000M;
        sub.CalculateBonusForDeposit(openingBalance, amountToDeposit).Returns(100M);

        // Act
        account.Deposit(amountToDeposit);


        // Assert
        Assert.Equal(openingBalance + amountToDeposit + 100M, account.GetBalance());
    }
}
