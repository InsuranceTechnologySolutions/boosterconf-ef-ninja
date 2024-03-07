namespace BoosterConf.Ef.Ninja.Database.Entities;

public class ClaimEntity
{
    public int Id { get; set; }
    public required Guid ExternalId { get; set; }
    public required string Description { get; set; }
    public required DateTimeOffset Date { get; set; }
    public required ClaimStatusEntity Status { get; set; }
    public required decimal Amount { get; set; }
}