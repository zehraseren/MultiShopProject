using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MS.WebUI.Services.CatalogServices.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly HttpClient _httpClient;

    public ProductDetailService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto cpddto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetails", cpddto);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _httpClient.DeleteAsync($"productdetails?id={id}");
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var response = await _httpClient.GetAsync("productdetails");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(data);
        return result;
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var response = await _httpClient.GetAsync($"productdetails/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
        return result;
    }

    public async Task<GetByIdProductDetailDto> GetProductDetailByProductIdAsync(string id)
    {
        var response = await _httpClient.GetAsync($"productdetails/GetProductDetailByProductId/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
        return result;
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto ucpdto)
    {
        await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetails", ucpdto);
    }
}
