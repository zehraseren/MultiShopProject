using MS.UI.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MS.WebUI.Services.OrderServices.OrderOrderingServices;

public interface IOrderOrderingService
{
    Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
}
