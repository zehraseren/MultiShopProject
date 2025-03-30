using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.ViewComponents.ContactViewComponents;

public class _ContactDetailComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}