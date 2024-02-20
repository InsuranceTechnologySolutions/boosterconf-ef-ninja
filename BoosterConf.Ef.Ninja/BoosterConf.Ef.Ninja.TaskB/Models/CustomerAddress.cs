namespace BoosterConf.Ef.Ninja.TaskB.Models
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }
        
        public required string Street { get; set; } 

        public required string City { get; set; }

        public required string PostalCode { get; set; }

        public required string Country { get; set; }
    }
}
