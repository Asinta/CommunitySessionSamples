var incoming = (
    new Salary(20_000m, 1_500m, 2_000, 0m),
    new Remunerations(2_000m),
    new BusinessIncome(0m, false),
    new ExtraIncome(1_0000m));

var tax = TotalTaxCalculator.Calculate(incoming);

// var incoming2 = (
//     new Salary(20_000m, 1_500m, 2_000, 0m),
//     new BusinessIncome(0m, false),
//     new ExtraIncome(1_0000m),
//     new Remunerations(2_000m));
//
// var tax = TotalTaxCalculator.Calculate(incoming2);

// not null check and deconstruction
if (tax is var (salaryTax, remunerationsTax, businessTax, extraTax))
{
    Console.WriteLine($"Remuneration tax is: {remunerationsTax}m");
    Console.WriteLine($"Total tax for incoming is: {salaryTax + remunerationsTax + businessTax + extraTax}m");
}
else
    Console.WriteLine("Calculation failed");
