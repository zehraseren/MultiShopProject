using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
