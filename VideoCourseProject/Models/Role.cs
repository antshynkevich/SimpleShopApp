using System.ComponentModel.DataAnnotations;

namespace VideoCourseProject.Models;

public class Role
{
    [Required]
    public string Name { get; set; }
}
