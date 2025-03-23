using MS.Catalog.Dtos.OfferDiscountDtos;

namespace MS.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto coddto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto uoddto);
        Task DeleteOfferDiscountAsync(string id);
        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
