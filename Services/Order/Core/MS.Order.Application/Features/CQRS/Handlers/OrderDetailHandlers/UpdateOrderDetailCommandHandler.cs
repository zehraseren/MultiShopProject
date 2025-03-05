using MS.Order.Domain.Entities;
using MS.Order.Application.Interfaces;
using MS.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

namespace MS.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);
            value.OrderDetailId = command.OrderDetailId;
            value.ProductId = command.ProductId;
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;
            value.ProductAmount = command.ProductAmount;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(value);
        }
    }
}
