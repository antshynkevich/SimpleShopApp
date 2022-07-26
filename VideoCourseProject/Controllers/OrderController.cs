using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class OrderController : Controller
{
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderController(ICartRepository cartRepository, IOrderRepository orderRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
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
            return View(nameof(Index), user);
        }

        var cart = _cartRepository.TryGetByUserId(Constans.UserId);
        // TODO : delete this mapping
        var cartView = _mapper.Map<CartViewModel>(cart);
        var order = new Order
        {
            User = user,
            Items = cartView.Items
        };
        _orderRepository.Add(order);
        _cartRepository.Clear(Constans.UserId);
        return View();
    }
}
