namespace CarManager.Application.DTOs.Input;

public class CreateCarCommandInput
{
    public Guid BrandId { get; init; }
    public Guid BodyTypeId { get; init; }
    public required string ModelName { get; init; }
    public required string ImageInBase64 { get; init; }
    public required int SeatsCount { get; init; }
    public string? Url { get; init; }
}