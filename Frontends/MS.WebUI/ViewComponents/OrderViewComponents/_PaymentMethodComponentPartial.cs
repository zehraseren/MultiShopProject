using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.ViewComponents.OrderViewComponents;

public class _PaymentMethodComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
