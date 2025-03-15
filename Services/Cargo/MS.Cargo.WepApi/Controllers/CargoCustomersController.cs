using Microsoft.AspNetCore.Mvc;
using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using MS.Cargo.DtoLayer.CargoCustomerDtos;

namespace MS.Cargo.WepApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController : ControllerBase
{
    private readonly ICargoCustomerService _customerService;

    public CargoCustomersController(ICargoCustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult CargoCustomerList()
    {
        var values = _customerService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCustomer(int id)
    {
        var value = _customerService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoCustomer(CreateCargoCustomerDto cccdto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            Name = cccdto.Name,
            Surname = cccdto.Surname,
            Email = cccdto.Email,
            Phone = cccdto.Phone,
            District = cccdto.District,
            City = cccdto.City,
            Address = cccdto.Address,
            UserCustomerId = cccdto.UserCustomerId,
        };
        _customerService.TInsert(cargoCustomer);
        return Ok("Kargo müşteri başarıyla oluşturuldu.");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCustomer(int id)
    {
        _customerService.TRemove(id);
        return Ok("Kargo müşteri başarıyla silindi.");
    }

    [HttpPut]
    public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto uccdto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            CargoCustomerId = uccdto.CargoCustomerId,
            Name = uccdto.Name,
            Surname = uccdto.Surname,
            Email = uccdto.Email,
            Phone = uccdto.Phone,
            District = uccdto.District,
            City = uccdto.City,
            Address = uccdto.Address,
            UserCustomerId = uccdto.UserCustomerId,
        };
        _customerService.TUpdate(cargoCustomer);
        return Ok("Kargo müşteri başarıyla güncellendi.");
    }
}
