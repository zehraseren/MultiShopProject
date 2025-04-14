using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MS.WebUI.ViewComponents.DefaultViewComponents;

public class _SpecialOfferComponentPartial : ViewComponent
{
    private readonly ISpecialOfferService _specialOfferService;

    public _SpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
    {
        _specialOfferService = specialOfferService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _specialOfferService.GetAllSpecialOfferAsync();
        return View(result);
    }
}