using BoosterConf.Ef.Ninja.TaskB.Solved.Storage.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoosterConf.Ef.Ninja.TaskB.Solved.Storage.Configuration.Audit
{
    public static class AuditClaimEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AuditClaimEntity> builder)
        {
            //this table should be using the audit schema
            builder.ToTable("Claim", "audit");
        }
    }
}
