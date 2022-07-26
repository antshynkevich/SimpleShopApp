using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.db.Models;
using VideoCourseProject.Models;

namespace VideoCourseProject.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var products = _mapper.Map<List<ProductViewModel>>(_productRepository.GetAll());
        return View(nameof(Index), products);
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

        var product = _mapper.Map<Product>(productViewModel);
        _productRepository.Add(product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(Guid productId)
    {
        var product = _productRepository.TryGetById(productId);
        var productForView = _mapper.Map<ProductViewModel>(product);
        return View(productForView);
    }

    [HttpPost]
    public IActionResult Edit(ProductViewModel productViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(productViewModel);
        }

        var product = _mapper.Map<Product>(productViewModel);
        _productRepository.Update(product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult DeleteProduct(Guid productId)
    {
        _productRepository.Remove(productId);
        return RedirectToAction(nameof(Index));
    }
}
