using MS.UI.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MS.WebUI.Services.OrderServices;

public interface IOrderAddressService
{
    Task CreateOrderAddressAsync(CreateOrderAddressDto coadto);
}
