using Domain.Models;

namespace Domain;

internal class CostCalculatorResolver
{
    private IBaseCostCalculator[] _baseCostCalculators = [];
    private ILastMileCostCalculator[] _lastMileCostCalculators = [];

    public CostCalculatorResolver(IBaseCostCalculator[] baseCostCalculators, ILastMileCostCalculator[] lastMileCostCalculators)
    {
        _baseCostCalculators = baseCostCalculators;
        _lastMileCostCalculators = lastMileCostCalculators;
    }

    internal IBaseCostCalculator[] BaseCostCalculatorsFor(Context context) =>
        [.. _baseCostCalculators.Where(c => c.AppliesToContext(context))];

    internal ILastMileCostCalculator[] LastMileCostCalculatorsFor(Context context) 
        => [.. _lastMileCostCalculators.Where(c => c.AppliesToContext(context))];
}