using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Types
{
    public class FixedCashAmount : IIncentiveType
    {
        public bool IsSuccesful(Rebate rebate, Product product)
        {
            if (rebate == null || product == null)
            {
                return false;
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
            {
                return false;
            }
            else if (rebate.Amount == 0)
            {
                return false;
            }
    
            return true;
        }
    }
}
