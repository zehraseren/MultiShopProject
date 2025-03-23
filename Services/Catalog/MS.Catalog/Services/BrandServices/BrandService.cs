using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.BrandDtos;

namespace MS.Catalog.Services.BrandServices;

public class BrandService : IBrandService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Brand> _brandCollection;

    public BrandService(IMapper mapper, IMongoCollection<Brand> brandCollection)
    {
        _mapper = mapper;
        _brandCollection = brandCollection;
    }

    public async Task CreateBrandAsync(CreateBrandDto cbdto)
    {
        var value = _mapper.Map<Brand>(cbdto);
        await _brandCollection.InsertOneAsync(value);
    }

    public async Task DeleteBrandAsync(string id)
    {
        await _brandCollection.DeleteOneAsync(x => x.BrandId == id);
    }

    public async Task<List<ResultBrandDto>> GetAllBrandAsync()
    {
        var values = await _brandCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultBrandDto>>(values);
    }

    public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
    {
        var value = await _brandCollection.Find<Brand>(x => x.BrandId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdBrandDto>(value);
    }

    public async Task UpdateBrandAsync(UpdateBrandDto ubdto)
    {
        var value = _mapper.Map<Brand>(ubdto);
        await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == ubdto.BrandId, value);
    }
}
