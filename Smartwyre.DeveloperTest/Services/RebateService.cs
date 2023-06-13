using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var rebateDataStore = new RebateDataStore();
        var productDataStore = new ProductDataStore();

        Rebate rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();

        if(!IsRebateValid(rebate, product, request))
        {
            result.Success = false;
            return result;
        }

        result.Success = true;

        var storeRebateDataStore = new RebateDataStore();
        storeRebateDataStore.StoreCalculationResult(rebate, rebate.Incentive.CalculateRebateAmount(rebate, product, request));

        return result;
    }

    private bool IsRebateValid(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        if (rebate == null || product == null)
        {
            return false;
        }

        if (!rebate.Incentive.IsSuccesful(rebate, product, request))
        {
            return false;
        }

        return true;
    }
}
