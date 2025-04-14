using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.CategoryServices;

namespace MS.WebUI.ViewComponents.DefaultViewComponents;

public class _CategoriesDefaultComponentPartial : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public _CategoriesDefaultComponentPartial(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _categoryService.GetAllCategoryAsync();
        return View(result);
    }
}