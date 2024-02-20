﻿namespace BoosterConf.Ef.Ninja.TaskB.Storage.Entities
{
    public class CoverTypeEntity : IEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }    
        public required string Name { get; set; }
        public required string Description { get; set; }
    }    
}