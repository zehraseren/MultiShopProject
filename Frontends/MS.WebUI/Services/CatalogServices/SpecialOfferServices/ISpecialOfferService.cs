using MS.UI.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MS.WebUI.Services.CatalogServices.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
    Task CreateSpecialOfferAsync(CreateSpecialOfferDto csodto);
    Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto usodto);
    Task DeleteSpecialOfferAsync(string id);
    Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
}
