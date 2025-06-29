namespace D2App.WebApi.Common.ConfigurationBindings;

public class GlobalApiConfiguration
{
    public const string SectionName = nameof(GlobalApiConfiguration);
    public string ClientUrl { get; init; } = string.Empty;
    public string DefaultCorsPolicyName { get; init; } = string.Empty;
}