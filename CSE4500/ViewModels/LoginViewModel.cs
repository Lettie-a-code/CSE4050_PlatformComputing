using System.ComponentModel.DataAnnotations;
namespace CSE4050_SignIn.ViewModels;
public class LoginViewModel
{
    [Required, EmailAddress]
    public string Email { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
}
