using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.FeatureServices;

namespace MS.WebUI.ViewComponents.DefaultViewComponents;

public class _FeatureDefaultComponentPartial : ViewComponent
{
    private readonly IFeatureService _featureService;

    public _FeatureDefaultComponentPartial(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _featureService.GetAllFeatureAsync();
        return View(result);
    }
}