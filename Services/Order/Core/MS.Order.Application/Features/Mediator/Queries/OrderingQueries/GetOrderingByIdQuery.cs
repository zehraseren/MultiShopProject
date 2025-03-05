using MediatR;
using MS.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MS.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
    {
        public GetOrderingByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
