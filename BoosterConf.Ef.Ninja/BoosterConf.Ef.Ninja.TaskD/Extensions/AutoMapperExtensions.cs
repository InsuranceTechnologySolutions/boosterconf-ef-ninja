using AutoMapper;

namespace BoosterConf.Ef.Ninja.TaskD.Extensions
{
    public static class AutoMapperExtensions
    {

        public static IMapperConfigurationExpression RegisterMappings(
            this IMapperConfigurationExpression configuration)
        {

            return configuration;
        }
    }
}
