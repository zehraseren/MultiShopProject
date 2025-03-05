using MediatR;
using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.Mediator.Commands.OrderingCommands;

namespace MS.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                UserId = request.UserId,
                TotalPrice = request.TotalPrice,
                OrderDate = request.OrderDate
            });
        }
    }
}
