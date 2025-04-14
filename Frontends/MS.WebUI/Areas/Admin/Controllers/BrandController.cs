using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.BrandDtos;
using MS.WebUI.Services.CatalogServices.BrandServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class BrandController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IBrandService _brandService;

    public BrandController(IHttpClientFactory httpClientFactory, IBrandService brandService)
    {
        _httpClientFactory = httpClientFactory;
        _brandService = brandService;
    }

    void BrandViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Markalar";
        ViewBag.v3 = "Marka Listesi";
        ViewBag.v0 = "Marka İşlemleri";
    }

    public async Task<IActionResult> Index()
    {
        BrandViewBagList();
        var result = await _brandService.GetAllBrandAsync();
        return View(result);
    }

    [HttpGet]
    public IActionResult CreateBrand()
    {
        BrandViewBagList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto cbdto)
    {
        await _brandService.CreateBrandAsync(cbdto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrandAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBrand(string id)
    {
        BrandViewBagList();
        var result = await _brandService.GetByIdBrandAsync(id);
        var ubdto = new UpdateBrandDto
        {
            BrandId = result.BrandId,
            BrandName = result.BrandName,
            ImageUrl = result.ImageUrl
        };
        return View(ubdto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto ubdto)
    {
        await _brandService.UpdateBrandAsync(ubdto);
        return RedirectToAction("Index");
    }
}
