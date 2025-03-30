using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.ContactDtos;

namespace MS.WebUI.Controllers;

public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ContactController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    void ContactViewbagList()
    {
        ViewBag.v1 = "MultiShop";
        ViewBag.v2 = "İletişim";
        ViewBag.v3 = "Mesaj Gönder";
    }

    [HttpGet]
    public IActionResult Index()
    {
        ContactViewbagList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto ccdto)
    {
        var client = _httpClientFactory.CreateClient();
        var data = JsonConvert.SerializeObject(ccdto);
        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7070/api/Contacts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }
        return View();
    }
}
