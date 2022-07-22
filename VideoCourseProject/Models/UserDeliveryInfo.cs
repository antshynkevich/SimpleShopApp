using System.ComponentModel.DataAnnotations;

namespace VideoCourseProject.Models;

public class UserDeliveryInfo
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
}
