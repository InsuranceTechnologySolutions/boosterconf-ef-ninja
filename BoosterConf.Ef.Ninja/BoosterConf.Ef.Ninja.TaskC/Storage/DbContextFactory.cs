using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BoosterConf.Ef.Ninja.TaskC.Storage
{
    public class DbContextFactory : IDesignTimeDbContextFactory<InsuranceDbContext> 
    {
        public InsuranceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<InsuranceDbContext>(); 
            builder.UseSqlServer(
                connectionString: "Server=(localdb)\\mssqllocaldb;Database=BoosterConfEfNinjaTaskOne-TaskA;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new InsuranceDbContext(builder.Options);
        }
    }
}