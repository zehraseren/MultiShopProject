using Microsoft.AspNetCore.Mvc;
using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using MS.Cargo.DtoLayer.CargoOperationDtos;

namespace MS.Cargo.WepApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController : ControllerBase
{
    private readonly ICargoOperationService _cargoOperationService;

    public CargoOperationsController(ICargoOperationService cargoOperationService)
    {
        _cargoOperationService = cargoOperationService;
    }

    [HttpGet]
    public IActionResult CargoOperationList()
    {
        var values = _cargoOperationService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoOperation(int id)
    {
        var value = _cargoOperationService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoOperation(CreateCargoOperationDto ccodto)
    {
        CargoOperation cargoOperation = new CargoOperation()
        {
            Barcode = ccodto.Barcode,
            Description = ccodto.Description,
            OperationDate = ccodto.OperationDate,
        };
        _cargoOperationService.TInsert(cargoOperation);
        return Ok("Kargo operasyonu başarıyla oluşturuldu.");
    }

    [HttpDelete]
    public IActionResult RemoveCargoOperation(int id)
    {
        _cargoOperationService.TRemove(id);
        return Ok("Kargo operasyonu başarıyla silindi.");
    }

    [HttpPut]
    public IActionResult UpdateCargoOperation(UpdateCargoOperationDto ucodto)
    {
        CargoOperation cargoOperation = new CargoOperation()
        {
            CargoOperationId = ucodto.CargoOperationId,
            Barcode = ucodto.Barcode,
            Description = ucodto.Description,
            OperationDate = ucodto.OperationDate,
        };
        _cargoOperationService.TUpdate(cargoOperation);
        return Ok("Kargo operasyonu başarıyla güncellendi.");
    }
}
