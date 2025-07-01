using System;
using D2App.WebApi.HttpClients;

namespace D2App.WebApi.Features.Get.Manifest;

public static class ManifestEndpoint
{
  public static void UseManifestEndpoint(this WebApplication app)
  {
    app.MapGet("/manifest", (IManifestHttpClient client) =>
    {
      return client.GetManifestAsync()
        .ContinueWith(task =>
        {
          if (task.IsFaulted)
          {
            return Results.Problem("An error occurred while fetching the manifest.");
          }
          return Results.Ok(task.Result);
        });
    });
  }
}
