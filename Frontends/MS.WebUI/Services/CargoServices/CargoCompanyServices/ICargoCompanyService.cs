using MS.UI.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MS.WebUI.Services.CargoServices.CargoCompanyServices;

public interface ICargoCompanyService
{
    Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync();
    Task CreateCargoCompanyAsync(CreateCargoCompanyDto cccdto);
    Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto uccdto);
    Task DeleteCargoCompanyAsync(int id);
    Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id);
}
