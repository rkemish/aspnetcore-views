using AspNetCoreViewsDemo.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreViewsDemo.Web.ViewComponents;

public class StatusPanelViewComponent(IDemoContentService demoContentService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken = default)
    {
        var model = await demoContentService.GetStatusPanelAsync(cancellationToken);
        return View(model);
    }
}
