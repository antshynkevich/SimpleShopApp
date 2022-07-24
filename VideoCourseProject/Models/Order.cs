using VideoCourseProject.Areas.Admin.Models;

namespace VideoCourseProject.Models;

public class Order
{
    public Guid Id { get; set; }
    public UserDeliveryInfo User { get; set; }
    public List<CartItem> Items { get; set; }
    public DateTime CreateTime { get; set; }
    public OrderStatus Status { get; set; }

    public Order()
    {
        Id = Guid.NewGuid();
        CreateTime = DateTime.Now;
    }

    public decimal Cost => Items?.Sum(x => x.Cost) ?? 0;
}
