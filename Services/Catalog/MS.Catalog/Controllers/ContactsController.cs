using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Dtos.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using MS.Catalog.Services.ContactServices;

namespace MS.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
        var values = await _contactService.GetAllContactAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(string id)
    {
        var value = await _contactService.GetByIdContactAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactDto ccdto)
    {
        await _contactService.CreateContactAsync(ccdto);
        return Ok("İletişim başarıyla eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContact(string id)
    {
        await _contactService.DeleteContactAsync(id);
        return Ok("İletişim başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactDto ucdto)
    {
        await _contactService.UpdateContactAsync(ucdto);
        return Ok("İletişim başarıyla güncellendi.");
    }
}
