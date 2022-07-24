using VideoCourseProject.Areas.Admin.Models;
using VideoCourseProject.Models;

namespace VideoCourseProject;

public class OrdersInMemoryRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public List<Order> GetAll()
    {
        return _orders;
    }

    public Order? TryGetById(Guid id)
    {
        return _orders?.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateStatus(Guid orderId, OrderStatus newStatus)
    {
        var order = TryGetById(orderId);
        if (order != null)
        {
            order.Status = newStatus;
        }
    }
}
