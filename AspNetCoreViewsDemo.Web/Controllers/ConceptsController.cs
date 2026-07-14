using AspNetCoreViewsDemo.Web.Models.Demos;
using AspNetCoreViewsDemo.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreViewsDemo.Web.Controllers;

/// <summary>
/// Drives the "Concepts" section of the demo site. Each action corresponds to a
/// dedicated Razor view that demonstrates a specific ASP.NET Core view feature:
/// partial views, view components, tag helpers, and documentation.
/// <para>
/// <see cref="IDemoContentService"/> is injected via the primary constructor so
/// actions that need dynamic data (e.g. the Tag Helpers form topic list) can
/// retrieve it without coupling the controller to a concrete implementation.
/// </para>
/// </summary>
public class ConceptsController(IDemoContentService demoContentService) : Controller
{
    /// <summary>
    /// Renders the Concepts section index / overview page
    /// (<c>Views/Concepts/Index.cshtml</c>).
    /// </summary>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Builds the view model for the Partial Views demo page and passes it to
    /// <c>Views/Concepts/Partials.cshtml</c>.
    /// The model contains:
    /// <list type="bullet">
    ///   <item>An <see cref="AlertBannerViewModel"/> rendered via the <c>_AlertBanner</c> partial.</item>
    ///   <item>A collection of <see cref="FeatureCardViewModel"/> items rendered via the <c>_FeatureCard</c> partial.</item>
    /// </list>
    /// </summary>
    public IActionResult Partials()
    {
        var model = new PartialsDemoViewModel
        {
            Alert = new AlertBannerViewModel
            {
                Title = "Partial views are for reusable markup.",
                Message = "Use partials for presentational fragments that do not need independent data-fetching behavior.",
                Style = "info"
            },
            FeatureCards =
            [
                new FeatureCardViewModel
                {
                    Title = "Strongly typed",
                    Description = "Each partial can receive a dedicated model and remain easy to test and reuse.",
                    BadgeText = "Typed"
                },
                new FeatureCardViewModel
                {
                    Title = "Composable",
                    Description = "Partials can be nested inside pages and other partials for layered UI composition.",
                    BadgeText = "Reusable"
                },
                new FeatureCardViewModel
                {
                    Title = "Low overhead",
                    Description = "Perfect for shared cards, banners, and snippets that should not live in controller actions.",
                    BadgeText = "Fast"
                }
            ]
        };

        return View(model);
    }

    /// <summary>
    /// Renders the View Components demo page (<c>Views/Concepts/ViewComponents.cshtml</c>).
    /// The view itself invokes <c>RecentArticles</c> and <c>StatusPanel</c> view components
    /// directly using <c>@await Component.InvokeAsync(...)</c>, so no model is needed here.
    /// </summary>
    public IActionResult ViewComponents()
    {
        return View();
    }

    /// <summary>
    /// Handles GET requests for the Tag Helpers demo page. Populates
    /// <see cref="ViewBag.Topics"/> with a <see cref="SelectList"/> so the Razor view
    /// can render a dropdown, then returns a blank <see cref="ContactFormInputModel"/>
    /// as the page model.
    /// </summary>
    [HttpGet]
    public IActionResult TagHelpers()
    {
        PopulateTopics();
        return View(new ContactFormInputModel());
    }

    /// <summary>
    /// Handles POST submissions of the contact form on the Tag Helpers demo page.
    /// Validates the model; if invalid, re-renders the form with validation messages.
    /// On success, stores a confirmation message in <see cref="TempData"/> (so it
    /// survives the redirect) and redirects back to the GET action (PRG pattern).
    /// </summary>
    /// <param name="input">The form values bound from the request body.</param>
    [HttpPost]
    [ValidateAntiForgeryToken] // Protects against cross-site request forgery attacks.
    public IActionResult TagHelpers(ContactFormInputModel input)
    {
        if (!ModelState.IsValid)
        {
            // Re-populate the dropdown before re-rendering the form because
            // ViewBag is not preserved across the POST.
            PopulateTopics();
            return View(input);
        }

        // Store the success message in TempData so it is available after the redirect.
        TempData["SubmissionMessage"] = $"Thanks {input.Name}, your '{input.Topic}' message was submitted.";
        return RedirectToAction(nameof(TagHelpers));
    }

    /// <summary>
    /// Renders the documentation / reference page (<c>Views/Concepts/Documentation.cshtml</c>).
    /// </summary>
    public IActionResult Documentation()
    {
        return View();
    }

    /// <summary>
    /// Retrieves the available contact topics from the content service and stores
    /// them in <see cref="ViewBag"/> as a <see cref="SelectList"/> so the Razor
    /// view can bind them to a <c>&lt;select&gt;</c> element via Tag Helpers.
    /// Called before every GET and failed-POST render of the TagHelpers action.
    /// </summary>
    private void PopulateTopics()
    {
        var topics = demoContentService.GetContactTopics();
        ViewBag.Topics = new SelectList(topics);
    }
}
