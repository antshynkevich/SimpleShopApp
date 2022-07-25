using VideoCourseProject.db.Interfaces;
using VideoCourseProject.db.Models;

namespace VideoCourseProject.db.Repositories;

public class ProductsDbRepository : IProductRepository
{
    private readonly DatabaseContext _databaseContext;

    //private List<Product> _products = new()
    //{
    //    new ("Name1", 10, "Desc1", "/images/img.webp"),
    //    new ("Name2", 20, "Desc2", "/images/img.webp"),
    //    new ("Name3", 30, "Desc3","/images/img.webp"),
    //    new ("Name4", 40, "Desc4", "/images/img.webp"),
    //};

    public ProductsDbRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public List<Product> GetAll()
    {
        return _databaseContext.Products.ToList();
    }

    public Product? TryGetById(Guid id)
    {
        return _databaseContext.Products.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Product product)
    {
        product.ImagePath = "/images/img.webp";
        _databaseContext.Products.Add(product);
        _databaseContext.SaveChanges();
    }

    public void Update(Product product)
    {
        var existingProduct = _databaseContext.Products.FirstOrDefault(x => x.Id == product.Id);
        if (existingProduct == null)
        {
            return;
        }

        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Cost = product.Cost;
        // existingProduct.ImagePath = product.ImagePath;
        _databaseContext.SaveChanges();
    }

    public void Remove(Guid id)
    {
        var product = _databaseContext.Products.FirstOrDefault(x => x.Id == id);
        if (product != null) _databaseContext.Products.Remove(product);
        _databaseContext.SaveChanges();
    }
}
