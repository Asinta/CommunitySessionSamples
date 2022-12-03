namespace TaxCalculator.Models;

public class Remunerations : IIncome
{
    public Remunerations(decimal amount) => Amount = amount;
    public decimal Amount { get; set; }

    // 劳务报酬所得的应纳税所得额为：收入金额×（1-20%）×20%-速算扣除数
    // 级数	预扣预缴
    // 应纳税所得额	预扣率（%）	速算扣除数
    // 1	不超过20000元的	20	0
    // 2	超过20000元至50000元的部分	30	2000
    // 3	超过50000元的部分	40	7000
    public decimal CalculateTax() => Amount switch
    {
        <= 20_000m => Amount * 0.8m * 0.2m,
        > 20_000m and <= 50_000 => Amount * 0.8m * 0.3m - 2_000m,
        _ => Amount * 0.8m * 0.4m - 7_000m
    };
}
