namespace BoosterConf.Ef.Ninja.TaskA.Models;

public class Claim
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public required DateTimeOffset Date { get; set; }
    public required ClaimStatus Status { get; set; }        
    public required decimal Amount { get; set; }
}