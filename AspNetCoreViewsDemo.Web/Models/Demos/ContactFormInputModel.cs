using System.ComponentModel.DataAnnotations;

namespace AspNetCoreViewsDemo.Web.Models.Demos;

/// <summary>
/// Input model for the contact form on the Tag Helpers demo page.
/// Data Annotations drive both server-side model validation (ModelState) and
/// client-side validation via <c>jquery-validation-unobtrusive</c>.
/// </summary>
public class ContactFormInputModel
{
    /// <summary>The sender's display name. Maximum 80 characters.</summary>
    [Required]
    [StringLength(80)]
    [Display(Name = "Your name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>A valid email address used to identify the sender.</summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>The subject area the message relates to (bound to a dropdown).</summary>
    [Required]
    [Display(Name = "Topic")]
    public string Topic { get; set; } = string.Empty;

    /// <summary>The body of the message. Between 20 and 500 characters.</summary>
    [Required]
    [StringLength(500, MinimumLength = 20)]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Opt-in flag indicating whether the sender wants to receive product updates.
    /// Bound to a checkbox in the form.
    /// </summary>
    [Display(Name = "Email me product updates")]
    public bool SubscribeToUpdates { get; set; }
}
