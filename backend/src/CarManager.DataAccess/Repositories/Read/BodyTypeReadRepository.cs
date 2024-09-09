using CarManager.Domain.Models;
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
}