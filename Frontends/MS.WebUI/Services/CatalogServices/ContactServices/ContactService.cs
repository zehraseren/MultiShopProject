using Newtonsoft.Json;
using MS.UI.DtoLayer.CatalogDtos.ContactDtos;

namespace MS.WebUI.Services.CatalogServices.ContactServices;

public class ContactService : IContactService
{
    private readonly HttpClient _httpClient;

    public ContactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateContactAsync(CreateContactDto ccdto)
    {
        await _httpClient.PostAsJsonAsync("contacts", ccdto);
    }

    public async Task DeleteContactAsync(string id)
    {
        await _httpClient.DeleteAsync($"contacts?id={id}");
    }

    public async Task<List<ResultContactDto>> GetAllContactAsync()
    {
        var response = await _httpClient.GetAsync("contacts");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<ResultContactDto>>(data);
        return result;
    }

    public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
    {
        var response = await _httpClient.GetAsync($"contacts/{id}");
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<GetByIdContactDto>(data);
        return result;
    }

    public async Task UpdateContactAsync(UpdateContactDto ucdto)
    {
        await _httpClient.PutAsJsonAsync("contacts", ucdto);
    }
}
