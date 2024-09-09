namespace CarManager.Application.DTOs.Output;

public class CarOutput
{
    public Guid Id { get; init; }
    public required string ModelName { get; init; }
    public required string Image { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required int SeatsCount { get; init; }
    public string? Url { get; init; }
    public required BodyTypeOutput BodyType { get; init; }
    public required BrandOutput Brand { get; init; }
}