using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.UserIdentityServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class UserController : Controller
{
    private readonly IUserIdentityService _userIdentityService;

    public UserController(IUserIdentityService userIdentityService)
    {
        _userIdentityService = userIdentityService;
    }

    public async Task<IActionResult> UserList()
    {
        var result = await _userIdentityService.GetAllUserListAsync();
        return View(result);
    }
}
