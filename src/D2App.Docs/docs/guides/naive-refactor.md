---
title: Naive Refactor
lang: en-US
aside: true
layout: doc
---

# Naive Refactor

---

We can start by breaking up the naive solution into functional components.

```js
public static class CorsExtensions
{
    public static IServiceCollection AddDefaultD2AppCorsConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var action = CorsOptionsAction(configuration);
        services.AddCors(action);
        return services;
    }

    public static Action<CorsOptions> CorsOptionsAction(IConfiguration configuration)
    {
        var action = DefaultCorsPolicyAction(configuration);
        return (options) =>
        {
            options.DefaultPolicyName =
                configuration[Consts.DEFAULT_CORS_SETTINGS_DEFAULT_CORS_POLICY_NAME]!;
            options.AddDefaultPolicy(action);
        };
    }

    public static Action<CorsPolicyBuilder> DefaultCorsPolicyAction(IConfiguration configuration)
    {
        var v = configuration[Consts.DEFAULT_CORS_SETTINGS_CLIENT_URL]!;
        return (builder) =>
        {
            builder.AllowAnyHeader();
            builder.WithMethods(
                methods: [Consts.GET, Consts.POST, Consts.DELETE, Consts.OPTIONS]
                );
            var v = configuration[Consts.DEFAULT_CORS_SETTINGS_CLIENT_URL]!;
            builder.WithOrigins(origins: v)
                .AllowCredentials();
        };
    }

    public static WebApplication UseD2AppCorsConfiguration(
        this WebApplication app,
        IConfiguration configuration)
    {
        app.UseCors(
            configuration[Consts.DEFAULT_CORS_SETTINGS_DEFAULT_CORS_POLICY_NAME]!
            );
        return app;
    }
}
```

Next we can use this inside the `Program.cs`.

```js
try
{

    var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;

    builder.Services.AddDefaultD2AppCorsConfiguration(configuration); // [!code focus]

    builder.Services.AddOpenApi();

    var app = builder.Build();

    app.UseD2AppCorsConfiguration(configuration);

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.MapGet("/", () => new { message = "Hello World!" });

    app.Run();
}
catch (Exception ex)
{
    // Log the exception
    Console.WriteLine(ex, "An unhandled exception occurred during bootstrapping the application.");
    throw;
}
finally
{
    Console.WriteLine("Application has shut down.");
}
```
