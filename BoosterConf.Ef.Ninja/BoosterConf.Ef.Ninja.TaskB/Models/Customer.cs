namespace BoosterConf.Ef.Ninja.TaskB.Models
{
    public record Customer
    {
        public Guid Id { get; set; }

        public required CustomerAddress Address { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }
        
        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public ICollection<Cover>? Covers { get; set; }
    }
}
