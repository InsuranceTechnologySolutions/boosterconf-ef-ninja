﻿namespace BoosterConf.Ef.Ninja.TaskOne.Completed.Storage.Entities
{
    public class CoverEntity : IEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }    
        public required CoverTypeEntity CoverType { get; set; }
        public required DateTimeOffset StartDate { get; set; }
        public required DateTimeOffset EndDate { get; set; }
        public required decimal Premium { get; set; }
        public required CustomerEntity Customer { get; set; }
        public ICollection<ClaimEntity>? Claims { get; set; }       
    }
}
