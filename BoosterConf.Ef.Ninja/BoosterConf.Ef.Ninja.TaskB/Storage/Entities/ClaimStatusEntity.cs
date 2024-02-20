namespace BoosterConf.Ef.Ninja.TaskB.Storage.Entities
{
    public class ClaimStatusEntity : IEntity 
    {
        public int Id { get; set; }
        public required Guid ExternalId { get; set; }    
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
