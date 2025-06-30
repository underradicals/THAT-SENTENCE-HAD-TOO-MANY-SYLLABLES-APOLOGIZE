using D2App.WebApi.Common;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace D2App.WebApi.Configurations;

public static class CorsExtensions
{
    public static IServiceCollection AddDefaultD2AppCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var action = CorsOptionsAction(configuration);
        services.AddCors(action);
        return services;
    }

    private static Action<CorsOptions> CorsOptionsAction(IConfiguration configuration)
    {
        var action = DefaultCorsPolicyAction(configuration);
        return (options) =>
        {
            options.DefaultPolicyName = configuration[Consts.DEFAULT_CORS_SETTINGS_DEFAULT_CORS_POLICY_NAME]!;
            options.AddDefaultPolicy(action);
        };
    }

    private static Action<CorsPolicyBuilder> DefaultCorsPolicyAction(IConfiguration configuration)
    {
        var v = configuration[Consts.DEFAULT_CORS_SETTINGS_CLIENT_URL]!;
        return (builder) =>
        {
            builder.AllowAnyHeader();
            builder.WithMethods(methods: [Consts.GET, Consts.POST, Consts.DELETE, Consts.OPTIONS]);
            var v = configuration[Consts.DEFAULT_CORS_SETTINGS_CLIENT_URL]!;
            builder.WithOrigins(origins: v)
                .AllowCredentials();
        };
    }

    public static WebApplication UseD2AppCorsConfiguration(this WebApplication app, IConfiguration configuration)
    {
        app.UseCors(configuration[Consts.DEFAULT_CORS_SETTINGS_DEFAULT_CORS_POLICY_NAME]!);
        return app;
    }
}