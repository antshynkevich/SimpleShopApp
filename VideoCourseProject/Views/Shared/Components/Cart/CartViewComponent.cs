using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject.Views.Shared.Components.Cart;

public class CartViewComponent : ViewComponent
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    
    public CartViewComponent(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public IViewComponentResult Invoke()
    {
        var cart = _cartRepository.TryGetByUserId(Constans.UserId);
        var cartViewModel = _mapper.Map<CartViewModel>(cart);
        var productCount = cartViewModel?.Amount ?? 0;
        return View("Cart", productCount);
    }
}
