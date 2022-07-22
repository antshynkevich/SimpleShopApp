using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class AdminController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public AdminController(IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public IActionResult Orders()
    {
        var orders = _orderRepository.GetAll();
        return View();
    }

    public IActionResult Users()
    {
        return View();
    }

    public IActionResult Roles()
    {
        return View();
    }

    public IActionResult Products()
    {
        var products = _productRepository.GetAll();
        return View(products);
    }

    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        _productRepository.Add(product);
        return RedirectToAction("Products");
    }

    public IActionResult EditProduct(int id)
    {
        var product = _productRepository.TryGetById(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult EditProduct(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        _productRepository.Update(product);
        return RedirectToAction("Products");
    }

    public IActionResult DeleteProduct()
    {
        throw new NotImplementedException();
    }
}
