namespace MS.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand
    {
        public RemoveOrderDetailCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
