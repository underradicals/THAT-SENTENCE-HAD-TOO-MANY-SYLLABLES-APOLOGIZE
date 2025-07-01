using System.Text.Json.Serialization;

namespace D2App.WebApi.Domain;

public class ManifestResponse
{
  [JsonPropertyName("version")]
  public string Version { get; set; } = string.Empty;
}
