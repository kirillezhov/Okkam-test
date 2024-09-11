using CarManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManager.DataAccess.Repositories.Read;

public class CarReadRepository : ICarReadRepository
{
    private DbSet<Car> _dbSet;

    private readonly ApplicationDbContext _context;
    
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

    public async Task<Car> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await FindByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            throw new KeyNotFoundException($"Car not found. Requested ID: {id}");
        }
        
        return entity;
    }

    public async Task<Car?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Query
            .Include(c => c.Brand)
            .Include(c => c.BodyType)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}