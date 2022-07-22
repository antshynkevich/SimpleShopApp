using VideoCourseProject.Models;

namespace VideoCourseProject;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? TryGetById(int id);
    void Add(Product product);
    void Update(Product product);
}
