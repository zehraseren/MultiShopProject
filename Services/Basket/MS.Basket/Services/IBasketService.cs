using MS.Basket.Dtos;

namespace MS.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket(string userId);
    Task SaveBasket(BasketTotalDto btdto);
    Task RemoveBasket(string userId);
}
