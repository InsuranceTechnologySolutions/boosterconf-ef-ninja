using BoosterConf.Ef.Ninja.TaskA.Solved.Storage.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoosterConf.Ef.Ninja.TaskA.Solved.Storage.Configuration
{
    public static class CustomerEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<CustomerEntity> builder)
        { 
            //Create composite index on firstname and lastname columns
            builder.HasIndex(e => new { e.FirstName, e.LastName }).IsUnique();
        }
    }
}