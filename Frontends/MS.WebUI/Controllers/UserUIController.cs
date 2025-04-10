using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.Interfaces;

namespace MS.WebUI.Controllers;

public class UserUIController : Controller
{
    private readonly IUserService _userService;

    public UserUIController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _userService.GetUserInfo();
        return View(result);
    }
}
