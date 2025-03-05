namespace MS.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public GetOrderDetailByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
