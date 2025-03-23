using MS.Catalog.Dtos.BrandDtos;

namespace MS.Catalog.Services.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandAsync();
    Task CreateBrandAsync(CreateBrandDto cbdto);
    Task UpdateBrandAsync(UpdateBrandDto ubdto);
    Task DeleteBrandAsync(string id);
    Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
}
