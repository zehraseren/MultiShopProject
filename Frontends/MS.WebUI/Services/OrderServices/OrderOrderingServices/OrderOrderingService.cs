using Newtonsoft.Json;
using MS.UI.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MS.WebUI.Services.OrderServices.OrderOrderingServices;

public class OrderOrderingService : IOrderOrderingService
{
    private readonly HttpClient _httpClient;

    public OrderOrderingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
    {
        var response = await _httpClient.GetAsync($"orderings/GetOrderingByUserId/{id}");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(data);
        return result ?? new List<ResultOrderingByUserIdDto>();
    }
}
