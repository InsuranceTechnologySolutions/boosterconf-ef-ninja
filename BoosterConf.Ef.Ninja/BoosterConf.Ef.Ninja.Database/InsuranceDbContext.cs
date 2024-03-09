using BoosterConf.Ef.Ninja.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoosterConf.Ef.Ninja.Database;

public class InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : DbContext(options)
{
    public DbSet<ClaimStatusEntity> ClaimStatuses => Set<ClaimStatusEntity>();
    public DbSet<CoverTypeEntity> CoverTypes => Set<CoverTypeEntity>();
    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
    public DbSet<CustomerAddressEntity> CustomerAddresses => Set<CustomerAddressEntity>();
    public DbSet<CoverEntity> Covers => Set<CoverEntity>();
    public DbSet<ClaimEntity> Claims => Set<ClaimEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureEntities(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureEntities(ModelBuilder modelBuilder)
    {
        // One way of defining entity configuration. An alternative to using attributes.
        modelBuilder
            .Entity<CoverEntity>()
            .Property(cover => cover.Premium)
            .HasPrecision(14, 2);
        
        modelBuilder
            .Entity<CustomerEntity>()
            .HasIndex(c => new { c.FirstName, c.LastName });
    }
}
