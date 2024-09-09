using CarManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManager.DataAccess.Repositories.Read;

public class BrandReadRepository : IBrandReadRepository
{
    private DbSet<Brand> _dbSet;

    private readonly ApplicationDbContext _context;
    
    protected virtual IQueryable<Brand> Query => _dbSet.AsNoTracking();

    public BrandReadRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<Brand>();
    }
    
    public async Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Query.ToListAsync(cancellationToken);
    }

    public async Task<Brand> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await FindByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            throw new KeyNotFoundException($"Brand not found. Requested ID: {id}");
        }
        
        return entity;
    }

    public async Task<Brand?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }
}