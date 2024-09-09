using CarManager.DataAccess;
using CarManager.DataAccess.Repositories.Write;
using CarManager.Domain.DomainEvents;
using CarManager.Domain.Entities;

namespace CarManager.Application.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly ICarWriteRepository _projectRepository;

    public UnitOfWork(ApplicationDbContext context, ICarWriteRepository projectRepository)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _projectRepository = projectRepository;
    }

    public Task SaveChangesAsync(Car car, DomainEvent @event, CancellationToken cancellationToken = default)
    {
        return SaveChangesAsync(car, [@event], cancellationToken);
    }

    public async Task SaveChangesAsync(Car car, IEnumerable<DomainEvent> events, CancellationToken cancellationToken = default)
    {
        foreach (var @event in events)
        {
            car.Apply(@event);
            UpdateReadModelEventHandler(@event)();
        }

        await _context.SaveChangesAsync(cancellationToken);
        return;

        Action UpdateReadModelEventHandler(DomainEvent @event) => @event switch
        {
            CarCreated => () => _projectRepository.Add(car)
        };
    }
}