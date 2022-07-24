using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Login login)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction(nameof(Index), "Home");
        }

        return RedirectToAction(nameof(Login));
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Register register)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction(nameof(Index), "Home");
        }

        return RedirectToAction(nameof(Register));
    }
}
