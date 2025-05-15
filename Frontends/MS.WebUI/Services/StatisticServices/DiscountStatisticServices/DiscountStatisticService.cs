namespace MS.WebUI.Services.StatisticServices.DiscountStatisticServices;

public class DiscountStatisticService : IDiscountStatisticService
{
    private readonly HttpClient _httpClient;

    public DiscountStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetDiscountCouponCount()
    {
        var response = await _httpClient.GetAsync("Discounts/GetTotalDiscountCouponCount");
        var result = await response.Content.ReadFromJsonAsync<int>();
        return result;
    }
}
