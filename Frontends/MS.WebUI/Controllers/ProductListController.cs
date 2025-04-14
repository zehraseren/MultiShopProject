using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CommentDtos;

namespace MS.WebUI.Controllers;

public class ProductListController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductListController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index(string id)
    {
        ViewBag.directory1 = "Ana Sayfa";
        ViewBag.directory2 = "Ürünler";
        ViewBag.directory3 = "Ürün Listesi";

        ViewBag.i = id;
        return View();
    }

    public IActionResult ProductDetail(string id)
    {
        ViewBag.directory1 = "Ana Sayfa";
        ViewBag.directory2 = "Ürün Listesi";
        ViewBag.directory3 = "Ürün Detayları";

        ViewBag.id = id;
        return View();
    }

    [HttpGet]
    public PartialViewResult AddComment()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<bool> AddComment(CreateCommentDto ccdto)
    {
        ccdto.ImageUrl = "https://i.pinimg.com/236x/d0/9a/38/d09a38017048ec506b4564d5048352c1.jpg";
        ccdto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        ccdto.Status = true;

        var client = _httpClientFactory.CreateClient();
        var data = JsonConvert.SerializeObject(ccdto);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7075/api/Comments", content);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }
}
