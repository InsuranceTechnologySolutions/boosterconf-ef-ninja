using System;
using System.Collections.Generic;

namespace BoosterConf.Ef.Ninja.DbFirstDatabase;

public partial class Cover
{
    public int Id { get; set; }

    public Guid ExternalId { get; set; }

    public int CoverTypeId { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    public decimal Premium { get; set; }

    public int CustomerId { get; set; }

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();

    public virtual CoverType CoverType { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
