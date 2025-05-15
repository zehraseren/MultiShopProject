namespace MS.WebUI.Services.StatisticServices.DiscountStatisticServices;

public interface IDiscountStatisticService
{
    Task<int> GetDiscountCouponCount();
}
