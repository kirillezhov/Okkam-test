using CarManager.Domain.Entities;

namespace CarManager.DataAccess.Repositories.Read;

public interface ICarReadRepository
{
    Task<IEnumerable<Car>> GetAllAsync(CancellationToken cancellationToken);
}