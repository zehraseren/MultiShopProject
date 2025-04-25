using MS.UI.DtoLayer.DiscountDtos;

namespace MS.WebUI.Services.DiscountServices;

public class DiscountService : IDiscountService
{
    private readonly HttpClient _httpClient;

    public DiscountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetDiscountCodeDetailByCodeDto> GetDiscountCode(string code)
    {
        var response = await _httpClient.GetAsync($"discounts/GetCodeDetailByCodeAsync/{code}");
        var result = await response.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCodeDto>();
        return result;
    }

    public async Task<int> GetDiscountCouponRate(string code)
    {
        var response = await _httpClient.GetAsync($"discounts/GetDiscountCouponRate?code={code}");
        var result = await response.Content.ReadFromJsonAsync<int>();
        return result;
    }
}