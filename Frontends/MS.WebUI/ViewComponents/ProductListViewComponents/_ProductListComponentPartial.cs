using MS.WebUI.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MS.WebUI.Services.LocalizationServices;
using MS.WebUI.Services.CatalogServices.CategoryServices;
using MS.WebUI.Services.CatalogServices.ProductServices;

namespace MS.WebUI.ViewComponents.ProductListViewComponents;

public class _ProductListComponentPartial : ViewComponent
{
    private readonly LocalizationService _localizer;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IStringLocalizer<ProductListWithCategoryResources> _productLocalizer;

    public _ProductListComponentPartial(LocalizationService localizer, IProductService productService, ICategoryService categoryService, IStringLocalizer<ProductListWithCategoryResources> productLocalizer)
    {
        _localizer = localizer;
        _productService = productService;
        _categoryService = categoryService;
        _productLocalizer = productLocalizer;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var category = await _categoryService.GetByIdCategoryAsync(id);
        if (category == null)
            return View();

        var products = await _productService.GetProductsWithCategoryByCatetegoryIdAsync(id);

        var localizedCategoryName = _localizer.GetKey(category.CategoryName, typeof(CategoryResources));

        ViewBag.cn = products.Any()
           ? string.Format(_localizer.GetKey("ProductsInCategory", typeof(ProductListWithCategoryResources)), localizedCategoryName)
           : string.Format(_localizer.GetKey("NoProductsInCategory", typeof(ProductListWithCategoryResources)), localizedCategoryName);

        return View(products);
    }
}