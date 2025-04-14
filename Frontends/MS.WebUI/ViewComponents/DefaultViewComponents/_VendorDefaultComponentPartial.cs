using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.BrandServices;

namespace MS.WebUI.ViewComponents.DefaultViewComponents;

public class _VendorDefaultComponentPartial : ViewComponent
{
    private readonly IBrandService _brandService;

    public _VendorDefaultComponentPartial(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _brandService.GetAllBrandAsync();
        return View(result);
    }
}