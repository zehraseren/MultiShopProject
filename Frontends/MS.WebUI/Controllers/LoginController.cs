using System.Text;
using System.Text.Json;
using MS.WebUI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using MS.UI.DtoLayer.IdentityDtos.LoginDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MS.WebUI.Controllers;

public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;
    private readonly IIdentityService _identityService;

    public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
        _identityService = identityService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateLoginDto cldto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonSerializer.Serialize(cldto), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            var tokenModel = JsonSerializer.Deserialize<JWTResponseModel>(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if (tokenModel != null && !string.IsNullOrEmpty(tokenModel.Token))
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenModel.Token);
                var claims = token.Claims.ToList();

                claims.Add(new Claim("multishoptoken", tokenModel.Token));
                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    ExpiresUtc = tokenModel.ExpireDate,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                var id = _loginService.GetUserId;
                return RedirectToAction("Index", "Default");
            }
        }
        return View();
    }

    //[HttpGet]
    //public IActionResult SignIn()
    //{
    //    return View();
    //}

    //[HttpPost]
    public async Task<IActionResult> SignIn(SignInDto sidto)
    {
        sidto.Username = "ayse01";
        sidto.Password = "123456aA*";
        await _identityService.SignIn(sidto);
        return RedirectToAction("Index", "Test");
    }
}
