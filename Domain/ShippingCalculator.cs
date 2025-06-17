namespace Domain;

internal class ShippingCalculator(IBaseCostCalculator baseCostCalculatorMock, ILastMileCostCalculator lastMileCostCalculatorMock)
{
    internal object EstimateShippingCost(Warehouse warehouse, Package package)
    {
        throw new NotImplementedException();
    }
}
