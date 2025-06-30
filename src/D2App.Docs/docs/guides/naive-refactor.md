---
title: Naive Refactor
lang: en-US
aside: true
layout: doc
---

# Naive Refactor

---

## Refactor Setup

We can start by breaking up the naive solution into functional components. This refactor consists of two methods, `AddDefaultD2AppCorsConfiguration` and `UseD2AppCorsConfiguration` both being extension methods on the `IServiceCollection` excepting an `IConfiguration` objects. Setting up CORS requires calling the AddCors extension method on the `IServiceCollection` which takes a delegate of type `CorsOptions`.

### File: AddDefaultD2AppCorsConfiguration

This method is called above the App Builder during Service registration.

```cs
 public static IServiceCollection AddDefaultD2AppCorsConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var action = CorsOptionsAction(configuration);
        services.AddCors(action);
        return services;
    }
```

### File: UseD2AppCorsConfiguration

This method is called below the App Builder during Middleware Registration. Just as with the wrapped extension method `UseCors`, `UseD2AppCorsConfiguration` must be placed between `UseRouting` and `UseAuthorization`. If the application implements Response Caching, then `UseCors` must also come before `UseResponseCaching`. If the application serves static files, (e.g., React, Vue, or Angular) you should also place `UseCors` before `UseStaticFiles`. This will ensure that CORS headers are applied correctly to static file responses. Remember Middleware components are executed in the order they are added to the pipeline. The order is critical for processing requests correctly.

```cs
public static WebApplication UseD2AppCorsConfiguration(
        this WebApplication app,
        IConfiguration configuration)
    {
        app.UseCors(
            configuration[Consts.DEFAULT_CORS_SETTINGS_DEFAULT_CORS_POLICY_NAME]!
            );
        return app;
    }
```

### Adding a Policy

If you want to add a Policy to the CORS middleware, you will do so in the `CorsOptionsAction` method. Do **NOT** add the configuration directly. Instead, follow this **SOP**:

1. Create a class with an appropriate name `XYZCorsPolicyExtensions`, (e.g., StaticFilesCorsPolicyExtensions)
2. Create a method on `XYZCorsPolicyExtensions` with signature; `Action<CorsPolicyBuilder>` [NameOfPolicy]CorsAction(IConfiguration configuration)
3. In the method `[NameOfPolicy]CorsAction` return an anonymous delegate `(builder) => { }` and include your policy.
4. Then back in the class `CorsExtensions` base class, inside the method `CorsOptionsAction` include your extension method:

This will allow the code base to scale, and keep the additions of Policies readable and maintainable.

#### Before State of Code Base:

```cs
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
```

#### After State of Code Base

```cs
public static Action<CorsOptions> CorsOptionsAction(IConfiguration configuration)
{
    var defaultAction = DefaultCorsPolicyAction(configuration);
    var staticFilesAction = StaticFilesCorsPolicyAction(configuration); // [!code ++]
    return (options) =>
    {
        options.DefaultPolicyName =
            configuration[Consts.DEFAULT_CORS_SETTINGS_DEFAULT_CORS_POLICY_NAME]!;
        options.AddDefaultPolicy(defaultAction);
        options.AddPolicy(staticFilesAction); // [!code ++]
    };
}
```

### Complete Code

```cs
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
