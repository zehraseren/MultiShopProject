using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MS.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class OfferDiscountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOfferDiscountService _offerDiscountService;

    public OfferDiscountController(IHttpClientFactory httpClientFactory, IOfferDiscountService offerDiscountService)
    {
        _httpClientFactory = httpClientFactory;
        _offerDiscountService = offerDiscountService;
    }

    void OfferDiscountViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Özel Teklifleri";
        ViewBag.v3 = "Özel Teklif Listesi";
        ViewBag.v0 = "Özel Teklif İşlemleri";
    }

    public async Task<IActionResult> Index()
    {
        OfferDiscountViewBagList();
        var result = await _offerDiscountService.GetAllOfferDiscountAsync();
        return View(result);
    }

    [HttpGet]
    public IActionResult CreateOfferDiscount()
    {
        OfferDiscountViewBagList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto coddto)
    {
        await _offerDiscountService.CreateOfferDiscountAsync(coddto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteOfferDiscount(string id)
    {
        await _offerDiscountService.DeleteOfferDiscountAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateOfferDiscount(string id)
    {
        OfferDiscountViewBagList();
        var result = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
        var uoddto = new UpdateOfferDiscountDto
        {
            OfferDiscountId = result.OfferDiscountId,
            Title = result.Title,
            SubTitle = result.SubTitle,
            ImageUrl = result.ImageUrl,
            ButtonTitle = result.ButtonTitle
        };
        return View(uoddto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto uoddto)
    {
        await _offerDiscountService.UpdateOfferDiscountAsync(uoddto);
        return RedirectToAction("Index");
    }
}
