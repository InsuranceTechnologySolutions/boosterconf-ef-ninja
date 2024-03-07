using BoosterConf.Ef.Ninja.Database.Entities;
using Riok.Mapperly.Abstractions;

namespace BoosterConf.Ef.Ninja.Api;

// If you are interested, this will transform our entities into a representation
// that doesn't leak the details of our database architecture.
// We will do so before returning them over HTTP.
[Mapper]
public partial class DtoMapper
{
    [MapProperty(nameof(ClaimEntity.ExternalId), nameof(Claim.Id))]
    public partial Claim ToDto(ClaimEntity entity);
    
    [MapProperty(nameof(ClaimStatusEntity.ExternalId), nameof(ClaimStatus.Id))]
    public partial ClaimStatus ToDto(ClaimStatusEntity entity);
    
    [MapProperty(nameof(CoverEntity.ExternalId), nameof(Cover.Id))]
    [MapProperty(nameof(CoverEntity.CoverType), nameof(Cover.Type))]
    public partial Cover ToDto(CoverEntity entity);
    
    [MapProperty(nameof(CoverTypeEntity.ExternalId), nameof(CoverType.Id))]
    public partial CoverType ToDto(CoverTypeEntity entity);
    
    [MapProperty(nameof(CustomerEntity.ExternalId), nameof(Customer.Id))]
    public partial Customer ToDto(CustomerEntity entity);
    
    [MapProperty(nameof(CustomerAddressEntity.ExternalId), nameof(CustomerAddress.Id))]
    public partial CustomerAddress ToDto(CustomerAddressEntity entity);
}