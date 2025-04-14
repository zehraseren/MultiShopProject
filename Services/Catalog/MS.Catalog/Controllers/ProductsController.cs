using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using MS.Catalog.Services.ProductServices;

namespace MS.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        var values = await _productService.GetAllProductAsync();
        return Ok(values);
    }

    [HttpGet("ProductListWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        var values = await _productService.GetProductsWithCategoryAsync();
        return Ok(values);
    }

    [HttpGet("ProductsWithCategoryByCategoryId/{id}")]
    public async Task<IActionResult> ProductsWithCategoryByCategoryId(string id)
    {
        var values = await _productService.GetProductsWithCategoryByCatetegoryIdAsync(id);
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var value = await _productService.GetByIdProductAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto cpdto)
    {
        await _productService.CreateProductAsync(cpdto);
        return Ok("Ürün başarıyla eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok("Ürün başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updto)
    {
        await _productService.UpdateProductAsync(updto);
        return Ok("Ürün başarıyla güncellendi.");
    }
}
