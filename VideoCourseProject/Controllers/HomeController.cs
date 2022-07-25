using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoCourseProject.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;

    public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
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