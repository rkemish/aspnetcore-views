namespace AspNetCoreViewsDemo.Web.Models.Demos;

public class StatusPanelViewModel
{
    public required string EnvironmentName { get; init; }

    public required string BuildVersion { get; init; }

    public DateTimeOffset GeneratedAt { get; init; }
}
