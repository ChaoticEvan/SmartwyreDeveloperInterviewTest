﻿namespace Smartwyre.DeveloperTest.Types;

public class RebateCalculation
{
    public int Id { get; set; }
    public string Identifier { get; set; }
    public string RebateIdentifier { get; set; }
    public IIncentiveType IncentiveType { get; set; }
    public decimal Amount { get; set; }
}
