using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Areas.Admin.Models;
using VideoCourseProject.Interfaces;

namespace VideoCourseProject.Areas.Admin.Controllers;

[Area("Admin")]
public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public IActionResult Index()
    {
        var orders = _orderRepository.GetAll();
        return View(nameof(Index), orders);
    }

    public IActionResult Detail(Guid productId)
    {
        var order = _orderRepository.TryGetById(productId);
        return View(order);
    }

    public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
    {
        _orderRepository.UpdateStatus(orderId, status);
        return RedirectToAction(nameof(Index));
    }
}
