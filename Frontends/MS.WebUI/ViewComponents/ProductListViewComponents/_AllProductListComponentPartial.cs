using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.ProductServices;

namespace MS.WebUI.ViewComponents.ProductListViewComponents;

public class _AllProductListComponentPartial : ViewComponent
{
    private readonly IProductService _productService;

    public _AllProductListComponentPartial(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var products = await _productService.GetAllProductAsync();
        return View(products);
    }
}
