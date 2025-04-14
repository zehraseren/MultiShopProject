using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MS.WebUI.ViewComponents.DefaultViewComponents;

public class _OfferDiscountDefaultComponentPartial : ViewComponent
{
    private readonly IOfferDiscountService _offerDiscountService;

    public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
    {
        _offerDiscountService = offerDiscountService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _offerDiscountService.GetAllOfferDiscountAsync();
        return View(result);
    }
}