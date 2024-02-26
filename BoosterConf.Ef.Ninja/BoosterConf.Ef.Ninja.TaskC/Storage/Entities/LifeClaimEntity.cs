using System.ComponentModel.DataAnnotations;

namespace BoosterConf.Ef.Ninja.TaskC.Storage.Entities
{
    public class LifeClaimEntity : ClaimEntity
    {
        [StringLength(100)]
        public string PolicyHolderName { get; set; } = null!;
        [StringLength(100)]
        public string BeneficiaryName { get; set; } = null!;
        [StringLength(100)]
        public string DeathCertificate { get; set; } = null!;
    }   
}
