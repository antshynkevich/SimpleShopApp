using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.Interfaces;
using VideoCourseProject.Models;

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

    public IActionResult Add(Guid id)
    {
        var product = _productRepository.TryGetById(id);
        var productForView = new ProductViewModel()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Cost = product.Cost
        };

        _cartRepository.Add(productForView, Constans.UserId);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult DecreaseAmount(Guid itemId)
    {
        _cartRepository.DecreaseAmount(itemId, Constans.UserId);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult IncreaseAmount(Guid itemId)
    {
        _cartRepository.IncreaseAmount(itemId, Constans.UserId);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Clear()
    {
        _cartRepository.Clear(Constans.UserId);
        return RedirectToAction(nameof(Index));
    }
}
