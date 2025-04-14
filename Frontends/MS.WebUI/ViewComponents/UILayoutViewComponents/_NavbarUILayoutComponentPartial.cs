using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.CategoryServices;

namespace MS.WebUI.ViewComponents.UILayoutViewComponents;

public class _NavbarUILayoutComponentPartial : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public _NavbarUILayoutComponentPartial(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _categoryService.GetAllCategoryAsync();
        return View(result);
    }
}