using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CatalogDtos.ContactDtos;
using MS.WebUI.Services.CatalogServices.ContactServices;

namespace MS.WebUI.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    void ContactViewbagList()
    {
        ViewBag.v1 = "MultiShop";
        ViewBag.v2 = "İletişim";
        ViewBag.v3 = "Mesaj Gönder";
    }

    public IActionResult Index()
    {
        ContactViewbagList();
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto ccdto)
    {
        ccdto.IsRead = false;
        ccdto.SendDate = DateTime.Now;
        await _contactService.CreateContactAsync(ccdto);
        return RedirectToAction("Index", "Default");
    }
}
