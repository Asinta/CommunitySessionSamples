namespace TaxCalculator.Models;

public class ExtraIncome : IIncome
{
    public ExtraIncome(decimal amount) => Amount = amount;
    public decimal Amount { get; set; }

    public decimal CalculateTax() => Amount * 0.2m;
}
