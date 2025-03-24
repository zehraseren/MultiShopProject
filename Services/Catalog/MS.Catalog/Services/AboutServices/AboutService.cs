using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.AboutDtos;

namespace MS.Catalog.Services.AboutServices;

public class AboutService : IAboutService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<About> _aboutCollection;

    public AboutService(IMapper mapper, IMongoCollection<About> aboutCollection)
    {
        _mapper = mapper;
        _aboutCollection = aboutCollection;
    }

    public async Task CreateAboutAsync(CreateAboutDto cadto)
    {
        var value = _mapper.Map<About>(cadto);
        await _aboutCollection.InsertOneAsync(value);
    }

    public async Task DeleteAboutAsync(string id)
    {
        await _aboutCollection.DeleteOneAsync(x => x.AboutId == id);
    }

    public async Task<List<ResultAboutDto>> GetAllAboutAsync()
    {
        var values = await _aboutCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultAboutDto>>(values);
    }

    public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
    {
        var value = await _aboutCollection.Find<About>(x => x.AboutId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdAboutDto>(value);
    }

    public async Task UpdateAboutAsync(UpdateAboutDto uadto)
    {
        var value = _mapper.Map<About>(uadto);
        await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == uadto.AboutId, value);
    }
}
