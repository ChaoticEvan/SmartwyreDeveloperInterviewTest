namespace Smartwyre.DeveloperTest.Types;

public class Rebate
{
    public string Identifier { get; set; }
    public IIncentiveType Incentive { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
}
