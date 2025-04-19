using MS.UI.DtoLayer.BasketDtos;

namespace MS.WebUI.Services.BasketServices;

public class BasketService : IBasketService
{
    private readonly HttpClient _httpClient;

    public BasketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BasketTotalDto> GetBasket()
    {
        var response = await _httpClient.GetAsync("baskets");
        if (!response.IsSuccessStatusCode)
            return null;
        var result = await response.Content.ReadFromJsonAsync<BasketTotalDto>();
        return result;
    }

    public Task DeleteBasket(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveBasket(BasketTotalDto btdto)
    {
        await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", btdto);
    }

    public async Task AddBasketItem(BasketItemDto bidto)
    {
        var values = await GetBasket();
        if (values != null)
        {
            if (!values.BasketItems.Any(x => x.ProductId == bidto.ProductId))
            {
                values.BasketItems.Add(bidto);
            }
            else
            {
                values = new BasketTotalDto();
                values.BasketItems.Add(bidto);
            }
        }
        await SaveBasket(values);
    }

    public async Task<bool> DeleteBasketItem(string productId)
    {
        var values = await GetBasket();
        var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
        var result = values.BasketItems.Remove(deletedItem);
        await SaveBasket(values);
        return true;
    }
}
