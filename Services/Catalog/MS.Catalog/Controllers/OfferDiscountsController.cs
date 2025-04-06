using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.OfferDiscountDtos;
using Microsoft.AspNetCore.Authorization;
using MS.Catalog.Services.OfferDiscountServices;

namespace MS.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OfferDiscountsController : ControllerBase
{
    private readonly IOfferDiscountService _offerDiscountService;

    public OfferDiscountsController(IOfferDiscountService offerDiscountService)
    {
        _offerDiscountService = offerDiscountService;
    }

    [HttpGet]
    public async Task<IActionResult> OfferDiscountList()
    {
        var values = await _offerDiscountService.GetAllOfferDiscountAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOfferDiscountById(string id)
    {
        var value = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto coddto)
    {
        await _offerDiscountService.CreateOfferDiscountAsync(coddto);
        return Ok("Özel teklif başarıyla eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOfferDiscount(string id)
    {
        await _offerDiscountService.DeleteOfferDiscountAsync(id);
        return Ok("Özel teklif başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto uoddto)
    {
        await _offerDiscountService.UpdateOfferDiscountAsync(uoddto);
        return Ok("Özel teklif başarıyla güncellendi.");
    }
}
