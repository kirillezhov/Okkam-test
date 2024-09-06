using CarManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarManager.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<BodyType> BodyTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .Property(c => c.Image)
            .HasColumnType("bytea");
        
        modelBuilder.Entity<Car>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Car>()
            .Property(c => c.ModelName)
            .HasMaxLength(1000);

        modelBuilder.Entity<Car>()
            .Property(c => c.Url)
            .HasMaxLength(1000);

        base.OnModelCreating(modelBuilder);
    }
}