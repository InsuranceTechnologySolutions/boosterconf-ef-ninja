using BoosterConf.Ef.Ninja.TaskOne.Models;

namespace BoosterConf.Ef.Ninja.TaskOne.Storage.Entities
{
    public class ClaimEntity : IEntity
    {
        public int Id { get; set; }
        public required Guid ExternalId { get; set; }
        public required string Description { get; set; }
        public required DateTimeOffset Date { get; set; }
        public required ClaimStatus Status { get; set; }
        public required decimal Amount { get; set; }
    }
}
