using MS.Catalog.Dtos.ProductImageDtos;

namespace MS.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto cpidto);
        Task UpdateProductImageAsync(UpdateProductImageDto upidto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
