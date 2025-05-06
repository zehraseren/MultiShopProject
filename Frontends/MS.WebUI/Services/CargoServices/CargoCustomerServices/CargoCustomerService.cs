using MS.UI.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MS.WebUI.Services.CargoServices.CargoCustomerServices;

public class CargoCustomerService : ICargoCustomerService
{
    private readonly HttpClient _httpClient;

    public CargoCustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id)
    {
        var response = await _httpClient.GetAsync($"cargocustomers/GetCargoCustomerById?id={id}");
        var result = await response.Content.ReadFromJsonAsync<GetCargoCustomerByIdDto>();
        return result;
    }
}