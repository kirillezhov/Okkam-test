using CarManager.Domain.ValueObjects;

namespace CarManager.Domain.Entities;

public class Brand
{
    public EntityId Id { get; set; }
    public required string Name { get; init; }
}