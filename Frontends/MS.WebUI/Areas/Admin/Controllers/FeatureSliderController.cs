using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MS.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]

public class FeatureSliderController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IFeatureSliderService _featureSliderService;

    public FeatureSliderController(IHttpClientFactory httpClientFactory, IFeatureSliderService featureSliderService)
    {
        _httpClientFactory = httpClientFactory;
        _featureSliderService = featureSliderService;
    }

    void FeatureSliderViewBaglist()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Öne Çıkan Görseller";
        ViewBag.v3 = "Öne Çıkan Görsel Listesi";
        ViewBag.v0 = "Öne Çıkan Görsel İşlemleri";
    }

    public async Task<IActionResult> Index()
    {
        FeatureSliderViewBaglist();
        var result = await _featureSliderService.GetAllFeatureSliderAsync();
        return View(result);
    }

    [HttpGet]
    public IActionResult CreateFeatureSlider()
    {
        FeatureSliderViewBaglist();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto cfsdto)
    {
        await _featureSliderService.CreateFeatureSliderAsync(cfsdto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteFeatureSlider(string id)
    {
        await _featureSliderService.DeleteFeatureSliderAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFeatureSlider(string id)
    {
        FeatureSliderViewBaglist();
        var result = await _featureSliderService.GetByIdFeatureSliderAsync(id);
        var ufsdto = new UpdateFeatureSliderDto
        {
            FeatureSliderId = result.FeatureSliderId,
            Title = result.Title,
            Description = result.Description,
            ImageUrl = result.ImageUrl,
            Status = result.Status,
        };
        return View(ufsdto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto ufsdto)
    {
        await _featureSliderService.UpdateFeatureSliderAsync(ufsdto);
        return RedirectToAction("Index");
    }
}
