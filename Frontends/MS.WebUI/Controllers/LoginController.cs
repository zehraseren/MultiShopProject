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
        return View();
    }

    public async Task<IActionResult> SignIn(SignInDto sidto)
    {
        sidto.Username = "ayse01";
        sidto.Password = "123456aA*";
        await _identityService.SignIn(sidto);
        return RedirectToAction("Index", "Test");
    }
}
