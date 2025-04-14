using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MS.WebUI.Services.CatalogServices.SpecialOfferServices;

public class SpecialOfferService : ISpecialOfferService
{
    private readonly HttpClient _httpClient;

    public SpecialOfferService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto csodto)
    {
        await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", csodto);
    }

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
    {
        var response = await _httpClient.GetAsync("specialoffers");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(data);
        return result;
    }

    public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
    {
        var response = await _httpClient.GetAsync($"specialoffers/{id}");
        var result = await response.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
        return result;
    }

    public async Task DeleteSpecialOfferAsync(string id)
    {
        await _httpClient.DeleteAsync($"specialoffers?id={id}");
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto usodto)
    {
        await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", usodto);
    }
}
