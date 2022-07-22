using Microsoft.AspNetCore.Mvc;

namespace VideoCourseProject.Controllers;

public class CartController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository localCartRepository, IProductRepository localProductRepository)
    {
        _cartRepository = localCartRepository;
        _productRepository = localProductRepository;
    }

    public IActionResult Index()
    {
        var cart = _cartRepository.TryGetByUserId(Constans.UserId);
        return View(cart);
    }

    public IActionResult Add(int id)
    {
        var product = _productRepository.TryGetById(id);
        _cartRepository.Add(product, Constans.UserId);
        return RedirectToAction("Index");
    }

    public IActionResult DecreaseAmount(Guid itemId)
    {
        _cartRepository.DecreaseAmount(itemId, Constans.UserId);
        return RedirectToAction("Index");
    }

    public IActionResult IncreaseAmount(Guid itemId)
    {
        _cartRepository.IncreaseAmount(itemId, Constans.UserId);
        return RedirectToAction("Index");
    }

    public IActionResult Clear()
    {
        _cartRepository.Clear(Constans.UserId);
        return RedirectToAction("Index");
    }
}
