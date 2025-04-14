using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MS.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class SpecialOfferController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ISpecialOfferService _specialOfferService;

    public SpecialOfferController(IHttpClientFactory httpClientFactory, ISpecialOfferService specialOfferService)
    {
        _httpClientFactory = httpClientFactory;
        _specialOfferService = specialOfferService;
    }

    void SpecialOfferViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Özel Teklifler";
        ViewBag.v3 = "Özel Teklif ve Günün İndirim Listesi";
        ViewBag.v0 = "Özel Teklif İşlemleri";
    }

    public async Task<IActionResult> Index()
    {
        SpecialOfferViewBagList();
        var result = await _specialOfferService.GetAllSpecialOfferAsync();
        return View(result);
    }

    [HttpGet]
    public IActionResult CreateSpecialOffer()
    {
        SpecialOfferViewBagList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto csodto)
    {
        await _specialOfferService.CreateSpecialOfferAsync(csodto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        await _specialOfferService.DeleteSpecialOfferAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateSpecialOffer(string id)
    {
        SpecialOfferViewBagList();
        var result = await _specialOfferService.GetByIdSpecialOfferAsync(id);
        var usodto = new UpdateSpecialOfferDto
        {
            SpecialOfferId = result.SpecialOfferId,
            Title = result.Title,
            SubTitle = result.SubTitle,
            ImageUrl = result.ImageUrl,
        };
        return View(usodto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto usodto)
    {
        await _specialOfferService.UpdateSpecialOfferAsync(usodto);
        return RedirectToAction("Index");
    }
}
