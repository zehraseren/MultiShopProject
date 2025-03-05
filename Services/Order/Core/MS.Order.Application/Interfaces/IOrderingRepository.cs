using MS.Order.Domain.Entities;

namespace MS.Order.Application.Interfaces
{
    public interface IOrderingRepository
    {
        public List<Ordering> GetOrderingsByUserId(string id);
    }
}
