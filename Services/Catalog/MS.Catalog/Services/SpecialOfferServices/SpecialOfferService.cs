using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.SpecialOfferDtos;

namespace MS.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;

        public SpecialOfferService(IMapper mapper, IMongoCollection<SpecialOffer> SpecialOfferCollection)
        {
            _mapper = mapper;
            _specialOfferCollection = SpecialOfferCollection;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto ccdto)
        {
            var value = _mapper.Map<SpecialOffer>(ccdto);
            await _specialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _specialOfferCollection.Find<SpecialOffer>(x => x.SpecialOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(value);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto ucdto)
        {
            var value = _mapper.Map<SpecialOffer>(ucdto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == ucdto.SpecialOfferId, value);
        }
    }
}
