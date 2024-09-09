using CarManager.Domain.DomainEvents;
using CarManager.Domain.Entities;

namespace CarManager.Application.Services;

public interface IUnitOfWork
{
    Task SaveChangesAsync(Car car, DomainEvent @event, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(Car car, IEnumerable<DomainEvent> events, CancellationToken cancellationToken = default);
}