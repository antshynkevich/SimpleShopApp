using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Interfaces;

namespace VideoCourseProject.Views.Shared.Components.Cart;

public class CartViewComponent : ViewComponent
{
    private readonly ICartRepository _cartRepository;
    
    public CartViewComponent(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public IViewComponentResult Invoke()
    {
        var cart = _cartRepository.TryGetByUserId(Constans.UserId);
        var productCount = cart?.Amount ?? 0;

        return View("Cart", productCount);
    }
}