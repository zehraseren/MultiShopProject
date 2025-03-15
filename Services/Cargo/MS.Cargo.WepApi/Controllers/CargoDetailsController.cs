using Microsoft.AspNetCore.Mvc;
using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.BusinessLayer.Abstract;
using MS.Cargo.DtoLayer.CargoDetailDtos;
using Microsoft.AspNetCore.Authorization;

namespace MS.Cargo.WepApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController : ControllerBase
{
    private readonly ICargoDetailService _cargoDetailService;

    public CargoDetailsController(ICargoDetailService cargoDetailService)
    {
        _cargoDetailService = cargoDetailService;
    }

    [HttpGet]
    public IActionResult CargoDetailList()
    {
        var values = _cargoDetailService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoDetail(int id)
    {
        var value = _cargoDetailService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoDetail(CreateCargoDetailDto ccddto)
    {
        CargoDetail cargoDetail = new CargoDetail()
        {
            SenderCustomer = ccddto.SenderCustomer,
            ReceiverCustomer = ccddto.ReceiverCustomer,
            Barcode = ccddto.Barcode,
            CargoCompanyId = ccddto.CargoCompanyId
        };
        _cargoDetailService.TInsert(cargoDetail);
        return Ok("Kargo detayı başarıyla oluşturuldu.");
    }

    [HttpDelete]
    public IActionResult RemoveCargoDetail(int id)
    {
        _cargoDetailService.TRemove(id);
        return Ok("Kargo detayı başarıyla silindi.");
    }

    [HttpPut]
    public IActionResult UpdateCargoDetail(UpdateCargoDetailDto ucddto)
    {
        CargoDetail cargoDetail = new CargoDetail()
        {
            CargoDetailId = ucddto.CargoDetailId,
            SenderCustomer = ucddto.SenderCustomer,
            ReceiverCustomer = ucddto.ReceiverCustomer,
            Barcode = ucddto.Barcode,
            CargoCompanyId = ucddto.CargoCompanyId
        };
        _cargoDetailService.TUpdate(cargoDetail);
        return Ok("Kargo detayı başarıyla güncellendi.");
    }
}
