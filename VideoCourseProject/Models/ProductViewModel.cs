using System.ComponentModel.DataAnnotations;

namespace VideoCourseProject.Models;

public class ProductViewModel
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Range(0, 1000000)] 
    [Required]
    public decimal Cost { get; set; }
    [Required]
    public string Description { get; set; }
    public string ImagePath { get; set; }
}
