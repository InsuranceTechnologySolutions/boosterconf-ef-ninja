using System.ComponentModel.DataAnnotations;

namespace BoosterConf.Ef.Ninja.TaskA.Solved.Storage.Entities
{
    public class ClaimStatusEntity : IEntity 
    {
        public int Id { get; set; }
        public required Guid ExternalId { get; set; }
        [StringLength(50)]
        public required string Name { get; set; }
        [StringLength(200)]
        public required string Description { get; set; }
    }
}
