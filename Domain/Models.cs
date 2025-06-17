namespace Domain.Models;

public record Warehouse(string Id, Country Country);
public record Destination(Country country)
{
    public static implicit operator Country(Destination destination) => destination.country;
    public static implicit operator Destination(Country country) => new(country);
}
public record Package(WeightInKg WeightInKg);

public record WeightInKg(decimal value)
{
    public static implicit operator WeightInKg(decimal value) => new(value);
    public static implicit operator decimal(WeightInKg weight) => weight.value;
};
public enum Country
{
    SE,
    UK
}

public record Context(WeightInKg weight, Warehouse Warehouse, Destination destination);
