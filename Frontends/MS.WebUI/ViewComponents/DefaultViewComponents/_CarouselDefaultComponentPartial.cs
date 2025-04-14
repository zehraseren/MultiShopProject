using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MS.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(result);
        }
    }
}