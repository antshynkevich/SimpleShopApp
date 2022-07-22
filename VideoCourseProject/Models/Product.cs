using System.ComponentModel.DataAnnotations;

namespace VideoCourseProject.Models;

public class Product
{
    private static int _id;

    public Product()
    {
        Id = _id;
        _id++;
    }

    public Product(string name, decimal cost, string description, string imgPath) : this()
    {
        Name = name;
        Cost = cost;
        Description = description;
        ImagePath = imgPath;
    }

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Range(0, 1000000)] 
    [Required]
    public decimal Cost { get; set; }
    [Required]
    public string Description { get; set; }
    public string? ImagePath { get; set; }

    public override string ToString()
    {
        return new string($"{Id}\n{Name}\n{Cost}");
    }
}
