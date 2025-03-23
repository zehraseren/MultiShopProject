using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.BrandDtos;
using Microsoft.AspNetCore.Authorization;
using MS.Catalog.Services.BrandServices;

namespace MS.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<IActionResult> BrandList()
    {
        var values = await _brandService.GetAllBrandAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById(string id)
    {
        var value = await _brandService.GetByIdBrandAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto cbdto)
    {
        await _brandService.CreateBrandAsync(cbdto);
        return Ok("Marka başarıyla eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrandAsync(id);
        return Ok("Marka başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto ubdto)
    {
        await _brandService.UpdateBrandAsync(ubdto);
        return Ok("Marka başarıyla güncellendi.");
    }
}
