﻿namespace BoosterConf.Ef.Ninja.TaskB.Models
{
    public class ClaimStatus
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}