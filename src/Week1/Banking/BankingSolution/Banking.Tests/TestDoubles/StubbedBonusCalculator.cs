using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Tests.TestDoubles;

public class StubbedBonusCalculator : IProvideBonusCalculationForAccounts
{
    public decimal CalculateBonusForDeposit(decimal balance, TransactionAmount amountToDeposit)
    {
        return balance == 5000M && amountToDeposit == 108.23M ? 42.42M : 0;  
    }
}
