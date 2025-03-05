using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.CQRS.Commands.AddressCommands;

namespace MS.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand command)
        {
            await _repository.CreateAsync(new Address
            {
                UserId = command.UserId,
                Name = command.Name,
                Surname = command.Surname,
                Email = command.Email,
                Phone = command.Phone,
                Country = command.Country,
                District = command.District,
                City = command.City,
                Detail1 = command.Detail1,
                Detail2 = command.Detail2,
                Description = command.Description,
                ZipCode = command.ZipCode
            });
        }
    }
}
