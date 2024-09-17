using CarManager.Domain.DomainEvents;

namespace CarManager.Domain.Entities;

public partial class Car
{
    private readonly List<DomainEvent> _appliedDomainEvents = new();

    private bool IsAlreadyApplied(DomainEvent domainEvent)
    {
        return _appliedDomainEvents.Any(e => e.EventId == domainEvent.EventId);
    }

    public void Apply(DomainEvent domainEvent)
    {
        if (domainEvent is CarCreated)
        {
            this.Id = domainEvent.DomainId;
        }
        
        if (this.Id != domainEvent.DomainId)
        {
            string eventTypeName = domainEvent.GetType().Name;
            
            throw new InvalidOperationException($"Bad DomainEvent applying. Probably you forgot setup DomainId for Event: {eventTypeName} ");
        }
        
        if (IsAlreadyApplied(domainEvent))
            return;

        _appliedDomainEvents.Add(domainEvent);

        Apply((dynamic)domainEvent);
    }
}