using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.BasketDtos;
using MS.WebUI.Services.BasketServices;
using MS.WebUI.Services.CatalogServices.ProductServices;

namespace MS.WebUI.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IBasketService _basketService;
    private readonly IProductService _productService;

    public ShoppingCartController(IBasketService basketService, IProductService productService)
    {
        _basketService = basketService;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.directory1 = "Ana Sayfa";
        ViewBag.directory2 = "Ürünler";
        ViewBag.directory3 = "Sepetim";

        var basket = await _basketService.GetBasket();
        ViewBag.total = basket?.TotalPrice ?? 0;

        var tax = (basket?.TotalPrice ?? 0) * 10 / 100;
        ViewBag.tax = tax;

        var totalPriceWithTax = (basket?.TotalPrice ?? 0) + tax;
        ViewBag.totalWithTax = totalPriceWithTax;

        return View(basket);
    }

    public async Task<IActionResult> AddBasketItem(string id)
    {
        var values = await _productService.GetByIdProductAsync(id);
        var items = new BasketItemDto
        {
            ProductId = values.ProductId,
            ProductName = values.ProductName,
            Quantity = 1,
            Price = values.ProductPrice,
            ProductImageUrl = values.ProductImageUrl
        };
        await _basketService.AddBasketItem(items);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveBasketItem(string id)
    {
        await _basketService.DeleteBasketItem(id);
        return RedirectToAction("Index");
    }
}
