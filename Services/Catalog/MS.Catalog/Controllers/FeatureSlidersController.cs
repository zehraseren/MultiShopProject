using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Authorization;
using MS.Catalog.Services.FeatureSliderServices;

namespace MS.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class FeatureSlidersController : ControllerBase
{
    private readonly IFeatureSliderService _featureSliderService;

    public FeatureSlidersController(IFeatureSliderService featureSliderService)
    {
        _featureSliderService = featureSliderService;
    }

    [HttpGet]
    public async Task<IActionResult> FeatureSliderList()
    {
        var values = await _featureSliderService.GetAllFeatureSliderAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeatureSliderById(string id)
    {
        var value = await _featureSliderService.GetByIdFeatureSliderAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto cfsdto)
    {
        await _featureSliderService.CreateFeatureSliderAsync(cfsdto);
        return Ok("Öne çıkan görsel başarıyla eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFeatureSlider(string id)
    {
        await _featureSliderService.DeleteFeatureSliderAsync(id);
        return Ok("Öne çıkan görsel başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto ufsdto)
    {
        await _featureSliderService.UpdateFeatureSliderAsync(ufsdto);
        return Ok("Öne çıkan görsel başarıyla güncellendi.");
    }
}
