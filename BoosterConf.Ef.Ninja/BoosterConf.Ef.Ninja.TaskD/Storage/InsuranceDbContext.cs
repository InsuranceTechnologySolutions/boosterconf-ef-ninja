using Microsoft.EntityFrameworkCore;

namespace BoosterConf.Ef.Ninja.TaskD.Storage
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options){ }

        //public DbSet<Entities.ClaimStatusEntity> ClaimStatuses => Set<Entities.ClaimStatusEntity>();

        //public DbSet<Entities.CoverTypeEntity> CoverTypes => Set<Entities.CoverTypeEntity>();

        //public DbSet<Entities.CustomerEntity> Customers => Set<Entities.CustomerEntity>();

        //public DbSet<Entities.CustomerAddressEntity> CustomerAddresses => Set<Entities.CustomerAddressEntity>();

        //public DbSet<Entities.CoverEntity> Covers => Set<Entities.CoverEntity>();

        //public DbSet<Entities.ClaimEntity> Claims => Set<Entities.ClaimEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ConfigureEntities(modelBuilder: modelBuilder);
            base.OnModelCreating(modelBuilder: modelBuilder);    
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            //ClaimEntityConfiguration.Configure(builder: modelBuilder.Entity<Entities.ClaimEntity>());
            //ClaimStatusEntityConfiguration.Configure(builder: modelBuilder.Entity<Entities.ClaimStatusEntity>());
            //CoverEntityConfiguration.Configure(builder: modelBuilder.Entity<Entities.CoverEntity>());
            //CoverTypeEntityConfiguration.Configure(builder: modelBuilder.Entity<Entities.CoverTypeEntity>());
            //CustomerAddressEntityConfiguration.Configure(builder: modelBuilder.Entity<Entities.CustomerAddressEntity>());
            //CustomerEntityConfiguration.Configure(builder: modelBuilder.Entity<Entities.CustomerEntity>());           
        }
    }
}