using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using MS.Catalog.Services.FeatureServices;

namespace MS.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IFeatureService _featureService;

    public FeaturesController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    [HttpGet]
    public async Task<IActionResult> FeatureList()
    {
        var values = await _featureService.GetAllFeatureAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeatureById(string id)
    {
        var value = await _featureService.GetByIdFeatureAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto cfdto)
    {
        await _featureService.CreateFeatureAsync(cfdto);
        return Ok("Öne çıkan başarıyla eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        await _featureService.DeleteFeatureAsync(id);
        return Ok("Öne çıkan başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto ufdto)
    {
        await _featureService.UpdateFeatureAsync(ufdto);
        return Ok("Öne çıkan başarıyla güncellendi.");
    }
}
