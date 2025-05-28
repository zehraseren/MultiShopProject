using Newtonsoft.Json;
using MS.RapidApiWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MS.RapidApiWebUI.Controllers;

public class ECommerceController : Controller
{
    public async Task<IActionResult> ECommerceList()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search-light-v2?q=logitech%20fare&country=tr&language=en&page=1&limit=10&sort_by=BEST_MATCH&product_condition=ANY&return_filters=false"),
            Headers =
    {
        { "x-rapidapi-key", "85e0067b92mshaad1b9d110ca2c4p1ffe7fjsn7fea82739ad4" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ECommerceViewModel.Rootobject>(body);
            return View(result.data.products.ToList());
        }
    }
}
