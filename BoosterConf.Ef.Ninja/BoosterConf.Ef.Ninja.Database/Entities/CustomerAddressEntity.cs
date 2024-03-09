using System.ComponentModel.DataAnnotations;

namespace BoosterConf.Ef.Ninja.Database.Entities;

public class CustomerAddressEntity
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }

    [MaxLength(length: 128)]
    public required string Street { get; set; }

    [MaxLength(length: 128)]
    public required string City { get; set; }

    [MaxLength(length: 128)]
    public required string PostalCode { get; set; }

    [MaxLength(length: 128)]
    public required string Country { get; set; }
}
