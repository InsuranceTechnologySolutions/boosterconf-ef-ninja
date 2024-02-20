namespace BoosterConf.Ef.Ninja.TaskC.Models
{
    public class AutoClaim : Claim
    {    
        public string VehicleIdentificationNumber { get; set; } = null!;    
        public string AccidentReport { get; set; } = null!;        
        public decimal RepairEstimate { get; set; }
    }
}
