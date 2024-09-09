namespace CarManager.Domain.ValueObjects;

public record SeatsCount : SingleValueObject<int>
{
    public SeatsCount(int value)
    {
        Validate(value);
        Value = value;
    }

    protected static void Validate(int value)
    {
        if (value is < 1 or > 12)
        {
            throw new ArgumentException($"Number of seats should be between 1 and 22. Passed value: {value}.", nameof(value));
        }
    }
}