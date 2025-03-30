using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.ContactDtos;

namespace MS.Catalog.Services.ContactServices;

public class ContactService : IContactService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Contact> _contactCollection;

    public ContactService(IMapper mapper, IMongoCollection<Contact> contactCollection)
    {
        _mapper = mapper;
        _contactCollection = contactCollection;
    }

    public async Task CreateContactAsync(CreateContactDto ccdto)
    {
        var value = _mapper.Map<Contact>(ccdto);
        await _contactCollection.InsertOneAsync(value);
    }

    public async Task DeleteContactAsync(string id)
    {
        await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
    }

    public async Task<List<ResultContactDto>> GetAllContactAsync()
    {
        var values = await _contactCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultContactDto>>(values);
    }

    public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
    {
        var value = await _contactCollection.Find<Contact>(x => x.ContactId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdContactDto>(value);
    }

    public async Task UpdateContactAsync(UpdateContactDto ucdto)
    {
        var value = _mapper.Map<Contact>(ucdto);
        await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == ucdto.ContactId, value);
    }
}
