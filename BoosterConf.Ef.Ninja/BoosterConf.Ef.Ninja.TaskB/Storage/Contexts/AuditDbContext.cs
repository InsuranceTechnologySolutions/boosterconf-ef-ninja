using BoosterConf.Ef.Ninja.TaskB.Storage.Configuration.Audit;
using BoosterConf.Ef.Ninja.TaskB.Storage.Entities.Audit;
using Microsoft.EntityFrameworkCore;

namespace BoosterConf.Ef.Ninja.TaskB.Storage.Contexts
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options) { }

        public DbSet<AuditClaimEntity> AuditClaims { get; set; }

        public DbSet<AuditCoverEntity> AuditCover { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureEntities(modelBuilder);         
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {

            AuditClaimEntityConfiguration.Configure(modelBuilder.Entity<AuditClaimEntity>());
            AuditCoverEntityConfiguration.Configure(modelBuilder.Entity<AuditCoverEntity>());            
        }
    }
}
