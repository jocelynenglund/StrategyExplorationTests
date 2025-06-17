using Domain;
using Domain.Models;

namespace StrategyExplorationTests;

public class AlgorithmTests
{
    [Fact]
    public void EstimateShippingCostFromBaseCostsAndLastMileCosts()
    {
        var warehouse = new Warehouse("123", Country.SE);
        var product = new Package(10);
        var destination = new Destination(Country.SE);

        var shippingCalculator = new ShippingCalculator(new CostCalculatorResolver([new IBaseCostCalculatorMock()],[ new ILastMileCostCalculatorMock()]));

        var shippingCost = shippingCalculator.EstimateShippingCost(warehouse, product, destination);

        Assert.Equal(30, shippingCost);
    }

    public class IBaseCostCalculatorMock : IBaseCostCalculator
    {
        public bool AppliesToContext(Context context) => true;
        public decimal CalculateBaseCost(WeightInKg Weight) => 10;
    }
    public class ILastMileCostCalculatorMock : ILastMileCostCalculator
    {
        public bool AppliesToContext(Context context) => true;

        public decimal CalculateLastMileCost(WeightInKg Weight, Country country) => 20;
    }
}