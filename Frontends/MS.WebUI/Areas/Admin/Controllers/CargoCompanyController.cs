using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.CargoDtos.CargoCompanyDtos;
using MS.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class CargoCompanyController : Controller
{
    private readonly ICargoCompanyService _cargoCompanyService;

    public CargoCompanyController(ICargoCompanyService cargoCompanyService)
    {
        _cargoCompanyService = cargoCompanyService;
    }

    public async Task<IActionResult> CargoCompanyList()
    {
        var result = await _cargoCompanyService.GetAllCargoCompanyAsync();
        return View(result);
    }

    [HttpGet]
    public IActionResult CreateCargoCompany()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto cccdto)
    {
        await _cargoCompanyService.CreateCargoCompanyAsync(cccdto);
        return RedirectToAction("CargoCompanyList");
    }

    public async Task<IActionResult> DeleteCargoCompany(int id)
    {
        await _cargoCompanyService.DeleteCargoCompanyAsync(id);
        return RedirectToAction("CargoCompanyList");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCargoCompany(int id)
    {
        var result = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto uccdto)
    {
        await _cargoCompanyService.UpdateCargoCompanyAsync(uccdto);
        return RedirectToAction("CargoCompanyList");
    }
}
