﻿using AutoMapper;
using BoosterConf.Ef.Ninja.TaskC.Services;

namespace BoosterConf.Ef.Ninja.TaskC.Extensions
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