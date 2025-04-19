using MS.Basket.Dtos;
using MS.Basket.Services;
using MS.Basket.LoginServices;
using Microsoft.AspNetCore.Mvc;

namespace MS.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BasketsController : ControllerBase
{
    private readonly ILoginService _loginService;
    private readonly IBasketService _basketService;

    public BasketsController(ILoginService loginService, IBasketService basketService)
    {
        _loginService = loginService;
        _basketService = basketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBasketDetail()
    {
        var userId = _loginService.GetUserId;
        var values = await _basketService.GetBasket(userId);

        if (values == null)
            return NotFound("Sepet bulunamadı"); // 👈 404 dönsün

        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> SaveMyBasket(BasketTotalDto btdto)
    {
        btdto.UserId = _loginService.GetUserId;
        await _basketService.SaveBasket(btdto);
        return Ok("Sepetteki değişiklikler kaydedildi.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBasket()
    {
        await _basketService.RemoveBasket(_loginService.GetUserId);
        return Ok("Sepet başarıyla silindi.");
    }
}
