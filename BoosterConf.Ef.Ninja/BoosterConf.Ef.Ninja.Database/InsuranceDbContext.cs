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
        SeedData(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ClaimStatusEntity>()
            .HasData([
                new()
                {
                    Id = 1, ExternalId = new("d578489e45e04ff89ef65b529ed5d95c"), 
                    Name = "Submitted",
                    Description = "The claim has been submitted and is awaiting review."
                },
                new()
                {
                    Id = 2, ExternalId = new("17fadf7651584ceea088281761949bdf"),
                    Name = "Approved",
                    Description = "The claim has been approved for payment."
                },
                new()
                {
                    Id = 3, ExternalId = new("edd82f86179a4a4193a74b204d9d1100"), 
                    Name = "Paid",
                    Description = "The claim has been paid to the policy holder."
                }
            ]);
    }

    private void ConfigureEntities(ModelBuilder modelBuilder)
    {
         // Put you additional configuration here. Try accessing the modelBuilder:
    }
}
