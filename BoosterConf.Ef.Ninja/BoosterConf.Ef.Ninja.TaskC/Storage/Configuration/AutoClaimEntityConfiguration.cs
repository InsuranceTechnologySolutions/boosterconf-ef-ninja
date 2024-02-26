using BoosterConf.Ef.Ninja.TaskC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoosterConf.Ef.Ninja.TaskC.Storage.Configuration
{
    public static class AutoClaimEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AutoClaimEntity> builder)
        {
            ////Table-per-type inheritance
            //builder.ToTable("AutoClaims");

            ////Table-per-concrete-type inheritance
            //builder.ToTable("AutoClaims").UseTpcMappingStrategy();
        }
    }
}
