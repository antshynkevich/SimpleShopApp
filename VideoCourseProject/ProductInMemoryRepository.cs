using VideoCourseProject.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject;

public class ProductInMemoryRepository : IProductRepository
{
    private List<Product> _products = new()
    {
        new ("Name1", 10, "Desc1", "/images/img.webp"),
        new ("Name2", 20, "Desc2", "/images/img.webp"),
        new ("Name3", 30, "Desc3","/images/img.webp"),
        new ("Name4", 40, "Desc4", "/images/img.webp"),
    };

    public List<Product> GetAll()
    {
        return _products;
    }

    public Product? TryGetById(int id)
    {
        return _products.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Product product)
    {
        product.ImagePath = "/images/img.webp";
        _products.Add(product);
    }

    public void Update(Product product)
    {
        var existingProduct = _products.FirstOrDefault(x => x.Id == product.Id);
        if (existingProduct == null)
        {
            return;
        }

        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Cost = product.Cost;
        // existingProduct.ImagePath = product.ImagePath;
    }

    public void Remove(int id)
    {
        _products.RemoveAll(x => x.Id == id);
    }
}
