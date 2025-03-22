using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.FeatureSliderDtos;

namespace MS.Catalog.Services.FeatureSliderServices;

public class FeatureSliderService : IFeatureSliderService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;

    public FeatureSliderService(IMongoCollection<FeatureSlider> featureSliderCollection, IMapper mapper)
    {
        _featureSliderCollection = featureSliderCollection;
        _mapper = mapper;
    }

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto ccdto)
    {
        var value = _mapper.Map<FeatureSlider>(ccdto);
        await _featureSliderCollection.InsertOneAsync(value);
    }

    public async Task DeleteFeatureSliderAsync(string id)
    {
        await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
    }

    public Task FeatureSliderChangeStatusFalseAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task FeatureSliderChangeStatusTrueAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
    {
        var values = await _featureSliderCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultFeatureSliderDto>>(values);
    }

    public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
    {
        var value = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdFeatureSliderDto>(value);
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto ucdto)
    {
        var value = _mapper.Map<FeatureSlider>(ucdto);
        await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == ucdto.FeatureSliderId, value);
    }
}
