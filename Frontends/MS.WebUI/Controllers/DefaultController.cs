using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.Controllers;

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        ViewBag.directory1 = "Ana Sayfa";
        ViewBag.directory3 = "Ürün Listesi";
        return View();
    }
}
