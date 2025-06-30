---
title: Health Check Implementation
lang: en-US
aside: true
layout: doc
---

# Health Check Implementation

---

Here is documentation that explains your `D2HealthChecksExtensions` implementation, following a professional and structured style suitable for internal docs, READMEs, or system design documentation:

---

## 📦 Health Check Implementation

This section documents the `D2HealthChecksExtensions` used to integrate and expose a health check endpoint in the `D2App.WebApi`.

---

### ✅ Purpose

Health checks provide a structured way to expose the operational status of the application. This implementation:

- Enables a `/health` endpoint.
- Returns a detailed JSON payload describing system health.
- Serves as a foundation for future dependency checks (e.g., database, Redis, external services).

---

### 🔧 Code Overview

#### `AddD2HealthChecks(IServiceCollection)`

Registers the default .NET Core health checks with the dependency injection container.

```csharp
public static IServiceCollection AddD2HealthChecks(this IServiceCollection services)
{
  services.AddHealthChecks();
  return services;
}
```

At this stage, no dependency checks are added. This keeps the setup minimal and extensible. Additional checks can be chained later, for example:

```csharp
services.AddHealthChecks()
        .AddSqlServer(connectionString, name: "sql");
```

---

#### `UseD2HealthChecks(WebApplication)`

Maps the `/health` endpoint and applies a custom response writer.

```csharp
public static WebApplication UseD2HealthChecks(this WebApplication app)
{
  app.MapHealthChecks("/health", GetHealthCheckOptions());
  return app;
}
```

This method is intended to be called from `Program.cs` after routing middleware is applied.

---

#### `GetHealthCheckOptions()`

Defines a `HealthCheckOptions` instance with a customized JSON output.

```csharp
private static HealthCheckOptions GetHealthCheckOptions()
```

#### Custom Response Format

Instead of returning the default plain text (`Healthy`), this implementation produces a structured JSON response:

```json
{
  "status": "Healthy",
  "totalChecks": 0,
  "totalDuration": "00:00:00.0002480",
  "checks": []
}
```

This output includes:

- **`status`**: Aggregated health status (`Healthy`, `Unhealthy`, or `Degraded`)
- **`totalChecks`**: Number of registered dependency checks
- **`totalDuration`**: Total time taken to evaluate all checks
- **`checks`**: Per-check results (currently empty)

#### JSON Serialization Options

```csharp
new JsonSerializerOptions
{
  PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
  WriteIndented = true
}
```

These ensure the response is:

- **CamelCase** (standard for JSON APIs)
- **Pretty-printed** for readability

---

### 🚀 How to Use

#### Register in `Program.cs`

```csharp
builder.Services.AddD2HealthChecks();
```

#### Configure Pipeline

```csharp
app.UseRouting();
app.UseD2HealthChecks(); // Maps /health
```

#### Test

```http
GET http://localhost:5000/health
```

Expected response (no checks yet):

```json
{
  "status": "Healthy",
  "totalChecks": 0,
  "totalDuration": "00:00:00.0002031",
  "checks": []
}
```

---

### 🧩 Extending with Dependency Checks

You can register checks as follows in `AddD2HealthChecks`:

```csharp
services.AddHealthChecks()
        .AddSqlServer(connectionString, name: "sql", timeout: TimeSpan.FromSeconds(2));
```

Each added check will appear in the `checks[]` array in the response payload.

---

### 🛡️ Deployment Considerations

- **Public or Internal?**
  The endpoint is currently unauthenticated. Restrict access if necessary via firewall, gateway rules, or middleware.

- **Monitoring Integration**
  Compatible with load balancers, Kubernetes readiness/liveness probes, and monitoring tools (e.g., Prometheus, Azure Monitor, Pingdom).

- **Startup Readiness**
  Extend logic to support readiness semantics (e.g., delay signaling `Healthy` until database is connected).

---

### 📌 Summary

| Feature       | Description                             |
| ------------- | --------------------------------------- |
| Endpoint      | `/health`                               |
| Output Format | Custom JSON                             |
| Dependencies  | None by default (extensible)            |
| Use Cases     | Monitoring, orchestration, CI/CD gating |
| Customizable  | ✔️ Yes – via standard health check APIs |

This modular, standards-compliant health check design provides a clean foundation for both internal diagnostics and production-grade infrastructure integration.

---

### Full Implementation

#### `D2HealthChecksExtensions.cs`

```cs
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace D2App.WebApi.Configurations;

public static class D2HealthChecksExtensions
{
  public static IServiceCollection AddD2HealthChecks(
    this IServiceCollection services
    )
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
        await context.Response.WriteAsJsonAsync(
          result,
          new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
          WriteIndented = true
        });
      }
    };
  }
}
```

#### `Program.cs`

```js
using D2App.WebApi.Configurations;

try
{
    SerilogApplicationExtensions.AddBootStrapsBootStrap();
    Log.Information("Starting the application...");

    var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;
    builder.AddSerilogServices();
    builder.Services.AddD2HealthChecks(); // [!code focus]
    builder.Services.AddDefaultD2AppCorsConfiguration(configuration);

    builder.Services.AddOpenApi();

    var app = builder.Build();

    app.UseD2AppCorsConfiguration(configuration);
    app.UseSerilogMiddleware();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseD2HealthChecks(); // [!code focus]
    app.MapGet("/", () => new { message = "Hello World!" });

    app.Run();
}
catch (Exception ex)
{
    // Log the exception
    Log.Fatal(ex, "An unhandled exception occurred during bootstrapping the application.");
    throw;
}
finally
{
    Log.Information("Application has shut down.");
    Log.CloseAndFlush();
}
```
