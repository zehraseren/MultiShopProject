using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.CQRS.Queries.AddressQueries;
using MS.Order.Application.Features.CQRS.Results.AddressResults;

namespace MS.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    private readonly IRepository<Address> _repository;
    public GetAddressByIdQueryHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return new GetAddressByIdQueryResult
        {
            AddressId = value.AddressId,
            UserId = value.UserId,
            Name = value.Name,
            Surname = value.Surname,
            Email = value.Email,
            Phone = value.Phone,
            Country = value.Country,
            City = value.City,
            District = value.District,
            Detail1 = value.Detail1,
            Detail2 = value.Detail2,
            Description = value.Description,
            ZipCode = value.ZipCode
        };
    }
}
