using Microsoft.EntityFrameworkCore;

namespace BoosterConf.Ef.Ninja.TaskOne.Storage
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options){ }

        public DbSet<Entities.ClaimStatusEntity> ClaimStatuses => Set<Entities.ClaimStatusEntity>();

        public DbSet<Entities.CoverTypeEntity> CoverTypes => Set<Entities.CoverTypeEntity>();

        public DbSet<Entities.CustomerEntity> Customers => Set<Entities.CustomerEntity>();

        public DbSet<Entities.CustomerAddressEntity> CustomerAddresses => Set<Entities.CustomerAddressEntity>();

        public DbSet<Entities.CoverEntity> Covers => Set<Entities.CoverEntity>();

        public DbSet<Entities.ClaimEntity> Claims => Set<Entities.ClaimEntity>();
    }
}