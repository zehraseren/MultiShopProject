using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using MS.Catalog.Services.CategoryServices;

namespace MS.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var value = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto ccdto)
        {
            await _categoryService.CreateCategoryAsync(ccdto);
            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto ucdto)
        {
            await _categoryService.UpdateCategoryAsync(ucdto);
            return Ok("Kategori başarıyla güncellendi.");
        }
    }
}
