using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoosterConf.Ef.Ninja.TaskB.Storage.Entities.Audit
{
    public class AuditCoverEntity : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("CoverId")]
        public required CoverEntity Cover { get; set; }

        public DateTimeOffset Changed { get; set; }

        [StringLength(200)]
        public required string WhatHappenedHere { get; set; }    
    }
}
