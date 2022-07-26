using VideoCourseProject.db.Interfaces;
using VideoCourseProject.db.Models;

namespace VideoCourseProject.db.Repositories;

public class ProductsDbRepository : IProductRepository
{
    private readonly DatabaseContext _databaseContext;

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
