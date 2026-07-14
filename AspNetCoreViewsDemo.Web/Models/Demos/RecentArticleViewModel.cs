namespace AspNetCoreViewsDemo.Web.Models.Demos;

public class RecentArticleViewModel
{
    public required int Id { get; init; }

    public required string Title { get; init; }

    public required string Category { get; init; }

    public required string Summary { get; init; }

    public DateOnly PublishedOn { get; init; }
}
