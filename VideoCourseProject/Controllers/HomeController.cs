using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoCourseProject.db.Interfaces;
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
        var productVM = new List<ProductViewModel>();
        foreach (var product in products)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
            
            productVM.Add(productViewModel);
        }
        return View(productVM);
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