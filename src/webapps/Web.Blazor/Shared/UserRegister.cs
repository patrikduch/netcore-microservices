using System.ComponentModel.DataAnnotations;

namespace Web.Blazor.Shared;

public class UserRegister
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

    [Compare("Password", ErrorMessage = "The passwords do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}

