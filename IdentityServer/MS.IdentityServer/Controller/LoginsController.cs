using MS.IdentityServer.Dtos;
using Microsoft.AspNetCore.Mvc;
using MS.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace MS.IdentityServer.Controller;

[Route("api/[controller]")]
[ApiController]
public class LoginsController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public LoginsController(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> UserLogin(UserLoginDto uldto)
    {
        var result = await _signInManager.PasswordSignInAsync(uldto.UserName, uldto.Password, false, false);
        if (result.Succeeded)
        {
            return Ok("Giriş Başarılı");
        }
        else
        {
            return Ok("Kullanıcı adı veya şifre hatalı");
        }
    }
}
