using BoosterConf.Ef.Ninja.TaskC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoosterConf.Ef.Ninja.TaskC.Storage.Configuration
{
    public static class LifeClaimEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<LifeClaimEntity> builder)
        {
            //Table-per-type inheritance
            //builder.ToTable("LifeClaims");

            //Table-per-concrete-type inheritance
            //builder.ToTable("LifeClaims").UseTpcMappingStrategy();
        }
    }
}
