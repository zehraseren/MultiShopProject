using MS.Cargo.EntityLayer.Concrete;

namespace MS.Cargo.BusinessLayer.Abstract;

public interface ICargoCustomerService : IGenericService<CargoCustomer>
{
    CargoCustomer TGetCargoCustomerById(string id);
}
