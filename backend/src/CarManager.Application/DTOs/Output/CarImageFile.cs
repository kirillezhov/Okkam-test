namespace CarManager.Application.DTOs.Output;

public class CarImageFile
{
    public required string FileName { get; init; }
    public required byte[] FileData { get; init; }
}