using MS.Discount.Dtos;

namespace MS.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
    Task CreateDiscountCouponAsync(CreateDiscountCouponDto cdcdto);
    Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto udcdto);
    Task DeleteDiscountCouponAsync(int id);
    Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
    Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code);
    int GetDiscountCouponRateAsync(string code);
    Task<int> GetTotalDiscountCouponCountAsync();
}
