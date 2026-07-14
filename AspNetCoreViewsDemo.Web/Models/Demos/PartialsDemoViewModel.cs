namespace AspNetCoreViewsDemo.Web.Models.Demos;

public class PartialsDemoViewModel
{
    public required IReadOnlyList<FeatureCardViewModel> FeatureCards { get; init; }

    public required AlertBannerViewModel Alert { get; init; }
}
