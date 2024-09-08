namespace CarManager.Application.DTOs;

public class CarDto
{
    public Guid Id { get; init; }
    public required string ModelName { get; init; }
    public required string Image { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required int SeatsCount { get; init; }
    public string? Url { get; init; }
    public required BodyTypeDto BodyType { get; init; }
    public required BrandDto Brand { get; init; }
}