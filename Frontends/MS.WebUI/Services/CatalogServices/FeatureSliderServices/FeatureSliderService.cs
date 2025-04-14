using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MS.WebUI.Services.CatalogServices.FeatureSliderServices;

public class FeatureSliderService : IFeatureSliderService
{
    private readonly HttpClient _httpClient;

    public FeatureSliderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto cfsdto)
    {
        await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featuresliders", cfsdto);
    }

    public async Task DeleteFeatureSliderAsync(string id)
    {
        await _httpClient.DeleteAsync($"featuresliders?id={id}");
    }

    public Task FeatureSliderChangeStatusFalseAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task FeatureSliderChangeStatusTrueAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
    {
        var response = await _httpClient.GetAsync("featuresliders");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(data);
        return result;
    }

    public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
    {
        var response = await _httpClient.GetAsync($"featuresliders/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdFeatureSliderDto>();
        return result;
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto ufsdto)
    {
        await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featuresliders", ufsdto);
    }
}
