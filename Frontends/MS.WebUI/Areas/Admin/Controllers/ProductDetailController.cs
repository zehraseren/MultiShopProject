using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MS.UI.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/[controller]/[action]/{id?}")]
public class ProductDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductDetailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> AddOrUpdateProductDetail(string id)
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ürünler";
        ViewBag.v3 = "Ürün Açıklama ve Bilgi Güncelleme Sayfası";
        ViewBag.v0 = "Ürün İşlemleri";

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/ProductDetails/GetProductDetailByProductId/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsondata);
            return View(values);
        }

        var emptyDto = new UpdateProductDetailDto { ProductId = id };
        return View(emptyDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrUpdateProductDetail(CreateProductDetailDto cpddto, UpdateProductDetailDto upddto, string id)
    {
        cpddto.ProductId = id;
        upddto.ProductId = id;

        var client = _httpClientFactory.CreateClient();

        if (!ModelState.IsValid || string.IsNullOrEmpty(upddto.ProductDetailId))
        {
            var createJsonData = JsonConvert.SerializeObject(cpddto);
            StringContent createContent = new StringContent(createJsonData, Encoding.UTF8, "application/json");
            var createResponse = await client.PostAsync("https://localhost:7070/api/ProductDetails", createContent);
            if (createResponse.IsSuccessStatusCode)
                return RedirectToAction("ProductListWithCategory", "Product");

            return View(cpddto);
        }

        var updateJsonData = JsonConvert.SerializeObject(upddto);
        StringContent updateContent = new StringContent(updateJsonData, Encoding.UTF8, "application/json");
        var updateResponse = await client.PutAsync("https://localhost:7070/api/ProductDetails", updateContent);
        if (updateResponse.IsSuccessStatusCode)
            return RedirectToAction("ProductListWithCategory", "Product");

        return View(upddto);
    }
}
