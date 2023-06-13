namespace Smartwyre.DeveloperTest.Types;

public interface IIncentiveType
{
    bool IsSuccesful(Rebate rebate, Product product, CalculateRebateRequest request);

    decimal CalculateRebateAmount(Rebate rebate, Product product, CalculateRebateRequest request);
}
