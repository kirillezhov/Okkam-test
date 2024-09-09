using CarManager.Domain.Models;

namespace CarManager.DataAccess.Repositories.Read;

public interface IBrandReadRepository
{
    Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken);
}