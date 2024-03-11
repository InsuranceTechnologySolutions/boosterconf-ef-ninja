using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BoosterConf.Ef.Ninja.Database.Infrastructure;

public class DesignTimeInsuranceDbContextFactory : IDesignTimeDbContextFactory<InsuranceDbContext>
{
    private IConfiguration Configuration { get; } =
        new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets(typeof(InsuranceDbContext).Assembly)
            .Build();

    public InsuranceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<InsuranceDbContext>();
        builder.UseSqlServer(Configuration.GetConnectionString("InsuranceDb"));
        return new InsuranceDbContext(builder.Options);
    }
}
