using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace D2App.WebApi.Configurations;

public static class D2HealthChecksExtensions
{
  public static IServiceCollection AddD2HealthChecks(this IServiceCollection services)
  {
    services.AddHealthChecks();
    return services;
  }

  public static WebApplication UseD2HealthChecks(this WebApplication app)
  {
    var check = GetHealthCheckOptions();
    app.MapHealthChecks("/health", GetHealthCheckOptions());
    return app;
  }

  private static HealthCheckOptions GetHealthCheckOptions()
  {
    return new HealthCheckOptions
    {
      ResponseWriter = async (context, report) =>
      {
        context.Response.ContentType = "application/json";
        var result = new
        {
          status = report.Status.ToString(),
          totalChecks = report.Entries.Count,
          totalDuration = report.TotalDuration,
          checks = report.Entries.Select(x => new
          {
            key = x.Key,
            status = x.Value.Status.ToString(),
            description = x.Value.Description,
            data = x.Value.Data,
          }),
        };
        await context.Response.WriteAsJsonAsync(result, new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
          WriteIndented = true
        });
      }
    };
  }
}