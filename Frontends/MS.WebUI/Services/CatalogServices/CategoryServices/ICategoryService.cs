using MS.UI.DtoLayer.CatalogDtos.CategoryDtos;

namespace MS.WebUI.Services.CatalogServices.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task CreateCategoryAsync(CreateCategoryDto ccdto);
    Task UpdateCategoryAsync(UpdateCategoryDto ucdto);
    Task DeleteCategoryAsync(string id);
    Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
}
