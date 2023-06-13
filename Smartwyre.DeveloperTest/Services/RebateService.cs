using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private IRebateDataStore RebateDataStore { get; set; }
    private IProductDataStore ProductDataStore { get; set; }

    public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
    {
        ProductDataStore = productDataStore;
        RebateDataStore = rebateDataStore;
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = RebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = ProductDataStore.GetProduct(request.ProductIdentifier);

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
        if (rebate == null || product == null || rebate.Incentive == null)
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
