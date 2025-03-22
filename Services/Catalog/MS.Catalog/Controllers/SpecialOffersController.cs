using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MS.Catalog.Dtos.SpecialOfferDtos;
using MS.Catalog.Services.SpecialOfferServices;

namespace MS.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var value = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto csodto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(csodto);
            return Ok("Özel teklif başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel teklif başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto usodto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(usodto);
            return Ok("Özel teklif başarıyla güncellendi.");
        }
    }
}
