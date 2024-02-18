namespace BoosterConf.Ef.Ninja.TaskOne.Completed.Storage.Entities
{
    public class CustomerAddressEntity : IEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}
