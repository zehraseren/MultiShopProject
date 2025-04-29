using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.Interfaces;
using MS.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MS.WebUI.Areas.User.Controllers;

[Area("User")]
[Route("User/[controller]/[action]/{id?}")]
public class MyOrderController : Controller
{
    private readonly IUserService _userService;
    private readonly IOrderOrderingService _orderOrderingService;

    public MyOrderController(IUserService userService, IOrderOrderingService orderOrderingService)
    {
        _userService = userService;
        _orderOrderingService = orderOrderingService;
    }

    void MyOrderViewBagList()
    {
        ViewBag.directory1 = "MultiShop";
        ViewBag.directory2 = "Kullanıcı Paneli";
        ViewBag.directory3 = "Siparişlerim";
        ViewBag.directory0 = "";
    }

    public async Task<IActionResult> MyOrderList()
    {
        MyOrderViewBagList();

        var user = await _userService.GetUserInfo();
        var result = await _orderOrderingService.GetOrderingByUserId(user.Id);
        return View(result);
    }
}
