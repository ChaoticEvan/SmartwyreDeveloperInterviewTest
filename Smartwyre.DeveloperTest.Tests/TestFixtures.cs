using Moq;
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

        public static Mock<IRebateDataStore> SetupRebateMock(Rebate rebate)
        {
            var mock = new Mock<IRebateDataStore>();
            mock.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
            return mock;
        }
        public static Mock<IProductDataStore> SetupProductMock(Product product)
        {
            var mock = new Mock<IProductDataStore>();
            mock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);
            return mock;
        }
    }
}
