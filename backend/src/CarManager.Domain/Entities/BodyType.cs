using CarManager.Domain.ValueObjects;

namespace CarManager.Domain.Entities;

public class BodyType
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}