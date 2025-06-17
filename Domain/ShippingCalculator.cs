using Domain.Models;

namespace Domain;

internal class ShippingCalculator(CostCalculatorResolver resolver)
{

    internal decimal EstimateShippingCost(Warehouse warehouse, Package package, Destination destination)
    {

        var context = new Context(package.WeightInKg, warehouse, destination);
        var _baseCostCalculator = resolver.BaseCostCalculatorsFor(context).First();
        var _lastMileCostCalculator = resolver.LastMileCostCalculatorsFor(context).First();

        return _baseCostCalculator.CalculateBaseCost(package.WeightInKg) +
               _lastMileCostCalculator.CalculateLastMileCost(package.WeightInKg, destination.country);
    }
}
