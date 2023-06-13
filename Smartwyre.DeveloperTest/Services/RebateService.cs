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

        if (rebate == null || product == null)
        {
            result.Success = false;
            return result;
        }
        
        if (!rebate.Incentive.IsSuccesful(rebate, product, request))
        {
            result.Success = false;
            return result;
        }

        result.Success = true;
        var rebateAmount = rebate.Incentive.CalculateRebateAmount(rebate, product, request);

        var storeRebateDataStore = new RebateDataStore();
        storeRebateDataStore.StoreCalculationResult(rebate, rebateAmount);

        return result;
    }
}
