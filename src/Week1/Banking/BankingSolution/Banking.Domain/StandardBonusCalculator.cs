using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain;

public class StandardBonusCalculator : IProvideBonusCalculationForAccounts
{
    /// all the wisdom of bonus calculation for the entire bank lives here.
    public decimal CalculateBonusForDeposit(decimal balance, TransactionAmount amountToDeposit)
    {
        return balance >= 5000M ? amountToDeposit * .10M : 0;
    }
}
