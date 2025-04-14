using MS.UI.DtoLayer.CatalogDtos.FeatureDtos;

namespace MS.WebUI.Services.CatalogServices.FeatureServices;

public interface IFeatureService
{
    Task<List<ResultFeatureDto>> GetAllFeatureAsync();
    Task CreateFeatureAsync(CreateFeatureDto cfdto);
    Task UpdateFeatureAsync(UpdateFeatureDto ufdto);
    Task DeleteFeatureAsync(string id);
    Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
}
