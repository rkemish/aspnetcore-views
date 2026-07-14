namespace AspNetCoreViewsDemo.Web.Models.Demos;

/// <summary>
/// Composite view model for the Partials demo page
/// (<c>Views/Concepts/Partials.cshtml</c>).
/// Bundles the data needed by every partial view rendered on that page into a
/// single strongly-typed object passed from <c>ConceptsController.Partials</c>.
/// </summary>
public class PartialsDemoViewModel
{
    /// <summary>
    /// Data for the <c>_FeatureCard</c> partials displayed as a card grid.
    /// Each item in the list is passed as the model when the partial is rendered.
    /// </summary>
    public required IReadOnlyList<FeatureCardViewModel> FeatureCards { get; init; }

    /// <summary>
    /// Data for the <c>_AlertBanner</c> partial rendered at the top of the page.
    /// </summary>
    public required AlertBannerViewModel Alert { get; init; }
}
