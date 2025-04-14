using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MS.WebUI.Services.CatalogServices.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly HttpClient _httpClient;

    public ProductImageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto cpidto)
    {
        await _httpClient.PostAsJsonAsync("productimages", cpidto);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _httpClient.DeleteAsync($"productimages?id={id}");
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var response = await _httpClient.GetAsync("productimages");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(data);
        return result;
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        var response = await _httpClient.GetAsync($"productimages/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
        return result;
    }

    public async Task<GetByIdProductImageDto> GetProductImagesByProductIdAsync(string id)
    {
        var response = await _httpClient.GetAsync($"productimages/ProductImagesByProductId/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
        return result;
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto upidto)
    {
        await _httpClient.PutAsJsonAsync("productimages", upidto);
    }
}
