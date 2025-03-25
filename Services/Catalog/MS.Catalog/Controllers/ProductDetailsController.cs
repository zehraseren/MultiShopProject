using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.ProductDetailDtos;
using MS.Catalog.Services.ProductDetailServices;

namespace MS.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }

        [HttpGet("GetProductDetailByProductId/{id}")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var value = await _productDetailService.GetProductDetailByProductIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto cpddto)
        {
            await _productDetailService.CreateProductDetailAsync(cpddto);
            return Ok("Ürün detayı başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto upddto)
        {
            await _productDetailService.UpdateProductDetailAsync(upddto);
            return Ok("Ürün detayı başarıyla güncellendi.");
        }
    }
}
