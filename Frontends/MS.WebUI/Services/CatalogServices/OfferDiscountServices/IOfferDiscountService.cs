using MS.UI.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MS.WebUI.Services.CatalogServices.OfferDiscountServices;

public interface IOfferDiscountService
{
    Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
    Task CreateOfferDiscountAsync(CreateOfferDiscountDto coddto);
    Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto uoddto);
    Task DeleteOfferDiscountAsync(string id);
    Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
}
