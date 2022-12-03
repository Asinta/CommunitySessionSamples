namespace TaxCalculator.Models;

public class BusinessIncome : IIncome
{
    public BusinessIncome(decimal amount, bool isBusinessIncomeValid)
    {
        Amount = amount;
        IsBusinessIncomeValid = isBusinessIncomeValid;
    }

    public decimal Amount { get; set; }
    private bool IsBusinessIncomeValid { get; }

    // 级数	全年应纳税所得额	税率（%）	速算扣除数
    // 1	不超过30000元的	5	0
    // 2	超过30000元至90000元的部分	10	1500
    // 3	超过90000元至300000元的部分	20	10500
    // 4	超过300000元至500000元的部分	30	40500
    // 5	超过500000元的部分	35	65500
    public decimal CalculateTax() => Amount switch
    {
        <= 30_000m when IsBusinessIncomeValid => Amount * 0.05m,
        > 30_000m and <= 90_000m when IsBusinessIncomeValid => Amount * 0.1m - 1500m,
        > 90_000m and <= 300_000m when IsBusinessIncomeValid => Amount * 0.2m - 10_500m,
        > 300_000m and <= 500_000 when IsBusinessIncomeValid => Amount * 0.3m - 40_500m,
        _ when IsBusinessIncomeValid => Amount * 0.35m - 65_500m,
        _ when !IsBusinessIncomeValid => 0m,
        _ => throw new ArgumentOutOfRangeException()
    };
}
