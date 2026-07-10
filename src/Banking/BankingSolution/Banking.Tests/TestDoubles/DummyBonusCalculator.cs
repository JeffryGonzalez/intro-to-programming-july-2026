using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Tests.TestDoubles;

public class DummyBonusCalculator : IProvideBonusCalculationForAccounts
{
    public decimal CalculateBonusForDeposit(decimal balance, TransactionAmount amountToDeposit)
    {
        return 0;
    }
}
