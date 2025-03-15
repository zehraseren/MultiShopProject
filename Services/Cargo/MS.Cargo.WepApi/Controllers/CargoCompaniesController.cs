using Microsoft.AspNetCore.Mvc;
using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.BusinessLayer.Abstract;
using MS.Cargo.DtoLayer.CargoCompanyDtos;
using Microsoft.AspNetCore.Authorization;

namespace MS.Cargo.WepApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController : ControllerBase
{
    private readonly ICargoCompanyService _companyService;

    public CargoCompaniesController(ICargoCompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public IActionResult CargoCompanyList()
    {
        var values = _companyService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCompany(int id)
    {
        var value = _companyService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoCompany(CreateCargoCompanyDto cccdto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            CargoCompanyName = cccdto.CargoCompanyName,
        };
        _companyService.TInsert(cargoCompany);
        return Ok("Kargo şirketi başarıyla oluşturuldu.");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCompany(int id)
    {
        _companyService.TRemove(id);
        return Ok("Kargo şirketi başarıyla silindi.");
    }

    [HttpPut]
    public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto uccdto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            CargoCompanyId = uccdto.CargoCompanyId,
            CargoCompanyName = uccdto.CargoCompanyName,
        };
        _companyService.TUpdate(cargoCompany);
        return Ok("Kargo şirketi başarıyla güncellendi.");
    }
}
