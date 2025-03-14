using MS.IdentityServer.Dtos;
using Microsoft.AspNetCore.Mvc;
using MS.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MS.IdentityServer.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto urdto)
        {
            var values = new ApplicationUser()
            {
                UserName = urdto.UserName,
                Email = urdto.Email,
                Name = urdto.Name,
                Surname = urdto.Surname
            };

            var result = await _userManager.CreateAsync(values, urdto.Password);

            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi.");
            }
            else
            {
                return Ok("Bir hata oluştu tekrar deneyiniz.");
            }
        }
    }
}
