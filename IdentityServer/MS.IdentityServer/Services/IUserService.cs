using MS.IdentityServer.Models;

namespace MS.IdentityServer.Services;

public interface IUserService
{
    Task<List<UserDetailViewModel>> GetUsersByIdsAsync(List<string> userIds);
}
