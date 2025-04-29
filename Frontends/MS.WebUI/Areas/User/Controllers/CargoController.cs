using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.Areas.User.Controllers;

[Area("User")]
[Route("User/[controller]/[action]/{id?}")]
public class CargoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
