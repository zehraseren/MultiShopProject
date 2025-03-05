using MS.Order.Domain.Entities;
using MS.Order.Persistence.Context;
using MS.Order.Application.Interfaces;

namespace MS.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _context;

        public OrderingRepository(OrderContext context)
        {
            _context = context;
        }

        public List<Ordering> GetOrderingsByUserId(string id)
        {
            var values = _context.Orderings.Where(x => x.UserId == id).ToList();
            return values;
        }
    }
}
