using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net;

namespace AspNetCoreViewsDemo.Web.TagHelpers;

[HtmlTargetElement("concept-callout")]
public class ConceptCalloutTagHelper : TagHelper
{
    public string Title { get; set; } = "Callout";

    public string Tone { get; set; } = "info";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "section";
        output.TagMode = TagMode.StartTagAndEndTag;

        var normalizedTone = Tone.ToLowerInvariant() switch
        {
            "success" => "success",
            "warning" => "warning",
            "danger" => "danger",
            _ => "info"
        };

        output.Attributes.SetAttribute("class", $"alert alert-{normalizedTone}");
        output.PreContent.SetHtmlContent($"<h5 class=\"alert-heading mb-2\">{WebUtility.HtmlEncode(Title)}</h5>");
    }
}
