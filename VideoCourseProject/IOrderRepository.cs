using VideoCourseProject.Areas.Admin.Models;
using VideoCourseProject.Models;

namespace VideoCourseProject
{
    public interface IOrderRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order? TryGetById(Guid id);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}
