using MS.UI.DtoLayer.CatalogDtos.ContactDtos;

namespace MS.WebUI.Services.CatalogServices.ContactServices;

public interface IContactService
{
    Task<List<ResultContactDto>> GetAllContactAsync();
    Task CreateContactAsync(CreateContactDto ccdto);
    Task UpdateContactAsync(UpdateContactDto ucdto);
    Task DeleteContactAsync(string id);
    Task<GetByIdContactDto> GetByIdContactAsync(string id);
}
