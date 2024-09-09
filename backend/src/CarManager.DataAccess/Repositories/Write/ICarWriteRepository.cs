using CarManager.Domain.Entities;

namespace CarManager.DataAccess.Repositories.Write;

public interface ICarWriteRepository
{
    void Add(Car car);
}