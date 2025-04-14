using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.ProductServices;

namespace MS.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailFeatureComponentPartial : ViewComponent
{
    private readonly IProductService _productService;

    public _ProductDetailFeatureComponentPartial(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var result = await _productService.GetByIdProductAsync(id);
        return View(result);
    }
}