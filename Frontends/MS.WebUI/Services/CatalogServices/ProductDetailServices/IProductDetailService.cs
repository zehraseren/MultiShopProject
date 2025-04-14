using MS.UI.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MS.WebUI.Services.CatalogServices.ProductDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
    Task CreateProductDetailAsync(CreateProductDetailDto cpddto);
    Task UpdateProductDetailAsync(UpdateProductDetailDto ucpdto);
    Task DeleteProductDetailAsync(string id);
    Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    Task<GetByIdProductDetailDto> GetProductDetailByProductIdAsync(string id);
}
