using System.ComponentModel.DataAnnotations;

namespace VideoCourseProject.Models;

public class Register
{
    [Required]
    [EmailAddress]
    public string Username { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 4)]
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
