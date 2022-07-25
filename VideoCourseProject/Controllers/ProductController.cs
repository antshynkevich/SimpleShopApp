using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository localProductRepository)
    {
        _productRepository = localProductRepository;
    }

    public ViewResult Index(Guid id)
    {
        var product = _productRepository.TryGetById(id);
        var productForView = new ProductViewModel()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Cost = product.Cost,
            ImagePath = product.ImagePath
        };

        return View(productForView);
    }
}
