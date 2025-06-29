using D2App.WebApi.Common;
using D2App.WebApi.Common.ConfigurationBindings;

namespace D2App.WebApi.Configurations;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddSettingsConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        // services.Configure<GlobalApiConfiguration>(configuration.GetSection(GlobalApiConfiguration.SectionName));
        // services.AddSingleton(x => x.GetRequiredService<IOptions<GlobalApiConfiguration>>().Value);
        services.AddBinding<GlobalApiConfiguration>(configuration, GlobalApiConfiguration.SectionName);
        return services;
    }
}