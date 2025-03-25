using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.ProductDtos;
using MS.UI.DtoLayer.CatalogDtos.CategoryDtos;

namespace MS.WebUI.ViewComponents.ProductListViewComponents;

public class _ProductListComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var client = _httpClientFactory.CreateClient();
        if (string.IsNullOrEmpty(id))
        {
            var response = await client.GetAsync("https://localhost:7070/api/Products");
            if (!response.IsSuccessStatusCode)
                return View();

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return View(values);
        }


        var categoryResponse = await client.GetAsync($"https://localhost:7070/api/Categories/{id}");
        if (!categoryResponse.IsSuccessStatusCode)
            return View();

        var categoryJsonData = await categoryResponse.Content.ReadAsStringAsync();
        var category = JsonConvert.DeserializeObject<ResultCategoryDto>(categoryJsonData);

        var productResponse = await client.GetAsync($"https://localhost:7070/api/Products/GetProductsWithCategoryByCategoryId/{id}");
        if (!productResponse.IsSuccessStatusCode)
            return View();

        var productJsonData = await productResponse.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(productJsonData);

        ViewBag.cn = products.Any()
            ? $"{category.CategoryName} Kategorisindeki Ürünler"
            : $"{category.CategoryName} kategorisinde ürün yok.";

        return View(products);
    }
}