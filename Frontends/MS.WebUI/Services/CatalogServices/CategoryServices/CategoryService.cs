using MS.UI.DtoLayer.CatalogDtos.CategoryDtos;

namespace MS.WebUI.Services.CatalogServices.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto ccdto)
    {
        await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", ccdto);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _httpClient.DeleteAsync($"categories?id={id}");
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        var response = await _httpClient.GetAsync("categories");
        var result = await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
        return result;
    }

    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
    {
        var response = await _httpClient.GetAsync($"categories/{id}");
        var result = await response.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
        return result;

    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto ucdto)
    {
        await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", ucdto);
    }
}
