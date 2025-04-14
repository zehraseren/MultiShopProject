using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.ProductImageServices;

namespace MS.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailImageSliderComponentPartial : ViewComponent
{
    private readonly IProductImageService _productImageService;

    public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
    {
        _productImageService = productImageService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var result = await _productImageService.GetProductImagesByProductIdAsync(id);
        return View(result);
    }
}