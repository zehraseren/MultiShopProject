using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MS.UI.DtoLayer.CatalogDtos.ProductImageDtos;
using MS.WebUI.Services.CatalogServices.ProductImageServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/[controller]/[action]/{id?}")]
public class ProductImageController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IProductImageService _productImageService;

    public ProductImageController(IHttpClientFactory httpClientFactory, IProductImageService productImageService)
    {
        _httpClientFactory = httpClientFactory;
        _productImageService = productImageService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductImageDetail(string id)
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ürünler";
        ViewBag.v3 = "Ürün Görsel Güncelleme Sayfası";
        ViewBag.v0 = "Ürün Görsel İşlemleri";

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/ProductImages/ProductImagesByProductId?id={id}");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsondata);
            return View(values);
        }
        var emptyDto = new UpdateProductImageDto { ProductId = id };
        return View(emptyDto);
    }

    [HttpPost]
    public async Task<IActionResult> ProductImageDetail(CreateProductImageDto cpidto, UpdateProductImageDto upidto, string id)
    {
        cpidto.ProductId = id;
        upidto.ProductId = id;

        var client = _httpClientFactory.CreateClient();
        if (!ModelState.IsValid || string.IsNullOrEmpty(upidto.ProductImageId))
        {
            var createJsonData = JsonConvert.SerializeObject(cpidto);
            StringContent createContent = new StringContent(createJsonData, Encoding.UTF8, "application/json");
            var createResponse = await client.PostAsync("https://localhost:7070/api/ProductImages", createContent);
            if (createResponse.IsSuccessStatusCode)
                return RedirectToAction("ProductListWithCategory", "Product");
            return View(cpidto);
        }

        var updateJsonData = JsonConvert.SerializeObject(upidto);
        StringContent updateContent = new StringContent(updateJsonData, Encoding.UTF8, "application/json");
        var updateResponse = await client.PutAsync("https://localhost:7070/api/ProductImages", updateContent);
        if (updateResponse.IsSuccessStatusCode)
            return RedirectToAction("ProductListWithCategory", "Product");
        return View(upidto);
    }
}
