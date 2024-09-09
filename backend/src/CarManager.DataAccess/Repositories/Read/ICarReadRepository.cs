using CarManager.Domain.Models;

namespace CarManager.DataAccess.Repositories.Read;

public interface ICarReadRepository
{
    Task<IEnumerable<Car>> GetAllAsync(CancellationToken cancellationToken);
}