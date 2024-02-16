﻿using BoosterConf.Ef.Ninja.TaskOne.Services;

namespace BoosterConf.Ef.Ninja.TaskOne.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ICoverService, CoverService>();
        }
    }
}