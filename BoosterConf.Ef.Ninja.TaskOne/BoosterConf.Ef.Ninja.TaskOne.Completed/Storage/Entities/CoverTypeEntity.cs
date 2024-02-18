namespace BoosterConf.Ef.Ninja.TaskOne.Completed.Storage.Entities
{
    public class CoverTypeEntity : IEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }    
        public string Name { get; set; }
        public string Description { get; set; }
    }    
}