using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Interfaces;

namespace VideoCourseProject.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository localProductRepository)
    {
        _productRepository = localProductRepository;
    }

    public ViewResult Index(int id)
    {
        var product = _productRepository.TryGetById(id);
        return View(product);
    }
}
