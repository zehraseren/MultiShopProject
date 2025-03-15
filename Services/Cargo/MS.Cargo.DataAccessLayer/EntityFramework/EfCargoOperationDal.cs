using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.DataAccessLayer.Abstract;
using MS.Cargo.DataAccessLayer.Concrete;
using MS.Cargo.DataAccessLayer.Repositories;

namespace MS.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
{
    public EfCargoOperationDal(CargoContext context) : base(context)
    {

    }
}
