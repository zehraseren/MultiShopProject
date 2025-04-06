using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.CategoryDtos;

namespace MS.WebUI.Controllers;

public class TestController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TestController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        string token = "";
        using (var httpClient = new HttpClient())
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:5001/connect/token"),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"client_id", "MultiShopVisitorId" },
                    { "client_secret", "multishopvisitorsecret" },
                    { "grant_type", "client_credentials" }
                })
            };

            using (var response1 = await httpClient.SendAsync(request))
            {
                if (response1.IsSuccessStatusCode)
                {
                    var tokenResponse = await response1.Content.ReadAsStringAsync();
                    var tokenData = JsonConvert.DeserializeObject<Dictionary<string, string>>(tokenResponse);
                    token = tokenData["access_token"].ToString();
                }
            }
        }

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7070/api/Categories");
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(data);
            return View(values);
        }
        return View();
    }
}
