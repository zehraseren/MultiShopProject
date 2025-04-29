using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents;

public class _UserLayoutNavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
