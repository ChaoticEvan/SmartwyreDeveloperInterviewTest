using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Types
{
    public class AmountPerUom : IIncentiveType
    {
        public decimal CalculateRebateAmount(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            return rebate.Amount * request.Volume;
        }

        public bool IsSuccesful(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
            {
                return false;
            }
            else if (rebate.Amount == 0 || request.Volume == 0)
            {
                return false;
            }

            return true;
        }
    }
}
