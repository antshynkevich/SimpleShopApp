using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public HomeController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public ViewResult Index()
    {
        var products = _productRepository.GetAll();
        var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
        return View(productsViewModel);
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
