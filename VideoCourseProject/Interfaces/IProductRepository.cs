using VideoCourseProject.Models;

namespace VideoCourseProject.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? TryGetById(int id);
    void Add(Product product);
    void Update(Product product);
    void Remove(int id);
}
