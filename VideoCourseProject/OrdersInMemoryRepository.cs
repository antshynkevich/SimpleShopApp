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
}
