using MS.IdentityServer.Dtos;
using MS.IdentityServer.Tools;
using Microsoft.AspNetCore.Mvc;
using MS.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace MS.IdentityServer.Controller;

[Route("api/[controller]")]
[ApiController]
public class LoginsController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> UserLogin(UserLoginDto uldto)
    {
        var result = await _signInManager.PasswordSignInAsync(uldto.UserName, uldto.Password, false, false);
        var user = await _userManager.FindByNameAsync(uldto.UserName);

        if (result.Succeeded)
        {
            GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
            model.UserName = uldto.UserName;
            model.Id = user.Id;
            var token = JwtTokenGenerator.GenerateToken(model);
            return Ok(token);
        }
        else
        {
            return Ok("Kullanıcı adı veya şifre hatalı");
        }
    }
}
