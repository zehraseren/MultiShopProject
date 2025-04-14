using MS.UI.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MS.WebUI.Services.CatalogServices.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImageAsync();
    Task CreateProductImageAsync(CreateProductImageDto cpidto);
    Task UpdateProductImageAsync(UpdateProductImageDto upidto);
    Task DeleteProductImageAsync(string id);
    Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    Task<GetByIdProductImageDto> GetProductImagesByProductIdAsync(string id);
}
