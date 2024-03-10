using System;
using System.Collections.Generic;

namespace BoosterConf.Ef.Ninja.DbFirstDatabase;

public partial class CustomerAddress
{
    public int Id { get; set; }

    public Guid ExternalId { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
