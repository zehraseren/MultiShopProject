using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.AboutDtos;
using MS.Catalog.Services.AboutServices;
using Microsoft.AspNetCore.Authorization;

namespace MS.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AboutsController : ControllerBase
{
    private readonly IAboutService _aboutService;

    public AboutsController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
        var values = await _aboutService.GetAllAboutAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAboutById(string id)
    {
        var value = await _aboutService.GetByIdAboutAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutDto cadto)
    {
        await _aboutService.CreateAboutAsync(cadto);
        return Ok("Hakkımda bilgisi başarıyla eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAbout(string id)
    {
        await _aboutService.DeleteAboutAsync(id);
        return Ok("Hakkımda bilgisi başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto uadto)
    {
        await _aboutService.UpdateAboutAsync(uadto);
        return Ok("Hakkımda bilgisi başarıyla güncellendi.");
    }
}
