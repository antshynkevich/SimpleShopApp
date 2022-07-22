using System.ComponentModel.DataAnnotations;

namespace VideoCourseProject.Models;

public class Login
{
    [Required]
    [EmailAddress]
    public string Username { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 4)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }

}
