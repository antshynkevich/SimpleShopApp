using Microsoft.AspNetCore.Mvc;
using VideoCourseProject.Interfaces;

namespace VideoCourseProject.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController : Controller
{
    private readonly IUsersManager _usersManager;
    public UserController(IUsersManager usersManager)
    {
        _usersManager = usersManager;
    }

    public IActionResult Index()
    {
        return View(_usersManager.GetAll());
    }

    public IActionResult Details(string name)
    {
        return View(_usersManager.TryGetByName(name));
    }

    public IActionResult ChangePassword()
    {
        throw new NotImplementedException();
    }

    public IActionResult EditUser()
    {
        throw new NotImplementedException();
    }

    public IActionResult EditUserRights()
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }
}
