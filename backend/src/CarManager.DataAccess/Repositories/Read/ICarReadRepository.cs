using CarManager.Domain.Entities;

namespace CarManager.DataAccess.Repositories.Read;

public interface ICarReadRepository
{
    Task<IEnumerable<Car>> GetAllAsync(CancellationToken cancellationToken);
    Task<Car> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Car?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
}