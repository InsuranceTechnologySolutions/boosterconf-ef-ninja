using BoosterConf.Ef.Ninja.TaskB.Solved.Storage.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoosterConf.Ef.Ninja.TaskB.Solved.Storage.Configuration.Audit
{
    public static class AuditCoverEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AuditCoverEntity> builder)
        { 
            //This table should be using the audit schema
            builder.ToTable("Cover", "audit");
        }
    }
}
