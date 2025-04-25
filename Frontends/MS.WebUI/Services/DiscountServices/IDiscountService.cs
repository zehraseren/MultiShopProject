using MS.UI.DtoLayer.DiscountDtos;

namespace MS.WebUI.Services.DiscountServices;

public interface IDiscountService
{
    Task<GetDiscountCodeDetailByCodeDto> GetDiscountCode(string code);
    Task<int> GetDiscountCouponRate(string code);
}
