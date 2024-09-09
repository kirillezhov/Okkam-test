using CarManager.Domain.Models;

namespace CarManager.DataAccess.Repositories.Read;

public interface IBodyTypeReadRepository
{
    Task<IEnumerable<BodyType>> GetAllAsync(CancellationToken cancellationToken);
}