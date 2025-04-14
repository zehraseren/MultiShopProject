using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.AboutServices;

namespace MS.WebUI.ViewComponents.UILayoutViewComponents;

public class _FooterUILayoutComponentPartial : ViewComponent
{
    private readonly IAboutService _aboutService;

    public _FooterUILayoutComponentPartial(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _aboutService.GetAllAboutAsync();
        return View(result);
    }
}