using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MS.UI.DtoLayer.CatalogDtos.AboutDtos;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/[controller]/[action]/{id?}")]
public class AboutController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AboutController(IHttpClientFactory httpClientFactory)
    {
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

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7070/api/Abouts");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsondata);
            return View(values);
        }
        return View();
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
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(cadto);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7070/api/Abouts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteAbout(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7070/api/Abouts?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateAbout(string id)
    {
        AboutViewbagList();
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/Abouts/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsondata);
            return View(value);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto uadto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(uadto);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7070/api/Abouts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
