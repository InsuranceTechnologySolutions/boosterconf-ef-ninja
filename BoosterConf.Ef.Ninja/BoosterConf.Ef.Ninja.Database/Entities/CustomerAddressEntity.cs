using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoosterConf.Ef.Ninja.Database.Entities;

[Table("CustomerAddresses", Schema = "pii")]
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
