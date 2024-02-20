using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BoosterConf.Ef.Ninja.TaskB.Storage.Contexts
{
    public class AuditDbContextFactory : IDesignTimeDbContextFactory<AuditDbContext>
    {
        public AuditDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AuditDbContext>();
            builder.UseSqlServer(
                               connectionString: "Server=(localdb)\\mssqllocaldb;Database=BoosterConfEfNinjaTaskOne-TaskB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AuditDbContext(builder.Options);
        }
    }
}
