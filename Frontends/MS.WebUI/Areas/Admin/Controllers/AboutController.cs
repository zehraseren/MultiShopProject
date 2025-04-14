using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.AboutDtos;
using MS.WebUI.Services.CatalogServices.AboutServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class AboutController : Controller
{
    private readonly IAboutService _aboutService;
    private readonly IHttpClientFactory _httpClientFactory;

    public AboutController(IHttpClientFactory httpClientFactory, IAboutService aboutService)
    {
        _aboutService = aboutService;
        _httpClientFactory = httpClientFactory;
    }

    void AboutViewbagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Hakkımda";
        ViewBag.v3 = "Hakkımda Listesi";
        ViewBag.v0 = "Hakkımda İşlemleri";
    }

    public async Task<IActionResult> Index()
    {
        AboutViewbagList();
        var result = await _aboutService.GetAllAboutAsync();
        return View(result);
    }

    [HttpGet]
    public IActionResult CreateAbout()
    {
        AboutViewbagList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutDto cadto)
    {
        await _aboutService.CreateAboutAsync(cadto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteAbout(string id)
    {
        await _aboutService.DeleteAboutAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateAbout(string id)
    {
        AboutViewbagList();
        var result = await _aboutService.GetByIdAboutAsync(id);
        var uadto = new UpdateAboutDto
        {
            AboutId = result.AboutId,
            Description = result.Description,
            Address = result.Address,
            Email = result.Email,
            Phone = result.Phone
        };
        return View(uadto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto uadto)
    {
        await _aboutService.UpdateAboutAsync(uadto);
        return RedirectToAction("Index");
    }
}
