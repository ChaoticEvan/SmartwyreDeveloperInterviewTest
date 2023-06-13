namespace Smartwyre.DeveloperTest.Types;

public enum IncentiveType
{
    FixedRateRebate,
    AmountPerUom,
    FixedCashAmount
}

public interface IIncentiveType
{
    bool IsSuccesful(Rebate rebate, Product product, CalculateRebateRequest request);
}
