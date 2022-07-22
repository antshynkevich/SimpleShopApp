using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class OrderController : Controller
{
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderController(ICartRepository cartRepository, IOrderRepository orderRepository)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Buy(UserDeliveryInfo user)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", user);
        }

        var cart = _cartRepository.TryGetByUserId(Constans.UserId);
        var order = new Order
        {
            User = user,
            Items = cart.Items
        };
        _orderRepository.Add(order);
        _cartRepository.Clear(Constans.UserId);
        return View();
    }
}
