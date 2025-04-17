using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.CategoryDtos;
using MS.WebUI.Services.CatalogServices.CategoryServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
    {
        _categoryService = categoryService;
        _httpClientFactory = httpClientFactory;
    }

    void CategoryViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Kategoriler";
        ViewBag.v3 = "Kategori Listesi";
        ViewBag.v0 = "Kategori İşlemleri";
    }

    public async Task<IActionResult> Index()
    {
        CategoryViewBagList();
        var result = await _categoryService.GetAllCategoryAsync();
        return View(result);
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        CategoryViewBagList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto ccdto)
    {
        await _categoryService.CreateCategoryAsync(ccdto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCategory(string id)
    {
        CategoryViewBagList();
        var result = await _categoryService.GetByIdCategoryAsync(id);
        var ucdto = new UpdateCategoryDto
        {
            CategoryId = result.CategoryId,
            CategoryName = result.CategoryName,
            ImageUrl = result.ImageUrl
        };
        return View(ucdto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto ucdto)
    {
        await _categoryService.UpdateCategoryAsync(ucdto);
        return RedirectToAction("Index");
    }
}
