using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS.UI.DtoLayer.CatalogDtos.ProductDtos;
using MS.WebUI.Services.CatalogServices.ProductServices;
using MS.WebUI.Services.CatalogServices.CategoryServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    void ProductViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ürünler";
        ViewBag.v3 = "Ürün Listesi";
        ViewBag.v0 = "Ürün İşlemleri";
    }

    public async Task<IActionResult> Index()
    {
        ProductViewBagList();
        var result = await _productService.GetAllProductAsync();
        return View(result);
    }

    public async Task<IActionResult> ProductListWithCategory()
    {
        ProductViewBagList();
        var result = await _productService.GetProductsWithCategoryAsync();
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        ProductViewBagList();
        var categories = await _categoryService.GetAllCategoryAsync();
        List<SelectListItem> categoryValues = (from x in categories
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId
                                               }).ToList();
        ViewBag.Categories = categoryValues;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto cpdto)
    {
        await _productService.CreateProductAsync(cpdto);
        return RedirectToAction("ProductListWithCategory");
    }

    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("ProductListWithCategory");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        ProductViewBagList();
        var categories = await _categoryService.GetAllCategoryAsync();
        List<SelectListItem> categoryValues = (from x in categories
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId
                                               }).ToList();
        ViewBag.Categories = categoryValues;

        var result = await _productService.GetByIdProductAsync(id);
        var updto = new UpdateProductDto
        {
            ProductId = result.ProductId,
            ProductName = result.ProductName,
            ProductPrice = result.ProductPrice,
            ProductImageUrl = result.ProductImageUrl,
            ProductDescription = result.ProductDescription,
            CategoryId = result.CategoryId
        };
        return View(updto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updto)
    {
        await _productService.UpdateProductAsync(updto);
        return RedirectToAction("ProductListWithCategory");
    }
}
