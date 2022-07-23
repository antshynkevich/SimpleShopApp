﻿using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class AdminController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IRolesRepository _rolesRepository;

    public AdminController(IProductRepository productRepository, IOrderRepository orderRepository, IRolesRepository rolesRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _rolesRepository = rolesRepository;
    }

    public IActionResult Orders()
    {
        var orders = _orderRepository.GetAll();
        return View(orders);
    }

    public IActionResult Users()
    {
        return View();
    }

    public IActionResult Roles()
    {
        var roles = _rolesRepository.GetAll();
        return View(roles);
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

    public IActionResult OrderDetails(Guid id)
    {
        var order = _orderRepository.TryGetById(id);
        return View(order);
    }

    public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
    {
        _orderRepository.UpdateStatus(orderId, status);
        return RedirectToAction("Orders");
    }

    public IActionResult RemoveRole(string roleName)
    {
        _rolesRepository.Remove(roleName);
        return RedirectToAction("Roles");
    }

    public IActionResult AddRole()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddRole(Role role)
    {
        if (_rolesRepository?.TryGetByName(role.Name) != null)
        {
            ModelState.AddModelError("","This role exists");
        }

        if (ModelState.IsValid)
        {
            _rolesRepository?.Add(role);
            return RedirectToAction("Roles");
        }

        return View(role);
    }
}
