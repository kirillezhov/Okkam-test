namespace CarManager.Domain.Models;

public class Brand
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}