using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
