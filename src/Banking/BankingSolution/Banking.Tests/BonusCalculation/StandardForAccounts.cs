using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Tests.BonusCalculation;

public class StandardForAccounts
{
    [Theory]
    [InlineData(5000, 100, 10)]
    [InlineData(5000, 200, 20)]
    public void SomeExamples(decimal balance, decimal amount, decimal expected)
    {
        var calc = new StandardBonusCalculator();

        var bonus = calc.CalculateBonusForDeposit(balance, amount);

        Assert.Equal(expected, bonus);
    }


    [Theory]
    [InlineData(4999.99, 100, 0)]
    [InlineData(4999.99, 200, 0)]
    public void NoBonus(decimal balance, decimal amount, decimal expected)
    {
        var calc = new StandardBonusCalculator();

        var bonus = calc.CalculateBonusForDeposit(balance, amount);

        Assert.Equal(expected, bonus);
    }
}
