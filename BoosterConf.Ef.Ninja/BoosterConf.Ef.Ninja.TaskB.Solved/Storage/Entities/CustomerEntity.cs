using System.ComponentModel.DataAnnotations;

namespace BoosterConf.Ef.Ninja.TaskB.Solved.Storage.Entities
{
    public class CustomerEntity : IEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        [StringLength(100)]
        public required string FirstName { get; set; }
        [StringLength(100)]
        public required string LastName { get; set; }
        [StringLength(100)]
        public required string Email { get; set; }
        [StringLength(100)]
        public required string PhoneNumber { get; set; }         
        public CustomerAddressEntity Address { get; set; }
        public ICollection<CoverEntity>? Covers { get; set; }
    }
}
