using MS.Catalog.Dtos.ContactDtos;

namespace MS.Catalog.Services.ContactServices;

public interface IContactService
{
    Task<List<ResultContactDto>> GetAllContactAsync();
    Task CreateContactAsync(CreateContactDto ccdto);
    Task UpdateContactAsync(UpdateContactDto ucdto);
    Task DeleteContactAsync(string id);
    Task<GetByIdContactDto> GetByIdContactAsync(string id);
}
