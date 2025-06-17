using Domain.Models;

namespace Domain;

internal class ShippingCalculator(IBaseCostCalculator baseCostCalculator, ILastMileCostCalculator lastMileCostCalculator)
{
    internal decimal EstimateShippingCost(Warehouse warehouse, Package package, Destination destination)
    {
        return baseCostCalculator.CalculateBaseCost(package.WeightInKg) +
               lastMileCostCalculator.CalculateLastMileCost(package.WeightInKg, destination.country);
    }
}
