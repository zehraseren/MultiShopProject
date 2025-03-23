using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MS.UI.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/[controller]/[action]/{id?}")]
public class OfferDiscountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OfferDiscountController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
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

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7070/api/OfferDiscounts");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsondata);
            return View(values);
        }

        return View();
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
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(coddto);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7070/api/OfferDiscounts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteOfferDiscount(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7070/api/OfferDiscounts?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateOfferDiscount(string id)
    {
        OfferDiscountViewBagList();
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/OfferDiscounts/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsondata);
            return View(value);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto uoddto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(uoddto);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7070/api/OfferDiscounts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
