
namespace StrategyExplorationTests;
using Domain;
public class Tests
{
    [Fact]
    public void aoeu()
    {
        var warehouse = new Warehouse("123", Country.SE);
        var product = new Package(10);

        var shippingCalculator = new ShippingCalculator(new IBaseCostCalculatorMock(), new ILastMileCostCalculatorMock());

        var shippingCost = shippingCalculator.EstimateShippingCost(warehouse, product);

        Assert.Equal(30, shippingCost);
    }

    public class IBaseCostCalculatorMock : IBaseCostCalculator
    {
        public decimal CalculateBaseCost(WeightInKg Weight) => 10;
    }
    public class ILastMileCostCalculatorMock : ILastMileCostCalculator
    {
        public decimal CalculateLastMileCost(WeightInKg Weight, Country country) => 20;
    }

  
}