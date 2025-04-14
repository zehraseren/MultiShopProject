using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.FeatureDtos;
using MS.WebUI.Services.CatalogServices.FeatureServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class FeatureController : Controller
{
    private readonly IFeatureService _featureService;
    private readonly IHttpClientFactory _httpClientFactory;

    public FeatureController(IHttpClientFactory httpClientFactory, IFeatureService featureService)
    {
        _featureService = featureService;
        _httpClientFactory = httpClientFactory;
    }

    void FeatureViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Öne Çıkan Alanlar";
        ViewBag.v3 = "Öne Çıkan Alan Listesi";
        ViewBag.v0 = "Ana Sayfa Öne Çıkan Alan İşlemleri";
    }

    public async Task<IActionResult> Index()
    {
        FeatureViewBagList();
        var result = await _featureService.GetAllFeatureAsync();
        return View(result);
    }

    [HttpGet]
    public IActionResult CreateFeature()
    {
        FeatureViewBagList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto cfdto)
    {
        await _featureService.CreateFeatureAsync(cfdto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteFeature(string id)
    {
        await _featureService.DeleteFeatureAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFeature(string id)
    {
        FeatureViewBagList();
        var result = await _featureService.GetByIdFeatureAsync(id);
        var ufdto = new UpdateFeatureDto
        {
            FeatureId = result.FeatureId,
            Title = result.Title,
            Icon = result.Icon,
        };
        return View(ufdto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto ufdto)
    {
        await _featureService.UpdateFeatureAsync(ufdto);
        return RedirectToAction("Index");
    }
}
