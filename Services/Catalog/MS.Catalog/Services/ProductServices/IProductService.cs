using MS.Catalog.Dtos.ProductDtos;

namespace MS.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto cpdto);
        Task UpdateProductAsync(UpdateProductDto updto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<ResultProductWithCategoryDto> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId);
    }
}
