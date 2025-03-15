using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.BusinessLayer.Abstract;
using MS.Cargo.DataAccessLayer.Abstract;

namespace MS.Cargo.BusinessLayer.Concrete;

public class CargoDetailManager : ICargoDetailService
{
    private readonly ICargoDetailDal _cargoDetailDal;

    public CargoDetailManager(ICargoDetailDal cargoDetailDal)
    {
        _cargoDetailDal = cargoDetailDal;
    }

    public List<CargoDetail> TGetAll()
    {
        return _cargoDetailDal.GetAll();
    }

    public CargoDetail TGetById(int id)
    {
        return _cargoDetailDal.GetById(id);
    }

    public void TInsert(CargoDetail entity)
    {
        _cargoDetailDal.Insert(entity);
    }

    public void TRemove(int id)
    {
        _cargoDetailDal.Remove(id);
    }

    public void TUpdate(CargoDetail entity)
    {
        _cargoDetailDal.Update(entity);
    }
}
