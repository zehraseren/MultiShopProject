using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.CQRS.Results.AddressResults;

namespace MS.Order.Application.Features.CQRS.Handlers.AddressHandlers;

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
            Name = x.Name,
            Surname = x.Surname,
            Email = x.Email,
            Phone = x.Phone,
            Country = x.Country,
            City = x.City,
            District = x.District,
            Detail1 = x.Detail1,
            Detail2 = x.Detail2,
            Description = x.Description,
            ZipCode = x.ZipCode
        }).ToList();
    }
}
