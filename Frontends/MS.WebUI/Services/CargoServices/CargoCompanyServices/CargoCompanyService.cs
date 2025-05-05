using MS.UI.DtoLayer.CargoDtos.CargoCompanyDtos;
using Newtonsoft.Json;

namespace MS.WebUI.Services.CargoServices.CargoCompanyServices;

public class CargoCompanyService : ICargoCompanyService
{
    private readonly HttpClient _httpClient;

    public CargoCompanyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto cccdto)
    {
        await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargocompanies", cccdto);
    }

    public async Task DeleteCargoCompanyAsync(int id)
    {
        await _httpClient.DeleteAsync($"cargocompanies?id={id}");
    }

    public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
    {
        var response = await _httpClient.GetAsync("cargocompanies");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultCargoCompanyDto>>(data);
        return result ?? new List<ResultCargoCompanyDto>();
    }

    public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
    {
        var response = await _httpClient.GetAsync($"cargocompanies/{id}");
        var result = await response.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
        return result ?? new UpdateCargoCompanyDto();
    }

    public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto uccdto)
    {
        await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargocompanies", uccdto);
    }
}
