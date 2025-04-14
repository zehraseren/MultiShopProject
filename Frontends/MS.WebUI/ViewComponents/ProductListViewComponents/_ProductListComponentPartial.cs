using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CatalogServices.ProductServices;
using MS.WebUI.Services.CatalogServices.CategoryServices;

namespace MS.WebUI.ViewComponents.ProductListViewComponents;

public class _ProductListComponentPartial : ViewComponent
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public _ProductListComponentPartial(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var category = await _categoryService.GetByIdCategoryAsync(id);
        if (category == null)
            return View();

        var products = await _productService.GetProductsWithCategoryByCatetegoryIdAsync(id);

        ViewBag.cn = products.Any()
            ? $"{category.CategoryName} Kategorisindeki Ürünler"
            : $"{category.CategoryName} kategorisinde ürün yok.";

        return View(products);
    }
}