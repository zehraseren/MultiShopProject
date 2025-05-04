using Newtonsoft.Json;
using MS.UI.DtoLayer.IdentityDtos.UserDtos;

namespace MS.WebUI.Services.UserIdentityServices;

public class UserIdentityService : IUserIdentityService
{
    private readonly HttpClient _httpClient;

    public UserIdentityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultUserDto>> GetAllUserListAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5001/api/users/GetAllUserList");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultUserDto>>(data);
        return result;
    }
}
