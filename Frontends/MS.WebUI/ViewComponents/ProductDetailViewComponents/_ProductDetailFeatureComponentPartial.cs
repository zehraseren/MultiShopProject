using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.ProductDtos;

namespace MS.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailFeatureComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductDetailFeatureComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/Products/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdProductDto>(jsonData);
            return View(value);
        }
        return View();
    }
}