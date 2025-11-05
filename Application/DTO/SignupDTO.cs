using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class SignupDTO
{
    [StringLength(25)]
    [Required(ErrorMessage = "User name required")]
    public string Username { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Incorrect email address")]
    [Required(ErrorMessage = "Please, enter your email address")]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Compare("Password", ErrorMessage = "Your password and Confirm must match each other")]
    public string ConfirmedPassword { get; set; } = string.Empty;
}
