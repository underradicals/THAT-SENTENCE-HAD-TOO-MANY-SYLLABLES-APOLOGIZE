namespace Applications.Logging.Serilog;

public static class SerilogApplicationExtensions
{
  public static WebApplicationBuilder AddSerilogServices(this WebApplicationBuilder builder)
  {
    builder.Host.UseSerilog((context, services, configuration) =>
    {
      configuration
        .AddOverrides()
        .AddLoggerSettingsConfiguration(services, context)
        .AddEnrichers()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm}] [{Level}] {Message:lj} {Properties}{NewLine}{Exception}");
    });

    return builder;
  }


  public static LoggerConfiguration AddLoggerSettingsConfiguration(this LoggerConfiguration loggerConfiguration, IServiceProvider services,  HostBuilderContext context)
  {

    loggerConfiguration
      .ReadFrom.Configuration(context.Configuration)
      .ReadFrom.Services(services);
    return loggerConfiguration;
  }


  public static LoggerConfiguration AddOverrides(this LoggerConfiguration configuration)
  {
    configuration
      .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Information)
      .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Information)
      .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Information);
    return configuration;
  }

  public static LoggerConfiguration AddEnrichers(this LoggerConfiguration configuration)
  {
    configuration
      .Enrich.FromLogContext()
      .Enrich.WithThreadId()
      .Enrich.WithThreadId()
      .Enrich.WithMachineName()
      .Enrich.WithEnvironmentName();
    return configuration;
  }

  public static void AddBootStrapsBootStrap()
  {
    Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Verbose)
        .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Verbose)
        .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Verbose)
        .AddEnrichers()
      .WriteTo.Console()
      .CreateLogger();
  }


  public static WebApplication UseSerilogMiddleware(this WebApplication app)
  {
    app.UseSerilogRequestLogging();
    return app;
  }
}
