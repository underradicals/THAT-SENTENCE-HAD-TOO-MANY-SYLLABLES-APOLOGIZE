namespace D2App.WebApi.Configurations;

public static class HttpClientFactoryExtensions
{
  public static IServiceCollection AddHttpClientFactoryServices(this IServiceCollection services)
  {
    services.AddHttpClient("ManifestClient", httpClient =>
    {
      httpClient.BaseAddress = new Uri("https://www.bungie.net");
      httpClient.DefaultRequestHeaders.Add("X-API-Key", Environment.GetEnvironmentVariable("D2_API_KEY"));
      httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    });
    return services;
  }
}