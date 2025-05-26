
namespace MS.SignalRRealTimeApi.Services.SignalRMessageServices;

public class SignalRMessageServices : ISignalRMessageServices
{
    private readonly HttpClient _httpClient;

    public SignalRMessageServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetTotalMessageCountByReceiverId(string id)
    {
        var response = await _httpClient.GetAsync($"UserMessages/GetTotalMessageCountByReceiverId?id={id}");
        var result = await response.Content.ReadFromJsonAsync<int>();
        return result;
    }
}
