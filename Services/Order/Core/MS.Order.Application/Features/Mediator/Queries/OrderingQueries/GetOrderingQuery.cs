using MediatR;
using MS.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MS.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {
    }
}
