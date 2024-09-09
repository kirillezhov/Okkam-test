using CarManager.Domain.Entities;

namespace CarManager.DataAccess.Repositories.Read;

public interface IBrandReadRepository
{
    Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken);
    Task<Brand> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Brand?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
}