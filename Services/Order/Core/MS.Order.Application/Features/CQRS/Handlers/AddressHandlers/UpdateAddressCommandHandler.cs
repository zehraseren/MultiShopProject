using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.CQRS.Commands.AddressCommands;

namespace MS.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
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
            value.District = command.District;
            value.City = command.City;
            value.Detail1 = command.Detail1;
            await _repository.UpdateAsync(value);
        }
    }
}
