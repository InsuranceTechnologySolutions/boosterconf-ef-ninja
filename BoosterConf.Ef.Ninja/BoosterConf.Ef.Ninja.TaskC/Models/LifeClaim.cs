namespace BoosterConf.Ef.Ninja.TaskC.Models
{
    public class LifeClaim : Claim
    {
        public string PolicyHolderName { get; set; } = null!;

        public string BeneficiaryName { get; set; } = null!;

        public string DeathCertificate { get; set; } = null!;
    }
}
