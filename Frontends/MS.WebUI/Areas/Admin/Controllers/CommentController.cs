using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using MS.UI.DtoLayer.CatalogDtos.ProductDtos;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/[controller]/[action]/{id?}")]
public class CommentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CommentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    void CommentViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Yorumlar";
        ViewBag.v3 = "Yorum Listesi";
        ViewBag.v0 = "Yorum İşlemleri";
    }

    public async Task<IActionResult> Index()
    {
        CommentViewBagList();

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7075/api/Comments");
        if (!response.IsSuccessStatusCode)
        {
            return View();
        }

        // Comments
        var data = await response.Content.ReadAsStringAsync();
        var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(data);

        // ProductName
        var productResponse = await client.GetAsync("https://localhost:7070/api/Products");
        if (!productResponse.IsSuccessStatusCode)
        {
            return View(comments);
        }

        var productData = await productResponse.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productData);

        // Matching ProductName
        foreach (var comment in comments)
        {
            var matchedProduct = products.FirstOrDefault(x => x.ProductId == comment.ProductId);
            if (matchedProduct != null)
            {
                comment.ProductName = matchedProduct.ProductName;
            }
        }

        return View(comments);
    }

    public async Task<IActionResult> DeleteComment(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7075/api/Comments/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateComment(string id)
    {
        CommentViewBagList();

        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"https://localhost:7075/api/Comments/{id}");
        if (response.IsSuccessStatusCode)
        {
            // Comments
            var data = await response.Content.ReadAsStringAsync();
            var comment = JsonConvert.DeserializeObject<UpdateCommentDto>(data);

            // ProductName
            var productResponse = await client.GetAsync($"https://localhost:7070/api/Products/{comment.ProductId}");
            if (productResponse.IsSuccessStatusCode)
            {
                var productData = await productResponse.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<GetByIdProductDto>(productData);
                ViewBag.ProductName = product.ProductName;
            }
            return View(comment);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateComment(UpdateCommentDto ucdto)
    {
        ucdto.Status = true;
        var client = _httpClientFactory.CreateClient();
        var data = JsonConvert.SerializeObject(ucdto);
        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7075/api/Comments", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
