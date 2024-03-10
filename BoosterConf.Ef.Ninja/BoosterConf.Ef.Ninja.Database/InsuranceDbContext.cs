using BoosterConf.Ef.Ninja.Database.Entities;
using BoosterConf.Ef.Ninja.Database.SeedData;
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
        ConfigureSchemas(modelBuilder);
        ConfigureEntities(modelBuilder);
        SeedData(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // We extracted the collection into a static class to avoid noise here.
        modelBuilder
            .Entity<ClaimStatusEntity>()
            .HasData(ClaimStatusSeedData.SeedData);
    }

    private void ConfigureSchemas(ModelBuilder modelBuilder)
    {
        // All bits of the model will be placed into the "insurance" schema by default now.
        // Check the CustomerEntity and CustomerAddressEntity types.
        // They have also been moved to a new schema.
        modelBuilder.HasDefaultSchema("insurance");
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
