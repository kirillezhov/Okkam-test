using CarManager.Domain.Entities;

namespace CarManager.DataAccess.Repositories.Read;

public interface IBodyTypeReadRepository
{
    Task<IEnumerable<BodyType>> GetAllAsync(CancellationToken cancellationToken);
    Task<BodyType> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<BodyType?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
}