namespace TaxCalculator.Models;

public class Salary : IIncome
{
    public Salary(decimal totalAmount, decimal specificDeduction, decimal specificExtraDeduction, decimal otherDeduction)
    {
        Amount = (totalAmount - specificDeduction - specificExtraDeduction - otherDeduction - Baseline) * 12;
    }
    
    private const decimal Baseline = 5_000m;
    public decimal Amount { get; set; }
    
    // 个人所得税计算明细=(税前收入-5000元(起征点)-专项扣除(三险一金等)-专项附加扣除-依法确定的其他扣除)×适用税率-速算扣除数计算方法
    // 级数	全年应纳税所得额	税率（%）	速算扣除数
    // 1	不超过36000元的	3	0
    // 2	超过36000元至144000元的部分	10	2520
    // 3	超过144000元至300000元的部分	20	16920
    // 4	超过300000元至420000元的部分	25	31920
    // 5	超过420000元至660000元的部分	30	52920
    // 6	超过660000元至960000元的部分	35	85920
    // 7	超过960000元的部分	45	181920
    public decimal CalculateTax() => Amount switch
    {
        <= 36_000m => Amount * 0.03m,
        > 36_000m and <= 144_000m => Amount * 0.1m - 2_520m,
        > 144_000m and <= 300_000m => Amount * 0.2m - 16_920m,
        > 300_000m and <= 420_000m => Amount * 0.25m - 31_920m,
        > 420_000m and <= 660_000m => Amount * 0.3m - 52_920m,
        > 660_000m and <= 960_000m => Amount * 0.35m - 85_920,
        _ => Amount * 0.45m - 181_920m
    };
}
