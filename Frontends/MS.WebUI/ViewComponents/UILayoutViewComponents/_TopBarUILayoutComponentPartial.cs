using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopBarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
