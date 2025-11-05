using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class Signin
{
    [StringLength(25)]
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
