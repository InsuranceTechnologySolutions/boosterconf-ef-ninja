using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BoosterConf.Ef.Ninja.TaskC.Storage.Entities
{
    public class AutoClaimEntity : ClaimEntity
    {
        [StringLength(50)]
        public string VehicleIdentificationNumber { get; set; } = null!;
        [StringLength(200)]
        public string AccidentReport { get; set; } = null!;
        [Precision(14, 2)]
        public decimal RepairEstimate { get; set; }
    }
}
