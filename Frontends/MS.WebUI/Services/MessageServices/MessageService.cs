using MS.UI.DtoLayer.MessageDtos;

namespace MS.WebUI.Services.MessageServices;

public class MessageService : IMessageService
{
    private readonly HttpClient _httpClient;

    public MessageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
    {
        var response = await _httpClient.GetAsync($"UserMessages/GetMessageInbox?id={id}");
        var result = await response.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
        return result ?? new List<ResultInboxMessageDto>();
    }

    public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
    {
        var response = await _httpClient.GetAsync($"UserMessages/GetMessageSendbox?id={id}");
        var result = await response.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
        return result ?? new List<ResultSendboxMessageDto>();
    }

    public async Task<int> GetTotalMessageCountByReceiverId(string id)
    {
        var response = await _httpClient.GetAsync($"UserMessages/GetTotalMessageCountByReceiverId?id={id}");
        var result = await response.Content.ReadFromJsonAsync<int>();
        return result;
    }
}
