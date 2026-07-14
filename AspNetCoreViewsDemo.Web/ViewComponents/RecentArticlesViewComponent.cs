using AspNetCoreViewsDemo.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreViewsDemo.Web.ViewComponents;

/// <summary>
/// View component that fetches and renders a list of recent articles.
/// Invoked from Razor views using:
/// <code>@await Component.InvokeAsync("RecentArticles", new { count = 4 })</code>
/// The component retrieves data independently through <see cref="IDemoContentService"/>,
/// which is why it is a view component rather than a partial view.
/// Its default view lives at
/// <c>Views/Shared/Components/RecentArticles/Default.cshtml</c>.
/// </summary>
public class RecentArticlesViewComponent(IDemoContentService demoContentService) : ViewComponent
{
    /// <summary>
    /// Fetches up to <paramref name="count"/> recent articles and passes them
    /// to the component's default view as the view model.
    /// </summary>
    /// <param name="count">The maximum number of articles to display. Defaults to 3.</param>
    /// <param name="cancellationToken">Token to observe for cancellation requests.</param>
    public async Task<IViewComponentResult> InvokeAsync(int count = 3, CancellationToken cancellationToken = default)
    {
        var model = await demoContentService.GetRecentArticlesAsync(count, cancellationToken);
        return View(model);
    }
}
