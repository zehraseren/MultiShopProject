using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.DataAccessLayer.Abstract;
using MS.Cargo.DataAccessLayer.Concrete;
using MS.Cargo.DataAccessLayer.Repositories;

namespace MS.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
{
    public EfCargoCompanyDal(CargoContext context) : base(context)
    {
    }
}
