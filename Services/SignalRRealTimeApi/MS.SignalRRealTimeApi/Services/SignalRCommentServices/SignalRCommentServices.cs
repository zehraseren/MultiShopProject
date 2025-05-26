using Newtonsoft.Json;

namespace MS.SignalRRealTimeApi.Services.SignalRCommentServices;

public class SignalRCommentServices : ISignalRCommentServices
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SignalRCommentServices(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<int> GetTotalCommentCount()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:7075/api/CommentStatistics");
        var data = await response.Content.ReadAsStringAsync();
        var commentCount = JsonConvert.DeserializeObject<int>(data);
        return commentCount;
    }
}
