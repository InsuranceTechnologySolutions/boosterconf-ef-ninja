using System;
using System.Collections.Generic;

namespace BoosterConf.Ef.Ninja.DbFirstDatabase;

public partial class Claim
{
    public int Id { get; set; }

    public Guid ExternalId { get; set; }

    public string Description { get; set; } = null!;

    public DateTimeOffset Date { get; set; }

    public int StatusId { get; set; }

    public decimal Amount { get; set; }

    public int CoverId { get; set; }

    public virtual Cover Cover { get; set; } = null!;

    public virtual ClaimStatus Status { get; set; } = null!;
}
