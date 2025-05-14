namespace MS.Catalog.Services.StatisticServices;

public interface IStatisticService
{
    Task<long> GetBrandCount();
    Task<long> GetProductCount();
    Task<long> GetCategoryCount();
    Task<decimal> GetProductAvgPrice();
    Task<string> GetMinPriceProductName();
    Task<string> GetMaxPriceProductName();
}
