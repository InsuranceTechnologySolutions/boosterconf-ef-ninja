using BoosterConf.Ef.Ninja.TaskC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoosterConf.Ef.Ninja.TaskC.Storage.Configuration
{
    public static class ClaimEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<ClaimEntity> builder)
        {
            ////Table-per-type inheritance
            //builder.ToTable("Claims");

            ////Table-per-concrete-type inheritance
            //builder.ToTable("Claims").UseTpcMappingStrategy();
        }   
    }
}
