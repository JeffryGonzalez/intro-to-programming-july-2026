using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain;

public class TimeBoundBonusCalculator(TimeProvider clock) : IProvideBonusCalculationForAccounts
{
    public decimal CalculateBonusForDeposit(decimal balance, TransactionAmount amountToDeposit)
    {
        if(clock.GetLocalNow().Hour >= 9 && clock.GetLocalNow().Hour < 17 && balance >= 5000M)
        {
            return amountToDeposit * .10M;
        }
        return amountToDeposit * 0.05M;
        // this is all wrong, not taking into consider days of week ,etc .

    }
}
