namespace TaxCalculator.Models;

public interface IIncome
{
    public decimal Amount { get; set; }

    decimal CalculateTax();
}
