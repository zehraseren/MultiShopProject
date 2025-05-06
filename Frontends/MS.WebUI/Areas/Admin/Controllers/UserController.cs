using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.UserIdentityServices;
using MS.WebUI.Services.CargoServices.CargoCustomerServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class UserController : Controller
{
    private readonly IUserIdentityService _userIdentityService;
    private readonly ICargoCustomerService _cargoCustomerService;

    public UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService)
    {
        _userIdentityService = userIdentityService;
        _cargoCustomerService = cargoCustomerService;
    }

    public async Task<IActionResult> UserList()
    {
        var result = await _userIdentityService.GetAllUserListAsync();
        return View(result);
    }

    public async Task<IActionResult> UserAddressInfo(string id)
    {
        var result = await _cargoCustomerService.GetByIdCargoCustomerInfoAsync(id);
        return View(result);
    }
}
