using System.ComponentModel.DataAnnotations;

namespace IdentityService.Pages.Register;

public class InputModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
    public string Button { get; set; }
    public string ReturnUrl { get; set; }
}