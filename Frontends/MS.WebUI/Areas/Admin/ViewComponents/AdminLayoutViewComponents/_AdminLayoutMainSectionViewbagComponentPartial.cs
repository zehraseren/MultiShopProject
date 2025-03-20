using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutMainSectionViewbagComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}