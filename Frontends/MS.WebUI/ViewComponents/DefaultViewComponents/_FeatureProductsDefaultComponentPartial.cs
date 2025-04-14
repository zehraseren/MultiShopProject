using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.ProductServices;

namespace MS.WebUI.ViewComponents.DefaultViewComponents;

public class _FeatureProductsDefaultComponentPartial : ViewComponent
{
    private readonly IProductService _productService;

    public _FeatureProductsDefaultComponentPartial(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _productService.GetAllProductAsync();
        return View(result);
    }
}