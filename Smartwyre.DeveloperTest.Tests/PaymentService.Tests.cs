using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void ReturnsFailureWhenUsingDefaultStores()
    {
        RebateService service = new RebateService(new RebateDataStore(), new ProductDataStore());
        var result = service.Calculate(new CalculateRebateRequest());
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact] 
    public void FixedCashAmountReturnsSuccessWhenIncentiveTypeIsSupported()
    {
        // Arrange
        Rebate rebate = new Rebate()
        {
            Amount = 10,
            Incentive = new FixedCashAmount(),
        };
        Product product = new Product()
        { 
            Price = 5,
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        };
        Mock<IRebateDataStore> rebateMock = new Mock<IRebateDataStore>();
        rebateMock.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        Mock<IProductDataStore> productMock = new Mock<IProductDataStore>();
        productMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);
        var result = service.Calculate(new CalculateRebateRequest());

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
    }

    [Fact]
    public void FixedCashAmountReturnsFailureWhenIncentiveTypeIsNotSupported()
    {
        // Arrange
        Rebate rebate = new Rebate()
        {
            Amount = 10,
            Incentive = new FixedCashAmount(),
        };
        Product product = new Product()
        {
            Price = 5,
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        };
        Mock<IRebateDataStore> rebateMock = new Mock<IRebateDataStore>();
        rebateMock.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        Mock<IProductDataStore> productMock = new Mock<IProductDataStore>();
        productMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);
        var result = service.Calculate(new CalculateRebateRequest());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }
}
