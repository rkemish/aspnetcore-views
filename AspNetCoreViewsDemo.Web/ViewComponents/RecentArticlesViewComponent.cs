using AspNetCoreViewsDemo.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreViewsDemo.Web.ViewComponents;

public class RecentArticlesViewComponent(IDemoContentService demoContentService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(int count = 3, CancellationToken cancellationToken = default)
    {
        var model = await demoContentService.GetRecentArticlesAsync(count, cancellationToken);
        return View(model);
    }
}
