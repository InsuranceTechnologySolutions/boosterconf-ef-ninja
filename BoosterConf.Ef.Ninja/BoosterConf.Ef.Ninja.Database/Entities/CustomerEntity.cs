using System.ComponentModel.DataAnnotations;

namespace BoosterConf.Ef.Ninja.Database.Entities;

public class CustomerEntity
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }

    [MaxLength(length: 128)]
    public required string FirstName { get; set; }

    [MaxLength(length: 128)]
    public required string LastName { get; set; }

    [MaxLength(length: 128)]
    public required string Email { get; set; }

    [MaxLength(length: 32)]
    public required string PhoneNumber { get; set; }

    public CustomerAddressEntity? Address { get; set; }

    public ICollection<CoverEntity>? Covers { get; set; }
}
