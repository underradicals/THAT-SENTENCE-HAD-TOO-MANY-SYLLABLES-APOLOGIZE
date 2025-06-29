using System.Reflection;
using Microsoft.Extensions.Options;

namespace D2App.WebApi.Common;

public static class UtilityService
{
    public static IServiceCollection AddBinding<TSetting>(this IServiceCollection services,
        IConfiguration configuration, string sectionName = null) where TSetting : class, new()
    {
        const BindingFlags flags = BindingFlags.Public | BindingFlags.Static;
        var ty = typeof(TSetting).GetField("SectionName", flags)?.GetValue(null) as string;
        sectionName ??= ty ?? typeof(TSetting).Name;
        services.Configure<TSetting>(configuration.GetSection(sectionName));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<TSetting>>().Value);

        return services;
    }
}