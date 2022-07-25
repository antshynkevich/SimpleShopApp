using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.db.Models;
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

        return View(nameof(Index), productVM);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(ProductViewModel productViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(productViewModel);
        }

        var product = new Product()
        {
            Id = productViewModel.Id,
            Name = productViewModel.Name,
            Description = productViewModel.Description,
            Cost = productViewModel.Cost
        };

        _productRepository.Add(product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(Guid id)
    {
        var product = _productRepository.TryGetById(id);
        var productForView = new ProductViewModel()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Cost = product.Cost
        };

        return View(productForView);
    }

    [HttpPost]
    public IActionResult Edit(ProductViewModel productViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(productViewModel);
        }

        var product = new Product()
        {
            Name = productViewModel.Name,
            Description = productViewModel.Description,
            Cost = productViewModel.Cost
        };

        _productRepository.Update(product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult DeleteProduct(Guid id)
    {
        _productRepository.Remove(id);
        return RedirectToAction(nameof(Index));
    }
}
