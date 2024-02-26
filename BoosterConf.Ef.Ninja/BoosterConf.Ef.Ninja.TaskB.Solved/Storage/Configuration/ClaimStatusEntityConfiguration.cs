using BoosterConf.Ef.Ninja.TaskB.Solved.Storage.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoosterConf.Ef.Ninja.TaskB.Solved.Storage.Configuration
{
    public static class ClaimStatusEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<ClaimStatusEntity> builder)
        {
            //Populate the table with the following lookup data:
            /*
                 | ID | Name      | Description |
               |----|-----------|-------------|
               | 1  | Submited | The claim has been submitted and is awaiting review. |
               | 2  | In Review | The claim is currently being reviewed by an insurance adjuster. |
               | 3  | Approved  | The claim has been approved for payment. |
               | 4  | Rejected  | The claim has been rejected and will not be paid. |
               | 5  | Paid      | The claim has been paid to the policyholder. |
             */
            builder.HasData(
                new ClaimStatusEntity { Id = 1, Name = "Submited", Description = "The claim has been submitted and is awaiting review.", ExternalId = new Guid("659a9701-1f76-4993-bcbd-4d703c4e91cf") },
                new ClaimStatusEntity { Id = 2, Name = "In Review", Description = "The claim is currently being reviewed by an insurance adjuster.", ExternalId = new Guid("5e5fb9bb-2f4a-4a6d-a8ff-3cd43321d7a3") },
                new ClaimStatusEntity { Id = 3, Name = "Approved", Description = "The claim has been approved for payment.", ExternalId = new Guid("5ee54db2-1d57-4b82-89cd-ece3957cf1b3") },
                new ClaimStatusEntity { Id = 4, Name = "Rejected", Description = "The claim has been rejected and will not be paid.", ExternalId = new Guid("9fad7c66-4554-4e26-858b-029f23964d61") },
                new ClaimStatusEntity { Id = 5, Name = "Paid", Description = "The claim has been paid to the policyholder.", ExternalId = new Guid("6dcd8442-3463-4ff5-afa9-66aa54191c28") });
        }   
    }
}
