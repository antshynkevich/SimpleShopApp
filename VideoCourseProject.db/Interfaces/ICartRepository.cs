using VideoCourseProject.db.Models;

namespace VideoCourseProject.db.Interfaces;

public interface ICartRepository
{
    Cart? TryGetByUserId(string userId);
    void Add(Product product, string userId);
    void DecreaseAmount(Guid itemId, string userId);
    void IncreaseAmount(Guid itemId, string userId);
    void Clear(string userId);
}
