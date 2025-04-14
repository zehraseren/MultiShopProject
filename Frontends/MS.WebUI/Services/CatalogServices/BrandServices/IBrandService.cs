using MS.UI.DtoLayer.CatalogDtos.BrandDtos;

namespace MS.WebUI.Services.CatalogServices.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandAsync();
    Task CreateBrandAsync(CreateBrandDto cbdto);
    Task UpdateBrandAsync(UpdateBrandDto ubdto);
    Task DeleteBrandAsync(string id);
    Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
}
