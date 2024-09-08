using System.Linq.Expressions;
using CarManager.Domain.Models;

namespace CarManager.DataAccess.Repositories;

public interface ICarReadRepository
{
    Task<IEnumerable<Car>> GetAllAsync(CancellationToken cancellationToken);
}