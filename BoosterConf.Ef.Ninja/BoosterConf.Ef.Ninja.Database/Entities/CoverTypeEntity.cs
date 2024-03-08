namespace BoosterConf.Ef.Ninja.Database.Entities;

public class CoverTypeEntity
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }    
    public required string Name { get; set; }
    public required string Description { get; set; }
}