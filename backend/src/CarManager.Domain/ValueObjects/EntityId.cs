namespace CarManager.Domain.ValueObjects;

public record EntityId : SingleValueObject<Guid>
{
    private static void Validate(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException($"Id is required and should be non-empty GUID. Passed value: {value}.", nameof(value));
        }
    }

    private static Guid Parse(string value)
    {
        if (!Guid.TryParse(value, out Guid id))
        {
            throw new ArgumentException($"Id is should be a GUID. Passed value: {value}.", nameof(value));
        }

        return id;
    }

    public static EntityId CreateNew()
    {
        return new EntityId(Guid.NewGuid());
    }

    public static EntityId Create(string value)
    {
        return new EntityId(value);
    }

    public static EntityId Create(Guid value)
    {
        return new EntityId(value);
    }

    public EntityId(Guid value)
    {
        Validate(value);
        Value = value;
    }

    public EntityId(string value)
    {
        Guid id = Parse(value);
        Validate(id);
        Value = id;
    }
}