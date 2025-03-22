using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MS.UI.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MS.WebUI.Areas.Admin.Controllers;

[AllowAnonymous]
[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]

public class FeatureSliderController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FeatureSliderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
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

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7070/api/FeatureSliders");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsondata);
            return View(values);
        }

        return View();
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
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(cfsdto);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7070/api/FeatureSliders", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteFeatureSlider(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7070/api/FeatureSliders?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFeatureSlider(string id)
    {
        FeatureSliderViewBaglist();
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/FeatureSliders/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsondata);
            return View(value);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto ufsdto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(ufsdto);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7070/api/FeatureSliders", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
