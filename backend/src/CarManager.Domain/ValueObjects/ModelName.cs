namespace CarManager.Domain.ValueObjects;

public record ModelName : SingleValueObject<string>
{
    public ModelName(string value)
    {
        Validate(value);
        Value = value;
    }

    protected static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Model name cannot be null or empty.");
        }
        
        if (value.Length > 1000)
        {
            throw new ArgumentException("Model name cannot exceed 1000 characters.");
        }
    }
}