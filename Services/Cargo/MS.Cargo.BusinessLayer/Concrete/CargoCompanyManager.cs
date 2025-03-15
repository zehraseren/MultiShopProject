using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.BusinessLayer.Abstract;
using MS.Cargo.DataAccessLayer.Abstract;

namespace MS.Cargo.BusinessLayer.Concrete;

public class CargoCompanyManager : ICargoCompanyService
{
    private readonly ICargoCompanyDal _cargoCompanyDal;

    public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
    {
        _cargoCompanyDal = cargoCompanyDal;
    }

    public List<CargoCompany> TGetAll()
    {
        return _cargoCompanyDal.GetAll();
    }

    public CargoCompany TGetById(int id)
    {
        return _cargoCompanyDal.GetById(id);
    }

    public void TInsert(CargoCompany entity)
    {
        _cargoCompanyDal.Insert(entity);
    }

    public void TRemove(int id)
    {
        _cargoCompanyDal.Remove(id);
    }

    public void TUpdate(CargoCompany entity)
    {
        _cargoCompanyDal.Update(entity);
    }
}
