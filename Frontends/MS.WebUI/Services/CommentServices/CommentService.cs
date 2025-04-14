using Newtonsoft.Json;
using MS.UI.DtoLayer.CommentDtos;

namespace MS.WebUI.Services.CommentServices;

public class CommentService : ICommentService
{
    private readonly HttpClient _httpClient;

    public CommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
    {
        var response = await _httpClient.GetAsync($"comments/CommmentListByProductId?productId={id}");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultCommentDto>>(data);
        return result;
    }

    public async Task CreateCommentAsync(CreateCommentDto ccdto)
    {
        await _httpClient.PostAsJsonAsync("comments", ccdto);
    }

    public async Task DeleteCommentAsync(string id)
    {
        await _httpClient.DeleteAsync($"comments?id={id}");
    }

    public async Task<List<ResultCommentDto>> GetAllCommentAsync()
    {
        var response = await _httpClient.GetAsync("comments");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultCommentDto>>(data);
        return result;
    }

    public async Task<GetByIdCommentDto> GetByIdCommentAsync(string id)
    {
        var response = await _httpClient.GetAsync($"comments/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdCommentDto>();
        return result;
    }
    public async Task UpdateCommentAsync(UpdateCommentDto ucdto)
    {
        await _httpClient.PostAsJsonAsync("comments", ucdto);
    }
}
