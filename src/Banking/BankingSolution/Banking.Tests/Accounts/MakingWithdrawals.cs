using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Tests.Accounts;

public class MakingWithdrawals
{
    // You do this. Write a fact or theory. 
    [Fact]
    public void WithdrawalsReduceBalance()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 101.23M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }
}
