using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.FeatureDtos;

namespace MS.Catalog.Services.FeatureServices;

public class FeatureService : IFeatureService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Feature> _featureCollection;

    public FeatureService(IMapper mapper, IMongoCollection<Feature> featureCollection)
    {
        _mapper = mapper;
        _featureCollection = featureCollection;
    }

    public async Task CreateFeatureAsync(CreateFeatureDto cfdto)
    {
        var value = _mapper.Map<Feature>(cfdto);
        await _featureCollection.InsertOneAsync(value);
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
    }

    public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
    {
        var values = await _featureCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultFeatureDto>>(values);
    }

    public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
    {
        var value = await _featureCollection.Find<Feature>(x => x.FeatureId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdFeatureDto>(value);
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto ufdto)
    {
        var value = _mapper.Map<Feature>(ufdto);
        await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == ufdto.FeatureId, value);
    }
}
