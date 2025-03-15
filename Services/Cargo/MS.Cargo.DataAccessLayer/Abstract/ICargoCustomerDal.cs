using MS.Cargo.EntityLayer.Concrete;

namespace MS.Cargo.DataAccessLayer.Abstract;

public interface ICargoCustomerDal : IGenericDal<CargoCustomer>
{
    CargoCustomer GetCargoCustomerById(string id);
}
