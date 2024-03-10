using BoosterConf.Ef.Ninja.Database.Entities;

namespace BoosterConf.Ef.Ninja.Database.SeedData;

// We make this internal so that outside assemblies don't accidentally
// start depending on this data.
internal static class ClaimStatusSeedData
{
    internal static ClaimStatusEntity[] SeedData =
    [
        new()
        {
            Id = 1,
            ExternalId = new("d578489e45e04ff89ef65b529ed5d95c"),
            Name = "Submitted",
            Description = "The claim has been submitted and is awaiting review."
        },
        new()
        {
            Id = 2,
            ExternalId = new("17fadf7651584ceea088281761949bdf"),
            Name = "Approved",
            Description = "The claim has been approved for payment."
        },
        new()
        {
            Id = 3,
            ExternalId = new("edd82f86179a4a4193a74b204d9d1100"),
            Name = "Paid",
            Description = "The claim has been paid to the policy holder."
        }
    ];
}
