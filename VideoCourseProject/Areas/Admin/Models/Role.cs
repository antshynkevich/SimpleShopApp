using System.ComponentModel.DataAnnotations;

namespace VideoCourseProject.Areas.Admin.Models;

public class Role
{
    [Required]
    public string Name { get; set; }
}
