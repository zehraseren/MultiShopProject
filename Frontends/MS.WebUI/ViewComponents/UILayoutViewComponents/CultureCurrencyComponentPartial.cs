using MS.WebUI.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.ViewComponents.UILayoutViewComponents;

public class CultureCurrencyComponentPartial : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        //var client = new HttpClient();
        //var requestUsd = new HttpRequestMessage
        //{
        //    Method = HttpMethod.Get,
        //        RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
        //        Headers =
        //{
        //        { "x-rapidapi-key", "85e0067b92mshaad1b9d110ca2c4p1ffe7fjsn7fea82739ad4" },
        //    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
        //},
        //    }
        //;
        //using (var response = await client.SendAsync(requestUsd))
        //{
        //    response.EnsureSuccessStatusCode();
        //    var body = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
        //    ViewBag.usdBuy = result.data.exchange_rate;
        //    ViewBag.usdSell = result.data.previous_close;
        //}

        //var requestEur = new HttpRequestMessage
        //{
        //    Method = HttpMethod.Get,
        //    RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en"),
        //    Headers =
        //{
        //    { "x-rapidapi-key", "85e0067b92mshaad1b9d110ca2c4p1ffe7fjsn7fea82739ad4" },
        //    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
        //},
        //};
        //using (var response = await client.SendAsync(requestEur))
        //{
        //    response.EnsureSuccessStatusCode();
        //    var body = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
        //    ViewBag.eurBuy = result.data.exchange_rate;
        //    ViewBag.eurSell = result.data.previous_close;
        //}

        return View();
    }
}