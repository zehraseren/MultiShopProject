using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MS.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MS.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductAmount = values.ProductAmount,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderingId = values.OrderingId
            };
        }
    }
}
