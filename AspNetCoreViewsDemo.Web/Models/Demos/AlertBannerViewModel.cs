namespace AspNetCoreViewsDemo.Web.Models.Demos;

/// <summary>
/// View model for the <c>_AlertBanner</c> partial view.
/// Carries the text content and Bootstrap color variant used to render a
/// dismissible alert banner at the top of a page or section.
/// </summary>
public class AlertBannerViewModel
{
    /// <summary>The bold heading displayed at the top of the banner.</summary>
    public required string Title { get; init; }

    /// <summary>The supporting body text shown beneath the heading.</summary>
    public required string Message { get; init; }

    /// <summary>
    /// Bootstrap color variant that controls the banner's appearance.
    /// Common values: <c>"info"</c>, <c>"success"</c>, <c>"warning"</c>, <c>"danger"</c>.
    /// </summary>
    public required string Style { get; init; }
}
