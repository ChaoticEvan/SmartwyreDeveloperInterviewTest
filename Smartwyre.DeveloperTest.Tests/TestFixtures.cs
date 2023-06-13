using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Tests
{
    public static class TestFixtures
    {
        public static Rebate BuildRebate(decimal amount, decimal percentage, IIncentiveType incentiveType)
        {
            return new Rebate
            {
                Amount = amount,
                Percentage = percentage,
                Incentive = incentiveType
            };
        }

        public static Product BuildProduct(decimal price, SupportedIncentiveType supportedIncentiveType)
        {
            return new Product
            {
                Price = price,
                SupportedIncentives = supportedIncentiveType
            };
        }
    }
}
