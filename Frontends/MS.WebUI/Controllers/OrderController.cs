using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.Interfaces;
using MS.WebUI.Services.OrderServices;
using MS.UI.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MS.WebUI.Controllers;

public class OrderController : Controller
{
    private readonly IUserService _userService;
    private readonly IOrderAddressService _orderAddressService;

    public OrderController(IOrderAddressService orderAddressService, IUserService userService)
    {
        _userService = userService;
        _orderAddressService = orderAddressService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.directory1 = "MultiShop";
        ViewBag.directory2 = "Siparişler";
        ViewBag.directory3 = "Sipariş İşlemleri";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateOrderAddressDto coadto)
    {
        var user = await _userService.GetUserInfo();
        coadto.UserId = user.Id;

        await _orderAddressService.CreateOrderAddressAsync(coadto);

        return RedirectToAction("Index", "Payment");
    }
}
