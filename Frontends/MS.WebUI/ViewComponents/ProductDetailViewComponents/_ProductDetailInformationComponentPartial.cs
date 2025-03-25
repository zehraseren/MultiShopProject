using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MS.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailInformationComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductDetailInformationComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/ProductDetails/GetProductDetailByProductId/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
            return View(values);
        }
        return View();
    }
}