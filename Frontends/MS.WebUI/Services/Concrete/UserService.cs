using MS.WebUI.Models;
using MS.WebUI.Services.Interfaces;

namespace MS.WebUI.Services.Concrete;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDetailViewModel> GetUserInfo()
    {
        return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
    }

    public async Task<List<UserDetailViewModel>> GetUsersByIdsAsync(List<string> userIds)
    {
        var response = await _httpClient.PostAsJsonAsync("api/users/GetUserByIds", userIds);
        response.EnsureSuccessStatusCode();
        var users = await response.Content.ReadFromJsonAsync<List<UserDetailViewModel>>();
        return users ?? new List<UserDetailViewModel>();
    }
}
