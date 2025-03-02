using MS.Discount.Dtos;
using MS.Discount.Services;
using Microsoft.AspNetCore.Mvc;

namespace MS.Discount.Controllers
{
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
        public async Task<ActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDiscountCouponById(int id)
        {
            var value = await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDiscountCoupon(CreateDiscountCouponDto cdcdto)
        {
            await _discountService.CreateDiscountCouponAsync(cdcdto);
            return Ok("Kupon başarıyla oluşturuldu.");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon başarıyla silindi.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto udcdto)
        {
            await _discountService.UpdateDiscountCouponAsync(udcdto);
            return Ok("Kupon başarıyla güncellendi.");
        }
    }
}
