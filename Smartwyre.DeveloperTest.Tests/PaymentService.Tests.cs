using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
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
        Rebate rebate = TestFixtures.BuildRebate(10, 0, new FixedCashAmount());
        Product product = TestFixtures.BuildProduct(5, SupportedIncentiveType.FixedCashAmount);
        Mock<IRebateDataStore> rebateMock = SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = SetupProductMock(product);

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
        Rebate rebate = TestFixtures.BuildRebate(10, 0, new FixedCashAmount());
        Product product = TestFixtures.BuildProduct(5, SupportedIncentiveType.AmountPerUom);
        Mock<IRebateDataStore> rebateMock = SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = SetupProductMock(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);
        var result = service.Calculate(new CalculateRebateRequest());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    private Mock<IRebateDataStore> SetupRebateMock(Rebate rebate)
    {
        var mock = new Mock<IRebateDataStore>();
        mock.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        return mock;
    }
    private Mock<IProductDataStore> SetupProductMock(Product product)
    {
        var mock = new Mock<IProductDataStore>();
        mock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);
        return mock;
    }
}
