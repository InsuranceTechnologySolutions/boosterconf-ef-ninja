using System;
using System.Collections.Generic;

namespace BoosterConf.Ef.Ninja.DbFirstDatabase;

public partial class CoverType
{
    public int Id { get; set; }

    public Guid ExternalId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Cover> Covers { get; set; } = new List<Cover>();
}
