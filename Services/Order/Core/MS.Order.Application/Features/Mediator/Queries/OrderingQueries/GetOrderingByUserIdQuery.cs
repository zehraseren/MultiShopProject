using MediatR;
using MS.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MS.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery : IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public GetOrderingByUserIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
