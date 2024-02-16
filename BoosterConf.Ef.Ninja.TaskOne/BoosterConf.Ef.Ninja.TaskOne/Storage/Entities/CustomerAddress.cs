namespace BoosterConf.Ef.Ninja.TaskOne.Storage.Entities
{
    public class CustomerAddress : IEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}
