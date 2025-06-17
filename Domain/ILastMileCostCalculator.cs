using Domain.Models;

namespace Domain;

interface ILastMileCostCalculator: IContextSpecific
{
    decimal CalculateLastMileCost(WeightInKg Weight, Country country);
}

internal class DHLLastMileCost : ILastMileCostCalculator, IContextSpecific
{
    private Country[] supportedCountries = { Country.SE, Country.UK };

    public bool AppliesToContext(Context context)
    {
        return supportedCountries.Contains(context.destination);
    }

    public decimal CalculateLastMileCost(WeightInKg Weight, Country country)
    {
        return Weight * 20;
    }
}

internal class UPSLastMileCost : ILastMileCostCalculator, IContextSpecific
{
    private Country[] supportedCountries = { Country.SE, Country.UK };
    public bool AppliesToContext(Context context)
    {
        return supportedCountries.Contains(context.destination);
    }

    public decimal CalculateLastMileCost(WeightInKg Weight, Country country)
    {
        return country switch
        {
            Country.SE => Weight * 30,
            Country.UK => Weight * 40,
            _ => throw new NotSupportedException($"Country {country} is not supported for UPS last mile cost calculation.")
        };
    }
}