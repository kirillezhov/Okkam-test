using CarManager.Domain.Models;
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
}