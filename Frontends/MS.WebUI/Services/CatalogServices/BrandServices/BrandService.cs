using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.BrandDtos;

namespace MS.WebUI.Services.CatalogServices.BrandServices;

public class BrandService : IBrandService
{
    private readonly HttpClient _httpClient;

    public BrandService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateBrandAsync(CreateBrandDto cbdto)
    {
        await _httpClient.PostAsJsonAsync<CreateBrandDto>("brands", cbdto);
    }

    public async Task DeleteBrandAsync(string id)
    {
        await _httpClient.DeleteAsync($"brands?id={id}");
    }

    public async Task<List<ResultBrandDto>> GetAllBrandAsync()
    {
        var response = await _httpClient.GetAsync("brands");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultBrandDto>>(data);
        return result;
    }

    public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
    {
        var response = await _httpClient.GetAsync($"brands/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdBrandDto>();
        return result;
    }

    public async Task UpdateBrandAsync(UpdateBrandDto ubdto)
    {
        await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brands", ubdto);
    }
}
