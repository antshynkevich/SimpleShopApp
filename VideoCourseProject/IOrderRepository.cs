using VideoCourseProject.Models;

namespace VideoCourseProject
{
    public interface IOrderRepository
    {
        void Add(Order order);
        List<Order> GetAll();
    }
}