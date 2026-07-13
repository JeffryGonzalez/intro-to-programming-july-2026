namespace Banking.Domain;

public interface IProvideBonusCalculationForAccounts
{
    decimal CalculateBonusForDeposit(decimal balance, TransactionAmount amountToDeposit);
}