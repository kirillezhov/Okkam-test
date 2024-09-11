using CarManager.Domain.ValueObjects;

namespace CarManager.Domain.Entities;

public partial class Car
{
    public Guid Id { get; set; }
    public required Brand Brand { get; init; }
    public ModelName ModelName { get; set; }
    public CarImage Image { get; set; }
    public required BodyType BodyType { get; init; }
    public DateTime CreatedAt { get; set; }
    public SeatsCount SeatsCount { get; set; }
    public DealerUrl? Url { get; set; }
}