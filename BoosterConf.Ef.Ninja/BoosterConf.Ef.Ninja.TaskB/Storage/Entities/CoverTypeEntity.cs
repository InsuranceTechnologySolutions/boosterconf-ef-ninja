using System.ComponentModel.DataAnnotations;

namespace BoosterConf.Ef.Ninja.TaskB.Storage.Entities
{
    public class CoverTypeEntity : IEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        [StringLength(50)]
        public required string Name { get; set; }
        [StringLength(200)]
        public required string Description { get; set; }
    }    
}