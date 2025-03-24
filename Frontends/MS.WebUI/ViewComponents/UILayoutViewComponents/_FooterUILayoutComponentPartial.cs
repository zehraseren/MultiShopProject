using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.AboutDtos;

namespace MS.WebUI.ViewComponents.UILayoutViewComponents;

public class _FooterUILayoutComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7070/api/Abouts");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsondata);
            return View(values);
        }
        return View();
    }
}