using System;
using System.Text.Json.Serialization;
using D2App.WebApi.Domain;

namespace D2App.WebApi.HttpClients;

public interface IManifestHttpClient
{
  Task<ManifestRoot?> GetManifestAsync();
}

public class ManifestHttpClient : IManifestHttpClient
{
  private readonly IHttpClientFactory _httpClientFactory;

  public ManifestHttpClient(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async Task<ManifestRoot?> GetManifestAsync()
  {
    var client = _httpClientFactory.CreateClient("ManifestClient");
    var response = await client.GetAsync("/Platform/Destiny2/Manifest");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<ManifestRoot>();
  }
}

