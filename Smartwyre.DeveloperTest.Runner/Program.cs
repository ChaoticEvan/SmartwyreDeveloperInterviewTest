using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Tests;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Diagnostics;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{    
    static void Main(string[] args)
    {
        string incentiveType = args[0].ToLower().Trim();
        Rebate rebate = BuildRebate(incentiveType);
        Product product = BuildProduct(incentiveType);
        RebateService rebateService = new RebateService(TestFixtures.SetupRebateMock(rebate).Object, TestFixtures.SetupProductMock(product).Object);
        CalculateRebateRequest request = new CalculateRebateRequest()
        {
            Volume = 1
        };
        Console.WriteLine($"Success: {rebateService.Calculate(request).Success}");

    }

    private static Rebate BuildRebate(string incetiveType)
    {
        switch (incetiveType.ToLower().Trim())
        {
            case "fixed rate":
                return new Rebate()
                {
                    Amount = 10,
                    Percentage = 5,
                    Incentive = new FixedRateAmount()
                };
            case "fixed cash":
                return new Rebate()
                {
                    Amount = 10,
                    Percentage = 5,
                    Incentive = new FixedCashAmount()
                };
            case "amount uom":
            default:
                return new Rebate()
                {
                    Amount = 10,
                    Percentage = 5,
                    Incentive = new AmountPerUom()
                };
        }
    }

    private static Product BuildProduct(string incetiveType)
    {
        switch (incetiveType.ToLower().Trim())
        {
            case "fixed rate":
                return new Product()
                {
                    Price = 10,
                    SupportedIncentives = SupportedIncentiveType.FixedRateRebate
                };
            case "fixed cash":
                return new Product()
                {
                    Price = 10,
                    SupportedIncentives = SupportedIncentiveType.FixedCashAmount
                };
            case "amount uom":
            default:
                return new Product()
                {
                    Price = 10,
                    SupportedIncentives = SupportedIncentiveType.AmountPerUom
                };
        }
    }
}
