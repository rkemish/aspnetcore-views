using AspNetCoreViewsDemo.Web.Models.Demos;

namespace AspNetCoreViewsDemo.Web.Services;

/// <summary>
/// In-memory implementation of <see cref="IDemoContentService"/>.
/// All data is hard-coded so the demo runs without a database.
/// Registered as a singleton in <c>Program.cs</c> so the same instance—and
/// therefore the same data—is reused for every request.
/// </summary>
public class DemoContentService(IHostEnvironment environment) : IDemoContentService
{
    // Static, read-only list of articles used across all requests.
    // Using a static field avoids re-allocating the collection on every call.
    private static readonly IReadOnlyList<RecentArticleViewModel> Articles =
    [
        new RecentArticleViewModel
        {
            Id = 101,
            Title = "Razor partials in production pages",
            Category = "Partials",
            Summary = "How to keep repeated UI fragments maintainable with strongly typed partials.",
            PublishedOn = new DateOnly(2026, 6, 17)
        },
        new RecentArticleViewModel
        {
            Id = 102,
            Title = "When view components outperform partial views",
            Category = "View Components",
            Summary = "Decision points for moving from presentational partials to data-backed components.",
            PublishedOn = new DateOnly(2026, 6, 24)
        },
        new RecentArticleViewModel
        {
            Id = 103,
            Title = "Tag Helpers for clean, route-safe markup",
            Category = "Tag Helpers",
            Summary = "Using built-in Tag Helpers to author links, forms, and validation UIs in Razor.",
            PublishedOn = new DateOnly(2026, 7, 2)
        },
        new RecentArticleViewModel
        {
            Id = 104,
            Title = "Composing maintainable Razor views",
            Category = "Razor Views",
            Summary = "A practical approach for splitting responsibilities between layouts, partials, and components.",
            PublishedOn = new DateOnly(2026, 7, 9)
        }
    ];

    // Static list of topics available in the Tag Helpers demo contact form dropdown.
    private static readonly IReadOnlyList<string> ContactTopics =
    [
        "Partial Views",
        "View Components",
        "Tag Helpers",
        "General Razor Composition"
    ];

    /// <inheritdoc />
    /// <remarks>
    /// Uses <see cref="Enumerable.Take{T}"/> so the caller can control how many
    /// articles appear without exposing the full list. Wrapped in a completed
    /// <see cref="Task"/> to satisfy the async interface contract without
    /// actual I/O overhead.
    /// </remarks>
    public Task<IReadOnlyList<RecentArticleViewModel>> GetRecentArticlesAsync(int count, CancellationToken cancellationToken = default)
    {
        var items = Articles.Take(count).ToArray();
        return Task.FromResult<IReadOnlyList<RecentArticleViewModel>>(items);
    }

    /// <inheritdoc />
    /// <remarks>
    /// Reads the assembly version at call time so the panel always reflects the
    /// version of the currently running assembly. <see cref="DateTimeOffset.UtcNow"/>
    /// captures the exact moment the panel data was generated.
    /// </remarks>
    public Task<StatusPanelViewModel> GetStatusPanelAsync(CancellationToken cancellationToken = default)
    {
        // Reflect the assembly version; fall back to "1.0.0" if the attribute is absent.
        var version = typeof(DemoContentService).Assembly.GetName().Version?.ToString() ?? "1.0.0";
        var panel = new StatusPanelViewModel
        {
            // IHostEnvironment.EnvironmentName is set by ASPNETCORE_ENVIRONMENT (e.g. "Development", "Production").
            EnvironmentName = environment.EnvironmentName,
            BuildVersion = version,
            GeneratedAt = DateTimeOffset.UtcNow
        };

        return Task.FromResult(panel);
    }

    /// <inheritdoc />
    public IReadOnlyList<string> GetContactTopics()
    {
        return ContactTopics;
    }
}
