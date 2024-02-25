using AutoMapper;
using BoosterConf.Ef.Ninja.TaskD.Services;

namespace BoosterConf.Ef.Ninja.TaskD.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.RegisterMappings();
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());
        }

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ICoverService, CoverService>();
        }
    }
}
