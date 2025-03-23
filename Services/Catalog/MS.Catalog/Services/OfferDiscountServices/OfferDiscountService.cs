using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.OfferDiscountDtos;

namespace MS.Catalog.Services.OfferDiscountServices;

public class OfferDiscountService : IOfferDiscountService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;

    public OfferDiscountService(IMapper mapper, IMongoCollection<OfferDiscount> offerDiscountCollection)
    {
        _mapper = mapper;
        _offerDiscountCollection = offerDiscountCollection;
    }

    public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto coddto)
    {
        var value = _mapper.Map<OfferDiscount>(coddto);
        await _offerDiscountCollection.InsertOneAsync(value);
    }

    public async Task DeleteOfferDiscountAsync(string id)
    {
        await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountId == id);
    }

    public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
    {
        var value = await _offerDiscountCollection.Find<OfferDiscount>(x => x.OfferDiscountId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdOfferDiscountDto>(value);
    }

    public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
    {
        var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultOfferDiscountDto>>(values);
    }

    public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto uoddto)
    {
        var value = _mapper.Map<OfferDiscount>(uoddto);
        await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountId == uoddto.OfferDiscountId, value);
    }
}
