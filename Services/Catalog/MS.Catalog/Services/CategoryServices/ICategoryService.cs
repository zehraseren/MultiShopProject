using MS.Catalog.Dtos.CategoryDtos;

namespace MS.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto ccdto);
        Task UpdateCategoryAsync(UpdateCategoryDto ucdto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
