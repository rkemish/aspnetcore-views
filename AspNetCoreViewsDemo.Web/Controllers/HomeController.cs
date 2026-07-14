using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreViewsDemo.Web.Models;

namespace AspNetCoreViewsDemo.Web.Controllers;

/// <summary>
/// Handles the top-level site pages: the landing page, the privacy policy, and
/// the generic error page.
/// </summary>
public class HomeController : Controller
{
    /// <summary>
    /// Renders the site landing page (<c>Views/Home/Index.cshtml</c>).
    /// </summary>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Renders the privacy policy page (<c>Views/Home/Privacy.cshtml</c>).
    /// </summary>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Renders the error page. Caching is disabled so stale error responses are
    /// never served from a proxy or browser cache.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // Prefer the Activity (distributed tracing) ID when available; fall back to
        // the ASP.NET Core trace identifier so the error can always be correlated.
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
