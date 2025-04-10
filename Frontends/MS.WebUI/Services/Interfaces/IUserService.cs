using MS.WebUI.Models;

namespace MS.WebUI.Services.Interfaces;

public interface IUserService
{
    Task<UserDetailViewModel> GetUserInfo();
}
