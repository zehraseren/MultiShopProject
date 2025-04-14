using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.ProductDetailServices;

namespace MS.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailInformationComponentPartial : ViewComponent
{
    private readonly IProductDetailService _productDetailService;

    public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var result = await _productDetailService.GetProductDetailByProductIdAsync(id);
        return View(result);
    }
}