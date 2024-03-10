using System;
using System.Collections.Generic;

namespace BoosterConf.Ef.Ninja.DbFirstDatabase;

public partial class ClaimStatus
{
    public int Id { get; set; }

    public Guid ExternalId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
}
