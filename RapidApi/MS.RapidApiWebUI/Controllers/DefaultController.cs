using Newtonsoft.Json;
using MS.RapidApiWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MS.RapidApiWebUI.Controllers;

public class DefaultController : Controller
{
    public async Task<IActionResult> WeatherDetail()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/ankara"),
            Headers =
    {
        { "x-rapidapi-key", "85e0067b92mshaad1b9d110ca2c4p1ffe7fjsn7fea82739ad4" },
        { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
            ViewBag.cityTemp = result.data.temp;
            return View();
        }
    }

    public async Task<IActionResult> Exchange()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
            Headers =
    {
        { "x-rapidapi-key", "85e0067b92mshaad1b9d110ca2c4p1ffe7fjsn7fea82739ad4" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
            ViewBag.usdExchangeRate = result.data.exchange_rate;
            ViewBag.usdPreviousClose = result.data.previous_close;
        }

        var client2 = new HttpClient();
        var request2 = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en"),
            Headers =
    {
        { "x-rapidapi-key", "85e0067b92mshaad1b9d110ca2c4p1ffe7fjsn7fea82739ad4" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
        };
        using (var response2 = await client2.SendAsync(request2))
        {
            response2.EnsureSuccessStatusCode();
            var body2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body2);
            ViewBag.eurExchangeRate = result2.data.exchange_rate;
            ViewBag.eurPreviousClose = result2.data.previous_close;
        }
        return View();
    }
}
