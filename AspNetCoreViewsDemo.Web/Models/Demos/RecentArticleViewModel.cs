namespace AspNetCoreViewsDemo.Web.Models.Demos;

/// <summary>
/// Represents a single article entry displayed by the
/// <c>RecentArticles</c> view component.
/// </summary>
public class RecentArticleViewModel
{
    /// <summary>Unique identifier for the article (used for linking).</summary>
    public required int Id { get; init; }

    /// <summary>The full title of the article.</summary>
    public required string Title { get; init; }

    /// <summary>The topic category the article belongs to (e.g. "Partials").</summary>
    public required string Category { get; init; }

    /// <summary>A short one- or two-sentence abstract of the article.</summary>
    public required string Summary { get; init; }

    /// <summary>The calendar date on which the article was published.</summary>
    public DateOnly PublishedOn { get; init; }
}
