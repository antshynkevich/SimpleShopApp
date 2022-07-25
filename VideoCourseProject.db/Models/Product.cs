using System.ComponentModel.DataAnnotations;

namespace VideoCourseProject.db.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
    public string? ImagePath { get; set; }
}
