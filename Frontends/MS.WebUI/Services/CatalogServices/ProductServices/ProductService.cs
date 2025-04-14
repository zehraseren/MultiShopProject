using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.ProductDtos;

namespace MS.WebUI.Services.CatalogServices.ProductServices;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateProductAsync(CreateProductDto cpdto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductDto>("products", cpdto);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _httpClient.DeleteAsync($"products?id={id}");
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var response = await _httpClient.GetAsync("products");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultProductDto>>(data);
        return result;
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
    {
        var response = await _httpClient.GetAsync($"products/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdProductDto>();
        return result;
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
    {
        var response = await _httpClient.GetAsync("products/ProductListWithCategory");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(data);
        return result;
    }

    public async Task<ResultProductWithCategoryDto> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId)
    {
        var response = await _httpClient.GetAsync($"products/GetProductsWithCategoryByCatetegoryId/{CategoryId}");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ResultProductWithCategoryDto>(data);
        return result;
    }

    public async Task UpdateProductAsync(UpdateProductDto updto)
    {
        var response = await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updto);
    }
}
