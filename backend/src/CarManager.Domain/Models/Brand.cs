namespace CarManager.Domain.Models;

public class Brand
{
    public Guid Id { get; set; }
    public required string Name { get; init; }
}