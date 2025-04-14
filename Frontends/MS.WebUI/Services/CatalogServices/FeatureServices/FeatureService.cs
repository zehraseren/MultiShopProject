using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.FeatureDtos;

namespace MS.WebUI.Services.CatalogServices.FeatureServices;

public class FeatureService : IFeatureService
{
    private readonly HttpClient _httpClient;

    public FeatureService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateFeatureAsync(CreateFeatureDto cfdto)
    {
        await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features", cfdto);
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await _httpClient.DeleteAsync($"features?id={id}");
    }

    public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
    {
        var response = await _httpClient.GetAsync("features");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(data);
        return result;
    }

    public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
    {
        var response = await _httpClient.GetAsync($"features/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdFeatureDto>();
        return result;
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto ufdto)
    {
        await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("features", ufdto);
    }
}
