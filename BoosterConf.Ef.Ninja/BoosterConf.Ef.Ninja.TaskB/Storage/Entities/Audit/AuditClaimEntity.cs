using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoosterConf.Ef.Ninja.TaskB.Storage.Entities.Audit
{
    public class AuditClaimEntity : IEntity
    {
        public int Id { get; init; }

        [ForeignKey("ClaimId")]
        public required ClaimEntity Claim { get; set; }

        public DateTimeOffset Changed { get; set; }

        [StringLength(200)]
        public required string WhatHappenedHere { get; set; } 
    }
}
