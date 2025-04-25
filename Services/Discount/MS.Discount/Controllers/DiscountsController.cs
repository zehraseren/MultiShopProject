using MS.Discount.Dtos;
using MS.Discount.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MS.Discount.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> DiscountCouponList()
    {
        var values = await _discountService.GetAllDiscountCouponAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiscountCouponById(int id)
    {
        var value = await _discountService.GetByIdDiscountCouponAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto cdcdto)
    {
        await _discountService.CreateDiscountCouponAsync(cdcdto);
        return Ok("Kupon başarıyla oluşturuldu.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDiscountCoupon(int id)
    {
        await _discountService.DeleteDiscountCouponAsync(id);
        return Ok("Kupon başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto udcdto)
    {
        await _discountService.UpdateDiscountCouponAsync(udcdto);
        return Ok("Kupon başarıyla güncellendi.");
    }

    [HttpGet("GetCodeDetailByCode")]
    public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
    {
        var value = await _discountService.GetCodeDetailByCodeAsync(code);
        return Ok(value);
    }

    [HttpGet("GetDiscountCouponRate")]
    public IActionResult GetDiscountCouponCountRate(string code)
    {
        var value = _discountService.GetDiscountCouponRateAsync(code);
        return Ok(value);
    }
}
