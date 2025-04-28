using MS.UI.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MS.WebUI.Services.OrderServices;

public class OrderAddressService : IOrderAddressService
{
    private readonly HttpClient _httpClient;

    public OrderAddressService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateOrderAddressAsync(CreateOrderAddressDto coadto)
    {
        await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", coadto);
    }
}
