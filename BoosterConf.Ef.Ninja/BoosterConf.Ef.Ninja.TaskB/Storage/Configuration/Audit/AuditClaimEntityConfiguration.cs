using BoosterConf.Ef.Ninja.TaskB.Storage.Entities.Audit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoosterConf.Ef.Ninja.TaskB.Storage.Configuration.Audit
{
    public static class AuditClaimEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AuditClaimEntity> builder)
        { }
    }
}
