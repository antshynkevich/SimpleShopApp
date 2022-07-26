using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class CartController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public CartController(ICartRepository localCartRepository, IProductRepository localProductRepository, IMapper mapper)
    {
        _cartRepository = localCartRepository;
        _productRepository = localProductRepository;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var cart = _cartRepository.TryGetByUserId(Constans.UserId);
        var cartForView = _mapper.Map<CartViewModel>(cart);
        return View(cartForView);
    }

    public IActionResult Add(Guid productId)
    {
        var product = _productRepository.TryGetById(productId);
        _cartRepository.Add(product, Constans.UserId);
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
