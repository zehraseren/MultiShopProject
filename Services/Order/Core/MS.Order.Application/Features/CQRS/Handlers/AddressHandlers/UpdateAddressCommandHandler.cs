using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.CQRS.Commands.AddressCommands;

namespace MS.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public UpdateAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAddressCommand command)
    {
        var value = await _repository.GetByIdAsync(command.AddressId);
        value.UserId = command.UserId;
        value.Name = command.Name;
        value.Surname = command.Surname;
        value.Email = command.Email;
        value.Phone = command.Phone;
        value.Country = command.Country;
        value.District = command.District;
        value.City = command.City;
        value.Detail1 = command.Detail1;
        value.Detail2 = command.Detail2;
        value.Description = command.Description;
        value.ZipCode = command.ZipCode;
        await _repository.UpdateAsync(value);
    }
}
