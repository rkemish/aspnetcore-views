using AspNetCoreViewsDemo.Web.Models.Demos;
using AspNetCoreViewsDemo.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreViewsDemo.Web.Controllers;

public class ConceptsController(IDemoContentService demoContentService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

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

    public IActionResult ViewComponents()
    {
        return View();
    }

    [HttpGet]
    public IActionResult TagHelpers()
    {
        PopulateTopics();
        return View(new ContactFormInputModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TagHelpers(ContactFormInputModel input)
    {
        if (!ModelState.IsValid)
        {
            PopulateTopics();
            return View(input);
        }

        TempData["SubmissionMessage"] = $"Thanks {input.Name}, your '{input.Topic}' message was submitted.";
        return RedirectToAction(nameof(TagHelpers));
    }

    public IActionResult Documentation()
    {
        return View();
    }

    private void PopulateTopics()
    {
        var topics = demoContentService.GetContactTopics();
        ViewBag.Topics = new SelectList(topics);
    }
}
