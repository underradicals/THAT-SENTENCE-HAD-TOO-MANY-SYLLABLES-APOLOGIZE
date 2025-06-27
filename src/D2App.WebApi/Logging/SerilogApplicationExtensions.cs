namespace Applications.Logging.Serilog;

public static class SerilogApplicationExtensions
{
  public static WebApplicationBuilder AddSerilogServices(this WebApplicationBuilder builder)
  {
    builder.Host.UseSerilog((context, services, configuration) =>
    {
      configuration
      .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Information)
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .Enrich.WithThreadId()
        .Enrich.WithThreadId()
        .Enrich.WithMachineName()
        .Enrich.WithEnvironmentName()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm}] [{Level}] {Message:lj} {Properties}{NewLine}{Exception}");
    });

    return builder;
  }

  public static void AddBootStrapsBootStrap()
  {
    Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Verbose)
        .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Verbose)
        .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Verbose)
        .Enrich.FromLogContext()
        .Enrich.WithThreadId()
        .Enrich.WithThreadId()
        .Enrich.WithMachineName()
        .Enrich.WithEnvironmentName()
      .WriteTo.Console()
      .CreateLogger();
  }


  public static WebApplication UseSerilogMiddleware(this WebApplication app)
  {
    app.UseSerilogRequestLogging();
    return app;
  }
}
