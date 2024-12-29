using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace PromoCodeFactory.WebHost.Mapping.Installer;

public static class AutomapperInstaller
{
    public static IServiceCollection InstallAutomapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CustomerMappingProfile>();
            cfg.AddProfile<PreferenceMappingProfile>();
            cfg.AddProfile<PromoCodeMappingProfile>();
        });
        
        configuration.AssertConfigurationIsValid();
        
        return configuration;
    }
}