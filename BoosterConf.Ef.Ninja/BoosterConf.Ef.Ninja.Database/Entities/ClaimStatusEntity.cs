namespace BoosterConf.Ef.Ninja.Database.Entities;

public class ClaimStatusEntity 
{
    public int Id { get; set; }
    public required Guid ExternalId { get; set; }    
    public required string Name { get; set; }
    public required string Description { get; set; }
}