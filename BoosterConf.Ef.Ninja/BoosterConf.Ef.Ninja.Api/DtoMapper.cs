using BoosterConf.Ef.Ninja.Database.Entities;
using Riok.Mapperly.Abstractions;

namespace BoosterConf.Ef.Ninja.Api;

// If you are interested, this will transform our entities into a representation
// that doesn't leak the details of our database architecture.
// We will do so before returning them over HTTP.
[Mapper]
public static partial class DtoMapper
{
    [MapProperty(nameof(ClaimEntity.ExternalId), nameof(Claim.Id))]
    public static partial Claim ToDto(this ClaimEntity entity);

    [MapProperty(nameof(ClaimStatusEntity.ExternalId), nameof(ClaimStatus.Id))]
    public static partial ClaimStatus ToDto(this ClaimStatusEntity entity);

    [MapProperty(nameof(CoverEntity.ExternalId), nameof(Cover.Id))]
    [MapProperty(nameof(CoverEntity.CoverType), nameof(Cover.Type))]
    public static partial Cover ToDto(this CoverEntity entity);

    [MapProperty(nameof(CoverTypeEntity.ExternalId), nameof(CoverType.Id))]
    public static partial CoverType ToDto(this CoverTypeEntity entity);

    [MapProperty(nameof(CustomerEntity.ExternalId), nameof(Customer.Id))]
    public static partial Customer ToDto(this CustomerEntity entity);

    [MapProperty(nameof(CustomerAddressEntity.ExternalId), nameof(CustomerAddress.Id))]
    public static partial CustomerAddress ToDto(this CustomerAddressEntity entity);
}
