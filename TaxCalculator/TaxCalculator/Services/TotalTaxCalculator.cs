namespace TaxCalculator.Services;

public static class TotalTaxCalculator
{
    public static (decimal, decimal, decimal, decimal)? Calculate((IIncome, IIncome, IIncome, IIncome) incomes)
    {
        if (incomes is (Salary salary, Remunerations remunerations, BusinessIncome businessIncome, ExtraIncome extraIncome))
            return (salary.CalculateTax(), remunerations.CalculateTax(), extraIncome.CalculateTax(), businessIncome.CalculateTax());

        return null;
    }
}
