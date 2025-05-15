namespace MS.WebUI.Services.StatisticServices.CatalogStatisticServices;

public class CatalogStatisticService : ICatalogStatisticService
{
    private readonly HttpClient _httpClient;

    public CatalogStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<long> GetBrandCount()
    {
        var response = await _httpClient.GetAsync("Statistics/GetBrandCount");
        var result = await response.Content.ReadFromJsonAsync<long>();
        return result;
    }

    public async Task<long> GetCategoryCount()
    {
        var response = await _httpClient.GetAsync("Statistics/GetCategoryCount");
        var result = await response.Content.ReadFromJsonAsync<long>();
        return result;
    }

    public async Task<string> GetMaxPriceProductName()
    {
        var response = await _httpClient.GetAsync("Statistics/GetMaxPriceProductName");
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }

    public async Task<string> GetMinPriceProductName()
    {
        var response = await _httpClient.GetAsync("Statistics/GetMinPriceProductName");
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }

    public async Task<decimal> GetProductAvgPrice()
    {
        var response = await _httpClient.GetAsync("Statistics/GetProductAvgPrice");
        var result = await response.Content.ReadFromJsonAsync<decimal>();
        return result;
    }

    public async Task<long> GetProductCount()
    {
        var response = await _httpClient.GetAsync("Statistics/GetProductCount");
        var result = await response.Content.ReadFromJsonAsync<long>();
        return result;
    }
}
