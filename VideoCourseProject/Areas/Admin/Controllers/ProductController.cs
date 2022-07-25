using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        var products = _productRepository.GetAll();
        return View(nameof(Index), products);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        _productRepository.Add(product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var product = _productRepository.TryGetById(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        _productRepository.Update(product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult DeleteProduct(int id)
    {
        _productRepository.Remove(id);
        return RedirectToAction(nameof(Index));
    }
}
