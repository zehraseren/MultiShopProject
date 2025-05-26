using Microsoft.AspNetCore.Identity;
using MS.IdentityServer.Models;

namespace MS.IdentityServer.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<UserDetailViewModel>> GetUsersByIdsAsync(List<string> userIds)
    {
        var users = new List<UserDetailViewModel>();

        foreach (var id in userIds)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                users.Add(new UserDetailViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname
                });
            }
        }

        return users;
    }
}
