using MS.UI.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MS.WebUI.Services.CargoServices.CargoCustomerServices;

public interface ICargoCustomerService
{
    Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
}
