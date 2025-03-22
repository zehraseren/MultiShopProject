using MS.Catalog.Dtos.FeatureSliderDtos;

namespace MS.Catalog.Services.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
    Task CreateFeatureSliderAsync(CreateFeatureSliderDto cfsdto);
    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto ufsdto);
    Task DeleteFeatureSliderAsync(string id);
    Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
    Task FeatureSliderChangeStatusTrueAsync(string id);
    Task FeatureSliderChangeStatusFalseAsync(string id);
}
