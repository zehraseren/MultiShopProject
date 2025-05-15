using Newtonsoft.Json;

namespace MS.WebUI.Services.StatisticServices.UserStatisticServices;

public class UserStatisticService : IUserStatisticService
{
    private readonly HttpClient _httpClient;

    public UserStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetUsercount()
    {
        var response = await _httpClient.GetAsync("http://localhost:5001/Api/Statistics");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<int>(data);
        return result;
    }
}
