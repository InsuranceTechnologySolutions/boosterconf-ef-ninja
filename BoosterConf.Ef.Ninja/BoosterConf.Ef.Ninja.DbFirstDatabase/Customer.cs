using System;
using System.Collections.Generic;

namespace BoosterConf.Ef.Ninja.DbFirstDatabase;

public partial class Customer
{
    public int Id { get; set; }

    public Guid ExternalId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int AddressId { get; set; }

    public virtual CustomerAddress Address { get; set; } = null!;

    public virtual ICollection<Cover> Covers { get; set; } = new List<Cover>();
}
