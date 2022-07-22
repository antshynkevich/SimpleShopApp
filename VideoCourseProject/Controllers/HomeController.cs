using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICartRepository _cartRepository;

    public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICartRepository cartRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
        _cartRepository = cartRepository;
    }

    private readonly ILogger<HomeController> _logger;

 
    public ViewResult Index()
    {
        var products = _productRepository.GetAll();
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}