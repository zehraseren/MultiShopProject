using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MS.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailImageSliderComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/ProductImages/ProductImagesByProductId?id={id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);
            return View(values);
        }
        return View();
    }
}