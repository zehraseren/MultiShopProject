using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MS.WebUI.Services.CatalogServices.OfferDiscountServices;

public class OfferDiscountService : IOfferDiscountService
{
    private readonly HttpClient _httpClient;

    public OfferDiscountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto coddto)
    {
        await _httpClient.PostAsJsonAsync("offerdiscounts", coddto);
    }

    public async Task DeleteOfferDiscountAsync(string id)
    {
        await _httpClient.DeleteAsync($"offerdiscounts?id={id}");
    }

    public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
    {
        var response = await _httpClient.GetAsync("offerdiscounts");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(data);
        return result;
    }

    public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
    {
        var response = await _httpClient.GetAsync($"offerdiscounts/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdOfferDiscountDto>();
        return result;
    }

    public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto uoddto)
    {
        await _httpClient.PutAsJsonAsync("offerdiscounts", uoddto);
    }
}
