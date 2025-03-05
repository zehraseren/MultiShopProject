using MediatR;

namespace MS.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingCommand : IRequest
    {
        public RemoveOrderingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
