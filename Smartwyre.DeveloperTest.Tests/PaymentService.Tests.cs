using Smartwyre.DeveloperTest.Services;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void Test1()
    {
        RebateService service = new RebateService();
        var result = service.Calculate(new Types.CalculateRebateRequest());
        Assert.NotNull(result);
        Assert.False(result.Success);
    }
}
