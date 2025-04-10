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
}
