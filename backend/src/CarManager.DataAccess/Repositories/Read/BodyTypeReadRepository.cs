using CarManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManager.DataAccess.Repositories.Read;

public class BodyTypeReadRepository : IBodyTypeReadRepository
{
    private DbSet<BodyType> _dbSet;

    private readonly ApplicationDbContext _context;
    
    protected virtual IQueryable<BodyType> Query => _dbSet.AsNoTracking();

    public BodyTypeReadRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<BodyType>();
    }
    
    public async Task<IEnumerable<BodyType>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Query.ToListAsync(cancellationToken);
    }

    public async Task<BodyType> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await FindByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            throw new KeyNotFoundException("BodyType not found. Requested ID: {id}");
        }
        
        return entity;
    }

    public async Task<BodyType?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }
}