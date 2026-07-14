using System.ComponentModel.DataAnnotations;

namespace AspNetCoreViewsDemo.Web.Models.Demos;

public class ContactFormInputModel
{
    [Required]
    [StringLength(80)]
    [Display(Name = "Your name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Topic")]
    public string Topic { get; set; } = string.Empty;

    [Required]
    [StringLength(500, MinimumLength = 20)]
    public string Message { get; set; } = string.Empty;

    [Display(Name = "Email me product updates")]
    public bool SubscribeToUpdates { get; set; }
}
