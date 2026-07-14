namespace AspNetCoreViewsDemo.Web.Models.Demos;

/// <summary>
/// View model for the <c>StatusPanel</c> view component.
/// Exposes runtime environment information useful for debugging and confirming
/// which build is deployed.
/// </summary>
public class StatusPanelViewModel
{
    /// <summary>
    /// The ASP.NET Core hosting environment name (e.g. <c>"Development"</c>,
    /// <c>"Staging"</c>, <c>"Production"</c>). Driven by the
    /// <c>ASPNETCORE_ENVIRONMENT</c> environment variable.
    /// </summary>
    public required string EnvironmentName { get; init; }

    /// <summary>The assembly version string of the running application.</summary>
    public required string BuildVersion { get; init; }

    /// <summary>
    /// The UTC timestamp captured when this view model was constructed, showing
    /// when the panel data was generated.
    /// </summary>
    public DateTimeOffset GeneratedAt { get; init; }
}
