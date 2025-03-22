using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MS.UI.DtoLayer.CatalogDtos.FeatureDtos;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/[controller]/[action]/{id?}")]
public class FeatureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FeatureController(IHttpClientFactory httpClientFactory)
    {
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

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7070/api/Features");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsondata);
            return View(values);
        }

        return View();
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
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(cfdto);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7070/api/Features", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteFeature(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7070/api/Features?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFeature(string id)
    {
        FeatureViewBagList();
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/Features/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsondata);
            return View(value);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto ufdto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(ufdto);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7070/api/Features", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
