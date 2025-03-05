using MediatR;
using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.Mediator.Commands.OrderingCommands;

namespace MS.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.OrderingId);
            value.UserId = request.UserId;
            value.TotalPrice = request.TotalPrice;
            value.OrderDate = request.OrderDate;
            await _repository.UpdateAsync(value);
        }
    }
}
