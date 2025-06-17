namespace Domain;

public record WeightInKg(decimal value)
{
    public static implicit operator WeightInKg(decimal value) => new(value);
    public static implicit operator decimal(WeightInKg weight) => weight.value;
};
