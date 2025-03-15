using MS.Basket.Dtos;
using System.Text.Json;
using MS.Basket.Settings;

namespace MS.Basket.Services;

public class BasketService : IBasketService
{
    private readonly RedisService _redisService;
    public BasketService(RedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task<BasketTotalDto> GetBasket(string userId)
    {
        var existBasket = await _redisService.GetDb().StringGetAsync(userId);
        return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
    }

    public async Task RemoveBasket(string userId)
    {
        await _redisService.GetDb().KeyDeleteAsync(userId);
    }

    public async Task SaveBasket(BasketTotalDto btdto)
    {
        await _redisService.GetDb().StringSetAsync(btdto.UserId, JsonSerializer.Serialize(btdto));
    }
}
