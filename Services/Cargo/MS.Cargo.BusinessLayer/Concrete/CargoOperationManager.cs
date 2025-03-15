using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.BusinessLayer.Abstract;
using MS.Cargo.DataAccessLayer.Abstract;

namespace MS.Cargo.BusinessLayer.Concrete;

public class CargoOperationManager : ICargoOperationService
{
    private readonly ICargoOperationDal _cargoOperationDal;

    public CargoOperationManager(ICargoOperationDal cargoOperationDal)
    {
        _cargoOperationDal = cargoOperationDal;
    }

    public List<CargoOperation> TGetAll()
    {
        return _cargoOperationDal.GetAll();
    }

    public CargoOperation TGetById(int id)
    {
        return _cargoOperationDal.GetById(id);
    }

    public void TInsert(CargoOperation entity)
    {
        _cargoOperationDal.Insert(entity);
    }

    public void TRemove(int id)
    {
        _cargoOperationDal.Remove(id);
    }

    public void TUpdate(CargoOperation entity)
    {
        _cargoOperationDal.Update(entity);
    }
}
