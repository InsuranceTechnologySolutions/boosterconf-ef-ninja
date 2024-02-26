using System.ComponentModel.DataAnnotations;

namespace BoosterConf.Ef.Ninja.TaskC.Storage.Entities
{
    public class CustomerAddressEntity : IEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        [StringLength(100)]
        public required string Street { get; set; }
        [StringLength(100)]
        public required string City { get; set; }
        [StringLength(100)]
        public required string PostalCode { get; set; }
        [StringLength(100)]
        public required string Country { get; set; }
    }
}
