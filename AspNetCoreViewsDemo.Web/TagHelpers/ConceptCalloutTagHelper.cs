using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net;

namespace AspNetCoreViewsDemo.Web.TagHelpers;

/// <summary>
/// Custom Tag Helper that transforms a <c>&lt;concept-callout&gt;</c> element in
/// Razor markup into a Bootstrap-styled alert <c>&lt;section&gt;</c> with a heading.
/// <para>
/// Usage in a Razor view:
/// <code>
/// &lt;concept-callout title="Important" tone="warning"&gt;
///     Body text goes here.
/// &lt;/concept-callout&gt;
/// </code>
/// </para>
/// </summary>
[HtmlTargetElement("concept-callout")]
public class ConceptCalloutTagHelper : TagHelper
{
    /// <summary>
    /// The heading text rendered inside the callout. Defaults to "Callout".
    /// The value is HTML-encoded before output to prevent XSS.
    /// </summary>
    public string Title { get; set; } = "Callout";

    /// <summary>
    /// Controls the Bootstrap color variant applied to the callout.
    /// Accepted values: <c>"info"</c> (default), <c>"success"</c>,
    /// <c>"warning"</c>, <c>"danger"</c>. Any unrecognised value falls back to <c>"info"</c>.
    /// </summary>
    public string Tone { get; set; } = "info";

    /// <summary>
    /// Transforms the <c>&lt;concept-callout&gt;</c> element into a
    /// <c>&lt;section class="alert alert-{tone}"&gt;</c> element with an
    /// <c>&lt;h5&gt;</c> heading prepended before the original inner content.
    /// </summary>
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // Replace the custom element name with a semantic <section> tag.
        output.TagName = "section";
        output.TagMode = TagMode.StartTagAndEndTag;

        // Normalise the tone to a known Bootstrap variant; unknown values default to "info".
        var normalizedTone = Tone.ToLowerInvariant() switch
        {
            "success" => "success",
            "warning" => "warning",
            "danger"  => "danger",
            _         => "info"
        };

        // Apply the Bootstrap alert class using the resolved tone variant.
        output.Attributes.SetAttribute("class", $"alert alert-{normalizedTone}");

        // Prepend an <h5> heading before the child content.
        // HtmlEncode prevents the Title value from injecting arbitrary HTML.
        output.PreContent.SetHtmlContent($"<h5 class=\"alert-heading mb-2\">{WebUtility.HtmlEncode(Title)}</h5>");
    }
}
