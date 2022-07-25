using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Extensions;
using VideoCourseProject.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject.Controllers;

public class AccountController : Controller
{
    private readonly IUsersManager _usersManager;

    public AccountController(IUsersManager usersManager)
    {
        _usersManager = usersManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Login login)
    {
        if (!ModelState.IsValid) return RedirectToAction(nameof(Login));
        var userAccount = _usersManager.TryGetByName(login.Username);
        if (userAccount == null)
        {
            ModelState.AddModelError("", "This user doesn't exist");
            return RedirectToAction(nameof(Login));
        }

        if (userAccount.Password != login.Password)
        {
            ModelState.AddModelError("", "Incorrect password");
        }

        return RedirectToAction(nameof(Index), nameof(HomeController).RemoveController());
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
            _usersManager.Add(new UserAccount
            {
                Name = register.Username,
                Password = register.Password,
                Phone = register.Phone
            });

            return RedirectToAction(nameof(Index), nameof(HomeController).RemoveController());
        }

        return RedirectToAction(nameof(Register));
    }
}
