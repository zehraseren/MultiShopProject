using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MS.WebUI.ViewComponents.DefaultViewComponents;

public class _SpecialOfferComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _SpecialOfferComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7070/api/SpecialOffers");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsondata);
            return View(values);
        }
        return View();
    }
}