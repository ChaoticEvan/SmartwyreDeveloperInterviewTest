namespace Smartwyre.DeveloperTest.Types;

public enum IncentiveType
{
    FixedRateRebate,
    AmountPerUom,
    FixedCashAmount
}

public interface IIncentiveType
{
    public bool IsSuccesful();
}
