using Domain.Models;

namespace Domain;

interface ILastMileCostCalculator
{
    decimal CalculateLastMileCost(WeightInKg Weight, Country country);
}
