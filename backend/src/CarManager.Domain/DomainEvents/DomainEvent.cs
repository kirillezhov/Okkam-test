namespace CarManager.Domain.DomainEvents;

public record DomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();

    public Guid DomainId { get; init; }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}