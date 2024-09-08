using System.Linq.Expressions;
using CarManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarManager.DataAccess.Repositories;

public class CarReadRepository : ICarReadRepository
{
    internal DbSet<Car> _dbSet;
    
    protected readonly ApplicationDbContext _context;
    
    protected virtual IQueryable<Car> Query => _dbSet.AsNoTracking();

    public CarReadRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<Car>();
    }

    public async Task<IEnumerable<Car>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Query
            .Include(c => c.Brand)
            .Include(c => c.BodyType)
            .ToListAsync(cancellationToken);
    }
}