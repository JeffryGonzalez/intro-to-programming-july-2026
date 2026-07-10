using Banking.Tests.TestDoubles;
using Microsoft.Extensions.Time.Testing;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Tests.BonusCalculation;

public class TimeBoundBonusCalculation
{


    [Theory]
    [InlineData(5000, 100, 10)]
    [InlineData(5000, 200, 20)]
    public void IfDuringBusinessHours(decimal balance, decimal amount, decimal expected)
    {
        var fakeOpenTime = new DateTimeOffset(2026, 7, 10, 10, 00, 00, TimeSpan.FromHours(-3));
        var fakeClock = new FakeTimeProvider(fakeOpenTime);
        var calc = new TimeBoundBonusCalculator(fakeClock);

        var bonus = calc.CalculateBonusForDeposit(balance, amount);

        Assert.Equal(expected, bonus);
    }


    [Theory]
    [InlineData(5000, 100, 5)]
    [InlineData(5000, 200, 10)]
    public void IfOutsideBusinessHours(decimal balance, decimal amount, decimal expected)
    {

        var fakeOpenTime = new DateTimeOffset(2026, 7, 10, 3, 00, 00, TimeSpan.FromHours(-3));
        var fakeClock = new FakeTimeProvider(fakeOpenTime);
        var calc = new TimeBoundBonusCalculator(fakeClock);

        var bonus = calc.CalculateBonusForDeposit(balance, amount);

        Assert.Equal(expected, bonus);
    }


    //[Theory]
    //[InlineData(4999.99, 100, 0)]
    //[InlineData(4999.99, 200, 0)]
    //public void DuringBusinessNoBonus(decimal balance, decimal amount, decimal expected)
    //{
    //    var calc = new TimeBoundBonusCalculator();

    //    var bonus = calc.CalculateBonusForDeposit(balance, amount);

    //    Assert.Equal(expected, bonus);
    //}

    //[Theory]
    //[InlineData(4999.99, 100, 0)]
    //[InlineData(4999.99, 200, 0)]
    //public void OutsideBusinessHoursNoBunus(decimal balance, decimal amount, decimal expected)
    //{
    //    var calc = new TimeBoundBonusCalculator();

    //    var bonus = calc.CalculateBonusForDeposit(balance, amount);

    //    Assert.Equal(expected, bonus);
    //}
}
