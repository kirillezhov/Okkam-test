using System.ComponentModel.DataAnnotations;

namespace CarManager.Domain.Models;

public class Car
{
    public Guid Id { get; init; }
    public required Brand Brand { get; init; }
    public required string ModelName { get; init; }
    public required byte[] Image { get; init; }
    public required BodyType BodyType { get; init; }
    public required DateTime CreatedAt { get; init; }
    [Range(1, 12)]
    public required int SeatsCount { get; init; }
    public string? Url { get; init; }
}