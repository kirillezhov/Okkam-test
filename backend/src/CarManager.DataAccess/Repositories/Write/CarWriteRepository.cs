using CarManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManager.DataAccess.Repositories.Write;

public class CarWriteRepository : ICarWriteRepository
{
    private readonly DbSet<Car> _dbSet;
    private readonly ApplicationDbContext _context;

    protected virtual IQueryable<Car> Query => _dbSet.AsTracking();

    public CarWriteRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<Car>();
    }

    public void Add(Car car)
    {
        _dbSet.Add(car);
    }
}