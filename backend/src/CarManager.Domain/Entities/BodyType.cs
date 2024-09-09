using CarManager.Domain.ValueObjects;

namespace CarManager.Domain.Entities;

public class BodyType
{
    public EntityId Id { get; set; }
    public required string Name { get; set; }
}