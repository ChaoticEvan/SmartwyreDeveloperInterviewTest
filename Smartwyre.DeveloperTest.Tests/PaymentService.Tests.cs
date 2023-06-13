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
    public void FixedCashAmountReturnsSuccessWhenAllConditionsAreMet()
    {
        // Arrange
        Rebate rebate = TestFixtures.BuildRebate(10, 0, new FixedCashAmount());
        Product product = TestFixtures.BuildProduct(5, SupportedIncentiveType.FixedCashAmount);
        Mock<IRebateDataStore> rebateMock = TestFixtures.SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = TestFixtures.SetupProductMock(product);

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
        Mock<IRebateDataStore> rebateMock = TestFixtures.SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = TestFixtures.SetupProductMock(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);
        var result = service.Calculate(new CalculateRebateRequest());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact]
    public void FixedCashAmountReturnsFailureWhenAmountIsZero()
    {
        // Arrange
        Rebate rebate = TestFixtures.BuildRebate(0, 0, new FixedCashAmount());
        Product product = TestFixtures.BuildProduct(5, SupportedIncentiveType.AmountPerUom);
        Mock<IRebateDataStore> rebateMock = TestFixtures.SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = TestFixtures.SetupProductMock(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);
        var result = service.Calculate(new CalculateRebateRequest());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact]
    public void FixedCashAmountReturnsFailureWhenRebateIsNull()
    {
        // Arrange
        Rebate rebate = null;
        Product product = TestFixtures.BuildProduct(5, SupportedIncentiveType.AmountPerUom);
        Mock<IRebateDataStore> rebateMock = TestFixtures.SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = TestFixtures.SetupProductMock(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);
        var result = service.Calculate(new CalculateRebateRequest());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact]
    public void FixedRateAmountReturnsSuccessWhenAllConditionsAreMet()
    {
        // Arrange
        Rebate rebate = TestFixtures.BuildRebate(10, 5, new FixedRateAmount());
        Product product = TestFixtures.BuildProduct(5, SupportedIncentiveType.FixedRateRebate);
        Mock<IRebateDataStore> rebateMock = TestFixtures.SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = TestFixtures.SetupProductMock(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);;
        var result = service.Calculate(new CalculateRebateRequest()
        {
            Volume = 5
        });

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
    }

    [Fact]
    public void FixedRateAmountReturnsFailureWhenIncentiveTypeIsNotSupported()
    {
        // Arrange
        Rebate rebate = TestFixtures.BuildRebate(10, 0, new FixedRateAmount());
        Product product = TestFixtures.BuildProduct(5, SupportedIncentiveType.AmountPerUom);
        Mock<IRebateDataStore> rebateMock = TestFixtures.SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = TestFixtures.SetupProductMock(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);
        var result = service.Calculate(new CalculateRebateRequest());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact]
    public void FixedRateAmountReturnsFailureWhenAmountIsZero()
    {
        // Arrange
        Rebate rebate = TestFixtures.BuildRebate(0, 0, new FixedRateAmount());
        Product product = TestFixtures.BuildProduct(5, SupportedIncentiveType.AmountPerUom);
        Mock<IRebateDataStore> rebateMock = TestFixtures.SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = TestFixtures.SetupProductMock(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);
        var result = service.Calculate(new CalculateRebateRequest());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact]
    public void FixedRateAmountReturnsFailureWhenRebateIsNull()
    {
        // Arrange
        Rebate rebate = null;
        Product product = TestFixtures.BuildProduct(5, SupportedIncentiveType.AmountPerUom);
        Mock<IRebateDataStore> rebateMock = TestFixtures.SetupRebateMock(rebate);
        Mock<IProductDataStore> productMock = TestFixtures.SetupProductMock(product);

        // Act
        RebateService service = new RebateService(rebateMock.Object, productMock.Object);
        var result = service.Calculate(new CalculateRebateRequest());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

}
