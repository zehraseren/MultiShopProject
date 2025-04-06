using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.CategoryDtos;

namespace MS.WebUI.ViewComponents.UILayoutViewComponents;

public class _NavbarUILayoutComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _NavbarUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        string token = "";

        // HttpClient ile token alma işlemi yapılır
        using (var httpClient = new HttpClient())
        {
            // Token endpointine yapılacak istek ayarlanır
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:5001/connect/token"), // IdentityServer token endpointi
                Method = HttpMethod.Post, // HTTP POST metodu kullanılacak
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", "MultiShopVisitorId" }, // Kimlik doğrulama için client_id
                    { "client_secret", "multishopvisitorsecret" }, // Kimlik doğrulama için client_secret
                    { "grant_type", "client_credentials" } // Client Credentials grant tipi kullanılıyor
                })
            };

            // Token isteği gönderilir
            using (var response1 = await httpClient.SendAsync(request))
            {
                // Eğer istek başarılı ise
                if (response1.IsSuccessStatusCode)
                {
                    // Gelen yanıt okunur
                    var tokenResponse = await response1.Content.ReadAsStringAsync();
                    // JSON string dictionary nesnesine çevrilir
                    var tokenData = JObject.Parse(tokenResponse);
                    // access_token 
                    token = tokenData["access_token"].ToString();
                }
            }
        }

        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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