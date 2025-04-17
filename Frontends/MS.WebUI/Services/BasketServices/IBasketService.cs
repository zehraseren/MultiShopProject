using MS.UI.DtoLayer.BasketDtos;

namespace MS.WebUI.Services.BasketServices;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket();
    Task SaveBasket(BasketTotalDto btdto);
    Task DeleteBasket(string userId);
    Task AddBasketItem(BasketItemDto bidto);
    Task<bool> DeleteBasketItem(string productId);
}
