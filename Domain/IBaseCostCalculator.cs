using Domain.Models;

namespace Domain;

interface IBaseCostCalculator
{
    decimal CalculateBaseCost(WeightInKg Weight);
}
