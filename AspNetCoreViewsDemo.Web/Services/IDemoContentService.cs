using AspNetCoreViewsDemo.Web.Models.Demos;

namespace AspNetCoreViewsDemo.Web.Services;

/// <summary>
/// Provides demo content used across the Concepts section of the site.
/// Abstracting behind an interface makes it straightforward to swap the
/// in-memory implementation for a database-backed one without touching
/// controllers or view components.
/// </summary>
public interface IDemoContentService
{
    /// <summary>
    /// Returns the most recent <paramref name="count"/> articles, ordered from
    /// newest to oldest, for display in the Recent Articles view component.
    /// </summary>
    /// <param name="count">The maximum number of articles to return.</param>
    /// <param name="cancellationToken">Token to observe for cancellation requests.</param>
    Task<IReadOnlyList<RecentArticleViewModel>> GetRecentArticlesAsync(int count, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a snapshot of the current application environment and build
    /// information for display in the Status Panel view component.
    /// </summary>
    /// <param name="cancellationToken">Token to observe for cancellation requests.</param>
    Task<StatusPanelViewModel> GetStatusPanelAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the list of contact topics used to populate the topic dropdown
    /// on the Tag Helpers demo form.
    /// </summary>
    IReadOnlyList<string> GetContactTopics();
}
