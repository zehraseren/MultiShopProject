using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.ProductImageDtos;
using MS.Catalog.Services.ProductImageServices;

namespace MS.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var value = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto cpidto)
        {
            await _productImageService.CreateProductImageAsync(cpidto);
            return Ok("Ürün resmi başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün resmi başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto upidto)
        {
            await _productImageService.UpdateProductImageAsync(upidto);
            return Ok("Ürün resmi başarıyla güncellendi.");
        }

        [HttpGet("ProductImagesByProductId")]
        public async Task<IActionResult> ProductImagesByProductId(string id)
        {
            var values = await _productImageService.GetByProductIdProductImagesAsync(id);
            return Ok(values);
        }

    }
}
