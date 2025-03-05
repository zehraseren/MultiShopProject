namespace MS.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
