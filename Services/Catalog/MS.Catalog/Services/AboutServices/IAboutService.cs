using MS.Catalog.Dtos.AboutDtos;

namespace MS.Catalog.Services.AboutServices;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllAboutAsync();
    Task CreateAboutAsync(CreateAboutDto cadto);
    Task UpdateAboutAsync(UpdateAboutDto uadto);
    Task DeleteAboutAsync(string id);
    Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
}
