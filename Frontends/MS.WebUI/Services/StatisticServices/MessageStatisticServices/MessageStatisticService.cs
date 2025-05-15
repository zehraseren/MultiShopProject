namespace MS.WebUI.Services.StatisticServices.MessageStatisticServices;

public class MessageStatisticService : IMessageStatisticService
{
    private readonly HttpClient _httpClient;

    public MessageStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetTotalMessageCount()
    {
        var response = await _httpClient.GetAsync("UserMessages/GetTotalMessageCount");
        var result = await response.Content.ReadFromJsonAsync<int>();
        return result;
    }
}
