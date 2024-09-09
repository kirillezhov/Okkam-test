using CarManager.Domain.ValueObjects;

namespace CarManager.Domain.DomainEvents;

public record CarCreated : DomainEvent
{
    public required ModelName ModelName { get; init; }
    public required SeatsCount SeatsCount { get; init; }
    public required CarImage Image { get; init; }
    public DealerUrl? DealerUrl { get; init; }
}