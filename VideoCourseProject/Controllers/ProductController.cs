using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductController(IProductRepository localProductRepository, IMapper mapper)
    {
        _productRepository = localProductRepository;
        _mapper = mapper;
    }

    public ViewResult Index(Guid productId)
    {
        var product = _productRepository.TryGetById(productId);
        var productForView = _mapper.Map<ProductViewModel>(product);
        return View(productForView);
    }
}
