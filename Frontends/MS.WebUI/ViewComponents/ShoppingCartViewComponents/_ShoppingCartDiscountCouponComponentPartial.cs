using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.BasketServices;
using MS.WebUI.Services.DiscountServices;

namespace MS.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
{
    private readonly IBasketService _basketService;
    private readonly IDiscountService _discountService;

    public _ShoppingCartDiscountCouponComponentPartial(IDiscountService discountService, IBasketService basketService)
    {
        _discountService = discountService;
        _basketService = basketService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string code, int? coupon, decimal? totalWithCoupon)
    {
        var basket = await _basketService.GetBasket();
        var total = basket?.TotalPrice ?? 0;
        ViewBag.total = total;
        var tax = total * 10 / 100;
        ViewBag.tax = tax;
        var totalWithTax = total + tax;
        ViewBag.totalWithTax = totalWithTax;

        ViewBag.code = code;
        ViewBag.coupon = coupon;
        ViewBag.totalWithCoupon = totalWithCoupon;
        return View();
    }
}