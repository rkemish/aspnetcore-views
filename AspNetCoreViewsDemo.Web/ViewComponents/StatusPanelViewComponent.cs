using AspNetCoreViewsDemo.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreViewsDemo.Web.ViewComponents;

/// <summary>
/// View component that fetches and renders a status panel showing the current
/// environment name, assembly build version, and the time the data was generated.
/// Invoked from Razor views using:
/// <code>@await Component.InvokeAsync("StatusPanel")</code>
/// Its default view lives at
/// <c>Views/Shared/Components/StatusPanel/Default.cshtml</c>.
/// </summary>
public class StatusPanelViewComponent(IDemoContentService demoContentService) : ViewComponent
{
    /// <summary>
    /// Fetches the current application status information and passes it to
    /// the component's default view as the view model.
    /// </summary>
    /// <param name="cancellationToken">Token to observe for cancellation requests.</param>
    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken = default)
    {
        var model = await demoContentService.GetStatusPanelAsync(cancellationToken);
        return View(model);
    }
}
