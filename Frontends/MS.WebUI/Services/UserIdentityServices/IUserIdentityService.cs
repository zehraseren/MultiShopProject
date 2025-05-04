using MS.UI.DtoLayer.IdentityDtos.UserDtos;

namespace MS.WebUI.Services.UserIdentityServices;

public interface IUserIdentityService
{
    Task<List<ResultUserDto>> GetAllUserListAsync();
}
