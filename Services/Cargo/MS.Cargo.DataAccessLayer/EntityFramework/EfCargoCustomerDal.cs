using MS.Cargo.EntityLayer.Concrete;
using MS.Cargo.DataAccessLayer.Abstract;
using MS.Cargo.DataAccessLayer.Concrete;
using MS.Cargo.DataAccessLayer.Repositories;

namespace MS.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
{
    private readonly CargoContext _context;

    public EfCargoCustomerDal(CargoContext context) : base(context)
    {
        _context = context;
    }

    public CargoCustomer GetCargoCustomerById(string id)
    {
        var value = _context.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
        return value;
    }
}
