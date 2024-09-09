using CarManager.Domain.Entities;
using CarManager.Domain.ValueObjects;
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
            .Property(c => c.Id)
            .HasConversion(v => v.Value, v => new EntityId(v));

        modelBuilder.Entity<Car>()
            .Property(c => c.Image)
            .HasConversion(v => v.Value, v => new CarImage(v))
            .HasColumnType("bytea");

        modelBuilder.Entity<Car>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Car>()
            .Property(c => c.ModelName)
            .HasConversion(v => v.Value, v => new ModelName(v))
            .HasMaxLength(1000);

        modelBuilder.Entity<Car>()
            .Property(c => c.Url)
            .HasConversion(v => v!.Value, v => new DealerUrl(v))
            .HasMaxLength(1000);

        modelBuilder.Entity<Car>()
            .Property(c => c.SeatsCount)
            .HasConversion(v => v.Value, v => new SeatsCount(v));

        modelBuilder.Entity<Brand>()
            .HasIndex(b => b.Name)
            .IsUnique();

        modelBuilder.Entity<Brand>()
            .Property(b => b.Id)
            .HasConversion(v => v.Value, v => new EntityId(v));

        modelBuilder.Entity<BodyType>()
           .HasIndex(bt => bt.Name)
           .IsUnique();

        modelBuilder.Entity<BodyType>()
           .Property(bt => bt.Id)
           .HasConversion(v => v.Value, v => new EntityId(v));

        base.OnModelCreating(modelBuilder);
    }
}