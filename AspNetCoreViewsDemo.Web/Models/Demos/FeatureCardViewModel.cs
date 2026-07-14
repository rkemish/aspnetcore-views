namespace AspNetCoreViewsDemo.Web.Models.Demos;

/// <summary>
/// View model for the <c>_FeatureCard</c> partial view.
/// Represents a single feature highlight card displayed on the Partials demo page.
/// </summary>
public class FeatureCardViewModel
{
    /// <summary>The short heading displayed at the top of the card.</summary>
    public required string Title { get; init; }

    /// <summary>A one- or two-sentence description of the feature.</summary>
    public required string Description { get; init; }

    /// <summary>Short label rendered as a badge in the card header.</summary>
    public required string BadgeText { get; init; }
}
