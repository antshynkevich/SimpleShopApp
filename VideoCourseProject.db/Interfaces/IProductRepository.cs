using VideoCourseProject.db.Models;

namespace VideoCourseProject.db.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? TryGetById(Guid id);
    void Add(Product product);
    void Update(Product product);
    void Remove(Guid id);
}
