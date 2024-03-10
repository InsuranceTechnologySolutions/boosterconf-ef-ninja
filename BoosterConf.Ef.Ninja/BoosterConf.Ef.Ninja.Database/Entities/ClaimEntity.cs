using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BoosterConf.Ef.Ninja.Database.Entities;

public class AutoClaimEntity : ClaimEntity
{
    [MaxLength(length: 32)]
    public required string VehicleId { get; set; }

    [MaxLength(length: 512)]
    public required string AccidentReport { get; set; }

    [Precision(14, 2)]
    public required decimal RepairEstimate { get; set; }
}

public class LifeClaimEntity : ClaimEntity
{
    [MaxLength(length: 128)]
    public required string PolicyHolderName { get; set; }

    [MaxLength(length: 128)]
    public required string BeneficiaryName { get; set; }

    [MaxLength(length: 32)]
    public required string DeathCertificate { get; set; }
}

public class MiscClaimEntity : ClaimEntity
{
    [MaxLength(length: 1024)]
    public required string AdditionalDetails { get; set; }
}

public abstract class ClaimEntity
{
    public int Id { get; set; }
    public required Guid ExternalId { get; set; }

    [MaxLength(length: 512)]
    public required string Description { get; set; }

    public required DateTimeOffset Date { get; set; }

    public required ClaimStatusEntity Status { get; set; }

    // You can use attributes to define schema configuration.
    [Precision(14, 2)] public required decimal Amount { get; set; }

    public required CoverEntity Cover { get; set; }
}
