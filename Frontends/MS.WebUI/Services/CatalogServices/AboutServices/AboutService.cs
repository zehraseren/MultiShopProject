using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.AboutDtos;

namespace MS.WebUI.Services.CatalogServices.AboutServices;

public class AboutService : IAboutService
{
    private readonly HttpClient _httpClient;

    public AboutService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAboutAsync(CreateAboutDto cadto)
    {
        await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts", cadto);
    }

    public async Task DeleteAboutAsync(string id)
    {
        await _httpClient.DeleteAsync($"abouts?id={id}");
    }

    public async Task<List<ResultAboutDto>> GetAllAboutAsync()
    {
        var response = await _httpClient.GetAsync("abouts");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultAboutDto>>(data);
        return result;
    }

    public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
    {
        var response = await _httpClient.GetAsync($"abouts/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdAboutDto>();
        return result;
    }

    public async Task UpdateAboutAsync(UpdateAboutDto uadto)
    {
        await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts", uadto);
    }
}
