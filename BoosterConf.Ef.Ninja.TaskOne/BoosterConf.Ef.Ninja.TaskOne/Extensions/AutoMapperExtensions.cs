using AutoMapper;

namespace BoosterConf.Ef.Ninja.TaskOne.Extensions
{
    public static class AutoMapperExtensions
    {

        public static IMapperConfigurationExpression RegisterMappings(
            this IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Storage.Entities.CustomerAddressEntity, Models.CustomerAddress>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ReverseMap();

            configuration.CreateMap<Storage.Entities.CustomerEntity, Models.Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ReverseMap();

            configuration.CreateMap<Storage.Entities.ClaimStatusEntity, Models.ClaimStatus>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ReverseMap();

            configuration.CreateMap<Storage.Entities.CoverTypeEntity, Models.CoverType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ReverseMap();

            configuration.CreateMap<Storage.Entities.ClaimEntity, Models.Claim>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ReverseMap();

            configuration.CreateMap<Storage.Entities.CoverEntity, Models.Cover>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ReverseMap();

            return configuration;
        }
    }
}
