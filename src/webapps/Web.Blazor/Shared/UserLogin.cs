namespace Web.Blazor.Shared;

using System.ComponentModel.DataAnnotations;

public class UserLogin
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}