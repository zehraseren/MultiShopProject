using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.BasketDtos;
using MS.WebUI.Services.BasketServices;

namespace MS.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _ShoppingCartProductListComponentPartial : ViewComponent
{
    private readonly IBasketService _basketService;

    public _ShoppingCartProductListComponentPartial(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var basketTotal = await _basketService.GetBasket();
        var basketItems = basketTotal?.BasketItems ?? new List<BasketItemDto>();
        return View(basketItems);
    }
}
