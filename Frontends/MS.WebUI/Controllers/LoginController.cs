using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.Interfaces;
using MS.UI.DtoLayer.IdentityDtos.LoginDtos;

namespace MS.WebUI.Controllers;

public class LoginController : Controller
{
    private readonly IIdentityService _identityService;

    public LoginController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(SignInDto sidto)
    {
        await _identityService.SignIn(sidto);
        return RedirectToAction("Index", "Default");
    }
}
