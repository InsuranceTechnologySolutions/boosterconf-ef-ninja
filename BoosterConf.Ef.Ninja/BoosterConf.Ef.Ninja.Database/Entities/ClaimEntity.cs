using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BoosterConf.Ef.Ninja.Database.Entities;

public class ClaimEntity
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
