using AspNetCoreViewsDemo.Web.Models.Demos;

namespace AspNetCoreViewsDemo.Web.Services;

public interface IDemoContentService
{
    Task<IReadOnlyList<RecentArticleViewModel>> GetRecentArticlesAsync(int count, CancellationToken cancellationToken = default);

    Task<StatusPanelViewModel> GetStatusPanelAsync(CancellationToken cancellationToken = default);

    IReadOnlyList<string> GetContactTopics();
}
