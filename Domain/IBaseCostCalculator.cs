using Domain.Models;

namespace Domain;

interface IBaseCostCalculator: IContextSpecific
{
    decimal CalculateBaseCost(WeightInKg Weight);
}
internal class SwedishBaseCostCalculator : IBaseCostCalculator, IContextSpecific
{
    public bool AppliesToContext(Context context)
    {
        return context.Warehouse.Country == Country.SE;
    }

    public decimal CalculateBaseCost(WeightInKg Weight)
    {
        return Weight * 100; // SEK per kg
    }
}

internal class UKBaseCostCalculator : IBaseCostCalculator
{
    public bool AppliesToContext(Context context)
    {
        return context.Warehouse.Country == Country.UK;
    }

    public decimal CalculateBaseCost(WeightInKg Weight)
    {
        return Weight * 1200; // SEK per kg, letsay UK is more expensive
    }
}