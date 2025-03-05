using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.CQRS.Results.AddressQueries;

namespace MS.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                UserId = x.UserId,
                District = x.District,
                City = x.City,
                Detail = x.District,
            }).ToList();
        }
    }
}
