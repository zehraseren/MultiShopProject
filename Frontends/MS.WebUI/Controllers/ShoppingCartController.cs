using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
