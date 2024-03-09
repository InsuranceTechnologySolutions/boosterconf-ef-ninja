﻿namespace BoosterConf.Ef.Ninja.Database.Entities;

public class CoverEntity
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }

    public required CoverTypeEntity CoverType { get; set; }

    public required DateTimeOffset StartDate { get; set; }

    public required DateTimeOffset EndDate { get; set; }

    // We configured this property in the InsuranceDbContext.cs
    // We mix and match in this example, but you should usually
    // stick with just one method.
    public required decimal Premium { get; set; }

    public required CustomerEntity Customer { get; set; }

    public ICollection<ClaimEntity>? Claims { get; set; }
}
