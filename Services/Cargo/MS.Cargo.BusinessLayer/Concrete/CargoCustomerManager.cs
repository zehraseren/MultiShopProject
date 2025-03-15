using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.BusinessLayer.Abstract;
using MS.Cargo.DataAccessLayer.Abstract;

namespace MS.Cargo.BusinessLayer.Concrete;

public class CargoCustomerManager : ICargoCustomerService
{
    private readonly ICargoCustomerDal _cargoCustomerDal;

    public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
    {
        _cargoCustomerDal = cargoCustomerDal;
    }

    public List<CargoCustomer> TGetAll()
    {
        return _cargoCustomerDal.GetAll();
    }

    public CargoCustomer TGetById(int id)
    {
        return _cargoCustomerDal.GetById(id);
    }

    public CargoCustomer TGetCargoCustomerById(string id)
    {
        return _cargoCustomerDal.GetCargoCustomerById(id);
    }

    public void TInsert(CargoCustomer entity)
    {
        _cargoCustomerDal.Insert(entity);
    }

    public void TRemove(int id)
    {
        _cargoCustomerDal.Remove(id);
    }

    public void TUpdate(CargoCustomer entity)
    {
        _cargoCustomerDal.Update(entity);
    }

}
